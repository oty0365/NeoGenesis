using Unity.Cinemachine;
using UnityEngine;

public class HeadCameraManager : MonoBehaviour
{
    public static HeadCameraManager instance;
    public CinemachineCamera headCam;

    private void Awake()
    {
        instance = this;
    }
    public void ChangeLens(float camSize)
    {
        headCam.Lens.OrthographicSize = camSize;    
    }
}
