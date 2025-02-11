using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "ItemInfo", menuName = "Scriptable Objects/ItemInfo")]
public class ItemInfo : ScriptableObject
{
    public LocalizedString itemName;
    public LocalizedString desc;
    public Sprite icon;
}
