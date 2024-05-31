using UnityEngine;

public class PipeSpawnner : MonoBehaviour
{
    public float minHeight = -1f;
    public float maxHeight = 1f;
    public float spawnRate = 1f;
    public GameObject pipe_prefab;
    private void OnEnable() {
        InvokeRepeating(nameof(SpawnPipe), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(SpawnPipe));
    }

    private void SpawnPipe() {
        Instantiate(
            pipe_prefab,
            transform.position + Vector3.up * Random.Range(minHeight, maxHeight),
            Quaternion.identity
        );
    }
}
