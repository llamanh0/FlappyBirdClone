using TMPro;
using UnityEngine;
using DG.Tweening;

public class Score : MonoBehaviour
{
    public static Score instance;

    [SerializeField] private TextMeshProUGUI _currentScoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    private int _score;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

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
        
        // Pulse efekti
        _currentScoreText.transform.DOPunchScale(Vector3.one * 1.3f, 0.5f, 1, 0.5f)
            .OnComplete(() => _currentScoreText.transform.localScale = Vector3.one);
        UpdateBestScore();
    }
}
