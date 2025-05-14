using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI Components")]
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private TextMeshProUGUI _countdownText;
    
    [Header("Settings")]
    [SerializeField] private float _countdownTime = 3f;

    public bool _isPlaying;

    private void Awake()
    {
        Instance = this;
        
        Time.timeScale = 0f;
        StartCoroutine(CountdownToStart());
    }

    private void Start() {
        Application.targetFrameRate = 60;
        Physics2D.autoSyncTransforms = false;
    }

    public void GameOver() => StartCoroutine(DelayedGameOver());

    // Delayed Finish because of visual bugs
    IEnumerator DelayedGameOver()
    {
        yield return 0; // Wait for 1 frame.

        AudioManager.Instance.PlayGameOverSound();
        
        Time.timeScale = 0f;
        _gameOverCanvas.SetActive(true);
        Pause.Instance.pauseButtonOnGame.SetActive(false);
        _isPlaying = false;
    }

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

   IEnumerator CountdownToStart()
    {
        _countdownText.gameObject.SetActive(true);
        
        float countdown = _countdownTime;
        
        while (countdown > 0)
        {
            _countdownText.text = Mathf.Ceil(countdown).ToString();
            _countdownText.transform.localScale = Vector3.zero;
            _countdownText.transform.DOScale(Vector3.one, 0.5f).SetUpdate(true);
            yield return new WaitForSecondsRealtime(1f);
            countdown--;
        }
        
        _countdownText.text = "GO!";
        _countdownText.transform.DOScale(Vector3.one * 1.5f, 0.3f).SetUpdate(true);
        yield return new WaitForSecondsRealtime(0.5f);
        _countdownText.transform.DOScale(Vector3.zero, 0.2f).SetUpdate(true);
        yield return new WaitForSecondsRealtime(0.2f);
        
        _countdownText.gameObject.SetActive(false);
        Time.timeScale = 1f;

        _isPlaying = true;
    }

}
