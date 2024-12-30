using System;

namespace NoobGGApp.Domain.Common.Entities;

public interface IEntity<TKey> where TKey : IEquatable<TKey>
{
    TKey Id { get; set; }
}
