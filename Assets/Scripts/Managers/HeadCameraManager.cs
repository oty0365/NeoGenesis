using Unity.Cinemachine;
using UnityEngine;

public class HeadCameraManager : MonoBehaviour
{
    public static HeadCameraManager instance;
    public CinemachineCamera headCam;

    public void OnMapChanged(float camSize)
    {
        headCam.Lens.OrthographicSize = camSize;    
    }
}
