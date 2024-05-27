using UnityEngine;

[CreateAssetMenu(menuName = "Configs/CameraSettingsConfig", fileName = "CameraSettingsConfig", order = 0)]
public class CameraSettingsConfig : ScriptableObject
{
    public Vector3 position;
    public Vector3 rotation;

    public uint  fieldOfView;
    public float nearClipPlane;
    public float farClipPlane;
}