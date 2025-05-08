using UnityEngine;
using System.Collections;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 1.5f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private float _pipeLifetime = 7f;

    private float _timer;
    private Coroutine _spawnCoroutine;

    private void Start()
    {
        _timer = _spawnInterval;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if (_timer >= _spawnInterval)
        {
            _spawnCoroutine = StartCoroutine(SpawnPipe());
            _timer = 0f;
        }
    }

    private IEnumerator SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange));
        GameObject pipe = PipePool.Instance.GetPipe(spawnPos);
        
        yield return new WaitForSeconds(_pipeLifetime);
        
        if (pipe.activeInHierarchy) // Pipe is already active (if player didn't die)
        {
            PipePool.Instance.ReturnPipe(pipe);
        }
    }

    private void OnDisable()
    {
        if (_spawnCoroutine != null)
        {
            StopCoroutine(_spawnCoroutine);
        }
    }
}