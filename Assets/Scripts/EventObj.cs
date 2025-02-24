using UnityEngine;

public class EventObj : MonoBehaviour,IInteractable,IEventObjects
{
    public string objectName;
    public Dialouges dialouges;
    public void TriggerEventObjects()
    {
        if (MapManager.instance.mapData.MapEventData.ContainsKey(objectName))
        {
            gameObject.SetActive(false);
        }
    }
    public void OnInteract()
    {
        DialogManager.instance.DoTalk(dialouges, 0, 0, objectName, false);
    }
    
    void Start()
    {
        TriggerEventObjects();
    }
}
