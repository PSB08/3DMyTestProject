using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAdjustment : MonoBehaviour
{
    public List<GameObject> enemies = new List<GameObject>();
    public EnemySpawner spawner;

    private void Start()
    {
        
    }

    private void Update()
    {
        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (enemies.Contains(enemy))
        {
            return;
        }
        enemies.Add(enemy);
        if (enemies.Count > 50)
        {
            spawner.gameObject.SetActive(false);
        }
    }

}
