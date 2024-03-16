using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggEnemySpawner : MonoBehaviour
{
    //[SerializeField] Transform eggCenterPos;
    [SerializeField] GameObject eggEnemyPrefab;
    [SerializeField] float spawnRadius = 5f;
    [SerializeField] float spawnInterval = 3f;
    float spawnTimer = 0f;
    bool onCooldown = false;

    private void Update()
    {
        if (onCooldown == false)
        {
            SpawnEnemy();
            spawnTimer = spawnInterval;
            onCooldown = true;
        }
        else if(onCooldown)
        {
            spawnTimer -= Time.deltaTime;
        }
        if (spawnTimer <= 0f)
        {
            onCooldown = false;
        }
    }
    void SpawnEnemy()
    {
        Vector2 direction = Random.insideUnitCircle.normalized * spawnRadius;
        Instantiate(eggEnemyPrefab, new Vector3(direction.x, transform.position.y, direction.y), Quaternion.identity);
    }
}
