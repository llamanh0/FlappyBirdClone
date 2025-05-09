using UnityEngine;

public class LoopGround : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = .65f;
    
    private void Update()
    {
        if (GameManager.Instance._isPlaying)
        {
            if(transform.position.x <= -1.5f)
            {
                transform.position = new Vector3(1.5f, transform.position.y, transform.position.z);
            }
            transform.position += Vector3.left * _moveSpeed * Time.deltaTime;
            
        }
    }
}
