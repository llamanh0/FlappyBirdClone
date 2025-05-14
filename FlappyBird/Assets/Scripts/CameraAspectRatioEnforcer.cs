using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAspectRatioEnforcer : MonoBehaviour
{
    private const float TargetAspect = 9f / 16f;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        UpdateCameraView();
        Application.onBeforeRender += UpdateCameraView;
    }

    private void OnDestroy() => Application.onBeforeRender -= UpdateCameraView;

    private void UpdateCameraView()
    {
        float currentAspect = (float)Screen.width / Screen.height;
        float scaleHeight = currentAspect / TargetAspect;

        if (scaleHeight < 1f){ _camera.rect = new Rect(0, (1f - scaleHeight) / 2f, 1f, scaleHeight); }
        else
        {
            float scaleWidth = 1f / scaleHeight;
            _camera.rect = new Rect((1f - scaleWidth) / 2f, 0, scaleWidth, 1f);
        }
    }
}