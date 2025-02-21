using UnityEngine;

public class ComonNonSaveableInteractableObj : MonoBehaviour,IInteractable
{
    public Dialouges dialouges;
    public string objectName;

    public void OnInteract()
    {
        DialogManager.instance.DoTalk(dialouges, 0, 0, objectName,false);
    }
}
