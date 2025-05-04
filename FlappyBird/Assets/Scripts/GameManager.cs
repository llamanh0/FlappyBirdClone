using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        Debug.Log("Game Over");
    }
}
