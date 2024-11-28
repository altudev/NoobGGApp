namespace NoobGGApp.Application.Common.Interfaces;

public interface ICacheKeyFactory
{
    string CreateCacheKey<TRequest>(TRequest request) where TRequest : ICacheable;
}