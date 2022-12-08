using UnityEngine;

public class SpawnerNewObstacle : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1f;
    private void OnEnable() {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn() {
        GameObject obstacle = Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
