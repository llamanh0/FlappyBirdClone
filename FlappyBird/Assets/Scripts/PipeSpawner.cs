using UnityEngine;
using System.Collections;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval = 1.5f;
    [SerializeField] private float _pipeLifetime = 7f;

    private float _timer;

    private void Start() => _timer = _spawnInterval;

    private void Update()
    {
        if (!GameManager.Instance._isPlaying) return;
        _timer += Time.deltaTime;
        
        if (_timer >= _spawnInterval)
        {
            StartCoroutine(SpawnPipe());
            _timer = 0f;
        }
    }

    private IEnumerator SpawnPipe()
    {
        Vector3 spawnPos = transform.position + new Vector3(0, Random.Range(-0.3f, 0.7f));
        GameObject pipe = PipePool.Instance.GetPipe(spawnPos);
        
        yield return new WaitForSeconds(_pipeLifetime);
        
        // Pipe is already active (if player didn't die)
        if (pipe.activeInHierarchy) { PipePool.Instance.ReturnPipe(pipe); }
    }
}