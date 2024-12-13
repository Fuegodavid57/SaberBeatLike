using UnityEngine;

public interface IManageable<Key>
{
    Key ID { get; }
    void SetId(Key _key);
    bool IsValidItem { get; }
    void Enable();
    void Disable();
}