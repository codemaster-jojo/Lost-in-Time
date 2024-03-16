using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggEnemySpawner : MonoBehaviour
{
    [SerializeField] Transform eggTransform;
    [SerializeField] GameObject eggEnemyPrefab;
    [SerializeField] float spawnRadius = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnEnemy();
        }
    }
    void SpawnEnemy()
    {
        Vector2 direction = Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(eggEnemyPrefab, new Vector3(direction.x, transform.position.y, direction.y), Quaternion.identity);
    }
}
