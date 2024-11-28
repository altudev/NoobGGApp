using System;
using System.Reflection;
using System.Text;
using NoobGGApp.Application.Common.Attributes;
using NoobGGApp.Application.Common.Interfaces;

namespace NoobGGApp.Infrastructure.Services;

public class CacheKeyFactory : ICacheKeyFactory
{
    /// <summary>
    /// Cache key'i oluşturur.
    /// </summary>
    /// <typeparam name="TRequest">Cache edilebilir istek tipi.</typeparam>
    /// <param name="request">Cache edilecek istek.</param>
    /// <returns>Oluşturulan cache key'i.</returns>
    public string CreateCacheKey<TRequest>(TRequest request) where TRequest : ICacheable
    {
        // İsteğin tip adını alır.
        var typeName = typeof(TRequest).Name;

        // İsteğin CacheGroup özelliğini alır. (Bu örnekte kullanılmıyor ama ileride kullanılabilir.)
        var cacheGroup = request.CacheGroup;

        // CacheKeyPartAttribute özniteliğine sahip tüm özellikleri alır ve adlarına göre sıralar.
        var properties = typeof(TRequest).GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.GetCustomAttribute<CacheKeyPartAttribute>() != null)
            .OrderBy(p => p.Name);

        // Cache key'ini oluşturacak StringBuilder nesnesi.
        var keyBuilder = new StringBuilder();

        // Key'e istek tip adını ekler.
        keyBuilder.Append(typeName);

        // Her özellik için:
        foreach (var prop in properties)
        {
            // Özelliğin CacheKeyPartAttribute özniteliğini alır.
            var attr = prop.GetCustomAttribute<CacheKeyPartAttribute>()!;

            // Özelliğin değerini alır.
            var value = prop.GetValue(request);

            // Değeri normalize eder.
            string normalizedValue = NormalizeValue(value, attr);

            // Normalize edilmiş değeri key'e ekler.
            keyBuilder.Append($"_{attr.Prefix}{normalizedValue}");
        }

        // Oluşturulan cache key'ini döndürür. Örnek: GetAllGameRegionsQuery_123_Turkiye_tr
        return keyBuilder.ToString();
    }

    /// <summary>
    /// Verilen değeri normalize eder. Null değerler için "null" döndürür, aksi takdirde değeri stringe çevirir ve istenirse Uri.EscapeDataString ile encode eder.
    /// </summary>
    /// <param name="value">Normalize edilecek değer.</param>
    /// <param name="attr">CacheKeyPartAttribute özniteliği.</param>
    /// <returns>Normalize edilmiş değer.</returns>
    private string NormalizeValue(object? value, CacheKeyPartAttribute attr)
    {
        // Değer null ise "null" döndürür.
        if (value is null)
            return "null";

        // Değeri stringe çevirir, null ise "null" döndürür.
        string stringValue = value.ToString() ?? "null";

        // Encode özelliği aktif ise Uri.EscapeDataString ile encode eder.
        if (attr.Encode)
        {
            stringValue = Uri.EscapeDataString(stringValue);
        }

        // Normalize edilmiş değeri döndürür.
        return stringValue;
    }
}
