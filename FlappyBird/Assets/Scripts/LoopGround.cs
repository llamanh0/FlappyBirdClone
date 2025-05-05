using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] private float _speed = 1.3f;
    [SerializeField] private float _width = 6f;

    private SpriteRenderer _spriteRenderer;

    private Vector2 _startSize;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _startSize = new Vector2(_spriteRenderer.size.x, _spriteRenderer.size.y);
    }

    void Update()
    {
        _spriteRenderer.size = new Vector2(_spriteRenderer.size.x + Time.deltaTime * _speed, _startSize.y);

        if (_spriteRenderer.size.x >= _width)
        {
            _spriteRenderer.size = _startSize;
        }
    }
}
