using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menuPannel;
    public GameObject[] menuSubPannels;
    private void Start()
    {
        foreach (var i in menuSubPannels)
        {
            i.SetActive(false);
        }
    }
    public void OnMenuButtonClicked()
    {
        menuPannel.SetActive(true);
    }
    public void OnSubButtonClicked(int index) 
    {
        foreach(var i in menuSubPannels)
        {
            i.SetActive(false);
        }
        menuSubPannels[index].SetActive(true);
    }
}
