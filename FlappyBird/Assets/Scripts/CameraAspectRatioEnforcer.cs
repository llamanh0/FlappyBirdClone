using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraAspectRatioEnforcer : MonoBehaviour
{
    private const float TargetAspect = 9f / 16f; // 9:16 aspect ratio
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        UpdateCameraView();
    }

    private void Update()
    {
        UpdateCameraView();
    }

    private void UpdateCameraView()
    {
        float currentAspect = (float)Screen.width / Screen.height;
        float scaleHeight = currentAspect / TargetAspect;

        // Letterbox/pillarbox oluştur
        if (scaleHeight < 1f) // Daha geniş ekran
        {
            Rect rect = _camera.rect;
            rect.width = 1f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1f - scaleHeight) / 2f;
            _camera.rect = rect;
        }
        else // Daha uzun ekran
        {
            float scaleWidth = 1f / scaleHeight;
            Rect rect = _camera.rect;
            rect.width = scaleWidth;
            rect.height = 1f;
            rect.x = (1f - scaleWidth) / 2f;
            rect.y = 0;
            _camera.rect = rect;
        }
    }
}