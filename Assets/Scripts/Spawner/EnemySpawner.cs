using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private Transform[] EnemyPaths;
    [SerializeField] private float spawnDelay = 5f;
    [SerializeField] private GameObject[] EnemysPrefabs;
    private float SpawnDelay;
    [SerializeField] private float DelayStartTimer;

    private void Update()
    {

        SpawnDelay -= Time.unscaledDeltaTime;
        DelayStartTimer -= Time.deltaTime;
        if (SpawnDelay <= 0f&& DelayStartTimer<=0)
        {
            SpawnEnemy();
            SpawnDelay = spawnDelay;
        }

       
    }

    private void SpawnEnemy()
    {
        System.Random random = new System.Random();
        int randomEnemy = random.Next(0, EnemysPrefabs.Length);
        GameObject NewEnemy = Instantiate(EnemysPrefabs[randomEnemy], EnemyPaths[0].position, Quaternion.identity);

        NewEnemy.GetComponent<Enemy>().waypoints = EnemyPaths;
    }

    private void OnDrawGizmos()
    {
        if (EnemyPaths != null)
            for (int i = 0; i < EnemyPaths.Length - 1; i++)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(EnemyPaths[i].position, EnemyPaths[i + 1].position);
            }
    }


   


}
