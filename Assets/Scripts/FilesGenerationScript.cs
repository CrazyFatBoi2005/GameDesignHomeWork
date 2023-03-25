using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class FilesGenerationScript : MonoBehaviour
{
    [SerializeField] private GameObject _filePrefab;

    [SerializeField] private Vector3 minPosition;
    [SerializeField] private Vector3 maxPosition;

    [SerializeField] private float _delay = 5f;
    [SerializeField] List<GameObject> files = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(spawnColdown(_delay));
    }

    private void SpawnFile()
    {
        var position = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            0f);
        var file = Instantiate(_filePrefab, position, Quaternion.identity);
        files.Add(file);
    }

    private IEnumerator spawnColdown(float timer)
    {
        yield return new WaitForSeconds(timer);
        SpawnFile();
        StartCoroutine(spawnColdown(timer * 0.95f));
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(minPosition, new Vector3(0.1f, 0.1f, 0.01f));
        Gizmos.DrawWireCube(maxPosition, new Vector3(0.1f, 0.1f, 0.01f));
    }
}
