using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = .65f;
    
    private void Update()
    {
        if (GameManager.Instance._isPlaying)
        {
            transform.position += Vector3.left * _moveSpeed * Time.deltaTime;
        }
    }
}