using System.Collections.Generic;
using UnityEngine;

public interface IManager<Key, Value> where Value : IManageable<Key>
{
    Dictionary<Key, Value> ManagedData { get; }
    void Add(Value _value);
    void Remove(Value _value);
    void Remove(Key _id);
    void Enable(Value _value);
    void Disable(Value _value);
    void Enable(Key _id);
    void Disable(Key _id);
    Value Get(Key _id);
    bool Exist(Key _id);
    bool Exist(Value _value);
}