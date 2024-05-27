using UnityEngine;
using Zenject;

public class CameraManager : MonoBehaviour
{
    private Camera cameraToManage;


    [Inject]
    public void Construct(Camera cameraToManage)
    {
        this.cameraToManage = cameraToManage;
    }

    public void InitCameraSettings(CameraSettingsConfig cameraSettings)
    {
        cameraToManage.transform.position    = cameraSettings.position;
        cameraToManage.transform.eulerAngles = cameraSettings.rotation;

        cameraToManage.fieldOfView   = cameraSettings.fieldOfView;
        cameraToManage.nearClipPlane = cameraSettings.nearClipPlane;
        cameraToManage.farClipPlane  = cameraSettings.farClipPlane;
    }
}