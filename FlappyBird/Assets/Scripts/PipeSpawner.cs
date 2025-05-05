using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float _maxTime = 1.7f;
    [SerializeField] private float _heightRange = 0.45f;
    [SerializeField] private GameObject _pipePrefab;

    [SerializeField] private Image _stageImage1;
    [SerializeField] private Image _stageImage2;
    [SerializeField] private Image _stageImage3;

    private float _timer;

    void Start()
    {
        SpawnPipe();
        StartCoroutine(NextStage());
    }

    void Update()
    {
        if (_timer > _maxTime)
        {
            SpawnPipe();
            _timer = 0;
        }
        _timer += Time.deltaTime;
    }

    private void SpawnPipe()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, Random.Range(-_heightRange, _heightRange) + 0.2f, 0);
        GameObject pipe = Instantiate(_pipePrefab, spawnPosition, Quaternion.identity);

        Destroy(pipe, 10f);

    }

    IEnumerator NextStage()
    {
        yield return new WaitForSecondsRealtime(33f);
        _maxTime = 1.5f;
        _stageImage1.color = Color.green;
        yield return new WaitForSecondsRealtime(30f);
        _maxTime = 1.3f;
        _stageImage2.color = Color.green;
        yield return new WaitForSecondsRealtime(30f);
        _maxTime = 1f;
        _stageImage3.color = Color.green;
    }
}
