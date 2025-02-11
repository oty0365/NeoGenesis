using UnityEngine;

[CreateAssetMenu(fileName = "ItemSet", menuName = "Scriptable Objects/ItemSet")]
public class ItemSet : ScriptableObject
{
    public string itemCode;
    public ItemInfo itemInfo;
}
