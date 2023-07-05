using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn instance;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private RectTransform enemyContainer;

    private GameObject spawnedEnemy;

    public void Spawn()
    {
        if (spawnedEnemy != null)
        {
            Destroy(spawnedEnemy);
        }
        spawnedEnemy = Instantiate(enemyPrefab, enemyContainer);
        spawnedEnemy.GetComponent<Enemy>().SetParameters();
    }

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Awake()
    {
        Singleton();
    }
}
