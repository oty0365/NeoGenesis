using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterInteractionData
{
    public Dictionary<string,Dictionary<string,int>> characterInteractionData= new Dictionary<string,Dictionary<string,int>>();
}

public class InteractionManager : MonoBehaviour
{
    public CharacterInteractionData interactionData;
    public string characterCode;
    public CharacterSets characterSets;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
