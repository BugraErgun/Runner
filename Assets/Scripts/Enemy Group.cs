using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGroup : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform enemiesParent;

    [Header("Settings")]
    [SerializeField] private int amount;
    [SerializeField] private float angle;
    [SerializeField] private float radius;

    void Start()
    {
        GenerateEnemies();
    }

    void Update()
    {
        
    }
    private void GenerateEnemies()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 enemyLocalPos = GetRunnerLocalPosition(i);

            Vector3 enemyWorldPos = enemiesParent.TransformPoint(enemyLocalPos);

            Instantiate(enemyPrefab,enemyWorldPos, Quaternion.identity,enemiesParent);
        }
    }
    private Vector3 GetRunnerLocalPosition(int index)
    {
        float x = radius * Mathf.Sqrt(index) * Mathf.Cos(Mathf.Deg2Rad * index * angle);
        float z = radius * Mathf.Sqrt(index) * Mathf.Sin(Mathf.Deg2Rad * index * angle);

        return new Vector3(x, 0, z);
    }
}
