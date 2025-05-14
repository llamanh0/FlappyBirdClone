using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioClip _jumpSound, _scoreSound, _gameOverSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }

        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null) { _audioSource = gameObject.AddComponent<AudioSource>(); }
    }

    public void PlayJumpSound() => PlaySound(_jumpSound);

    public void PlayScoreSound() => PlaySound(_scoreSound);

    public void PlayGameOverSound() => PlaySound(_gameOverSound);

    private void PlaySound(AudioClip clip)
    {
        if (clip != null){ _audioSource.PlayOneShot(clip); }
    }
}