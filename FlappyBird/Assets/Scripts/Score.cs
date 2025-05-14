using TMPro;
using UnityEngine;
using DG.Tweening;

public class Score : MonoBehaviour
{
    public static Score Instance;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;
    [SerializeField] private TextMeshProUGUI _fpsText;

    [SerializeField] private float _fpsUpdateInterval = 0.5f;

    private float _fpsTimer;
    private int _frameCount;

    private int _score;

    void Awake() { if (Instance == null) { Instance = this; } }

    void Update() => UpdateFPSCounter();

    void Start()
    {
        _currentScoreText.text = _score.ToString();

        _bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        UpdateBestScore();
    }

    private void UpdateBestScore()
    {
        if (_score > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", _score);
            _bestScoreText.text = _score.ToString();
        }
    }

    public void UpdateScore()
    {
        _score++;
        _currentScoreText.text = _score.ToString();
        
        // Pulse effect
        _currentScoreText.transform.DOPunchScale(Vector3.one * 1.3f, 0.5f, 1, 0.5f)
            .OnComplete(() => _currentScoreText.transform.localScale = Vector3.one);
        UpdateBestScore();
    }

    private void UpdateFPSCounter()
        {
            if (_fpsText != null)
            {
                _frameCount++;
                _fpsTimer += Time.unscaledDeltaTime;

                if (_fpsTimer >= _fpsUpdateInterval)
                {
                    float fps = _frameCount / _fpsTimer;
                    _fpsText.text = $"{Mathf.Round(fps)} FPS";
                    
                    _frameCount = 0;
                    _fpsTimer = 0;
                }
            }
        }
}
