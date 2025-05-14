using UnityEngine;
using System.Collections.Generic;

public class PipePool : MonoBehaviour
{
    public static PipePool Instance { get; private set; }
    
    [SerializeField] private GameObject _pipePrefab;
    [SerializeField] private int _initialPoolSize = 7;
    
    private Queue<GameObject> _pipePool = new Queue<GameObject>();

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else
        {
            Destroy(gameObject);
            return;
        }

        InitializePool();
    }

    private void InitializePool()
    {
        // Creating the objects
        for (int i = 0; i < _initialPoolSize; i++)
        {
            GameObject pipe = Instantiate(_pipePrefab);
            pipe.SetActive(false);
            _pipePool.Enqueue(pipe);
        }
    }

    public GameObject GetPipe(Vector3 position)
    {
        GameObject pipe;
        
        if (_pipePool.Count > 0) { pipe = _pipePool.Dequeue(); } // If the pool is not empty, get the first pipe
        else { pipe = Instantiate(_pipePrefab); } // If the pool is empty, create a new pipe

        pipe.transform.position = position;
        pipe.SetActive(true);
        return pipe;
    }

    public void ReturnPipe(GameObject pipe)
    {
        pipe.SetActive(false);
        _pipePool.Enqueue(pipe);
    }
}