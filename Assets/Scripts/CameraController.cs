using Sirenix.OdinInspector;
using Unity.Cinemachine;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Splines;

public class CameraController : MonoBehaviour
{
    public CinemachineCamera camA;
    public CinemachineCamera camB;
    public CinemachineCamera camC;
    private int currentCam = 0;

    void Start()
    {
        ActivateCamera(0);
    }

    [Button]
    public void SwitchCameras()
    {
        currentCam++;

        if (currentCam > 2)
            currentCam = 0;

        ActivateCamera(currentCam);
    }

    void ActivateCamera(int index)
    {
        camA.Priority = 10;
        camB.Priority = 10;
        camC.Priority = 10;

        switch (index)
        {
            case 0:
                camA.Priority = 20;
                break;
            case 1:
                camB.Priority = 20;
                break;
            case 2:
                camC.Priority = 20;
                break;
        }
    }
}