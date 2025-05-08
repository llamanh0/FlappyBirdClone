using UnityEngine;

public class BirdController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 1.5f;
    [SerializeField] private float _rotationSpeed = 10f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * _jumpForce;
            if (GameManager.Instance._isPlaying) {AudioManager.Instance.PlayJumpSound();}
        }
    }

    private void FixedUpdate() {
        if (!GameManager.Instance._isPlaying) return;

        if (Time.frameCount % 3 == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, rb.linearVelocityY * _rotationSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.GameOver();
    }
}
