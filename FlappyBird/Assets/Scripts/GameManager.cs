using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private TextMeshProUGUI _countdownText;
    [SerializeField] private float _countdownTime = 3f;



    private void Awake()
    {
        Instance = this;
        
        Time.timeScale = 0f;
        StartCoroutine(CountdownToStart());
    }

    public void GameOver()
    {
        AudioManager.Instance.PlayGameOverSound();
        _gameOverCanvas.SetActive(true);

        Time.timeScale = 0f;
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

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
    }

}
