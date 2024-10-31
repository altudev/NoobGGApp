using System;

namespace NoobGGApp.Domain.Common.Entities;

public interface IEntity<TKey> where TKey : struct
{
    TKey Id { get; set; }
}
