using System.Collections.Generic;
using UnityEngine;

public class Manager<T, Key, Value> : Singleton<T>, IManager<Key, Value> where T : MonoBehaviour where Value : IManageable<Key>
{
    Dictionary<Key, Value> allValues = new Dictionary<Key, Value>();
    [SerializeField] int count = 0;
    public Dictionary<Key, Value> ManagedData => allValues;

    virtual public void Add(Value _value)
    {
        if (Exist(_value)) return;
        allValues[_value.ID] = _value;
        count++;
    }

    virtual public void Disable(Value _value)
    {
        _value?.Disable();
    }

    virtual public void Disable(Key _id)
    {
        if (_id == null) return;
        Disable(Get(_id));
    }

    virtual public void Enable(Value _value)
    {
        _value?.Enable();
    }

    virtual public void Enable(Key _id)
    {
        if (_id == null) return;
        Value _item = Get(_id);
        _item?.Enable();
    }

    virtual public bool Exist(Key _id)
    {
        if (_id == null) return false;
        if (allValues.ContainsKey(_id)) return true;
        return false;
    }

    virtual public bool Exist(Value _value)
    {
        return Exist(_value.ID);
    }

    virtual public Value Get(Key _id)
    {
        if (!Exist(_id)) return default(Value);
        IManageable<Key> _item = allValues[_id];
        return (Value)_item;
    }

    virtual public void Remove(Value _value)
    {
        Remove(_value.ID);
        count--;
    }

    virtual public void Remove(Key _id)
    {
        if (Exist(_id))
        {
            allValues.Remove(_id);
        }
    }
}