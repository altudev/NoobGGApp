using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using NoobGGApp.Application.Common.Models.Queues;
using NoobGGApp.Application.Features.Auth.Commands.Register;

namespace NoobGGApp.Application.Common.JsonConverters;

public class BaseEmailMessageJsonConverter : JsonConverter<BaseEmailMessage>
{
    public override BaseEmailMessage Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        if (!doc.RootElement.TryGetProperty("MessageType", out var typeProperty))
        {
            throw new JsonException("MessageType bulunamadı.");
        }

        var messageType = (EmailMessageType)typeProperty.GetInt32();

        switch (messageType)
        {
            case EmailMessageType.UserRegistered:
                return doc.Deserialize<UserRegisteredMessage>(options)!;
            case EmailMessageType.ForgotPassword:
            // ...
            default:
                throw new NotSupportedException($"Desteklenmeyen EmailMessageType: {messageType}");
        }
    }

    public override void Write(Utf8JsonWriter writer, BaseEmailMessage value, JsonSerializerOptions options)
    {
        // Giden mesajları serialize ederken hangi alt tipe göre davranacağınızı yazabilirsiniz.
        JsonSerializer.Serialize(writer, (object)value, options);
    }
}

