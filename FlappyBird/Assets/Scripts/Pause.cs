using UnityEngine;

public class Pause : MonoBehaviour
{
    public static Pause Instance;

    public GameObject pausePanel, pauseButtonOnGame;

    public bool _isPaused = false;

    void Awake() { if (Instance == null) { Instance = this; } }

    public void TogglePause()
    {
        if (Time.timeScale == 1 && GameManager.Instance._isPlaying)
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
            pauseButtonOnGame.SetActive(false);
            _isPaused = !_isPaused;
        }
        else if (Time.timeScale == 0 && GameManager.Instance._isPlaying)
        {
            Time.timeScale = 1;
            pausePanel.SetActive(false);
            pauseButtonOnGame.SetActive(true);
            _isPaused = !_isPaused;
        }
    }


    
}
