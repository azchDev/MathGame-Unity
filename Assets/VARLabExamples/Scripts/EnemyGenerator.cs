using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private int maxEnemies = 10;

    [SerializeField] private float delay = 2f;

    private int currentEnemies = 0;

    private float lastGenerateTime;

    // Start is called before the first frame update
    void Start()
    {
        lastGenerateTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentEnemies < maxEnemies && Time.time - lastGenerateTime > delay)
        {
            var enemy = Instantiate(prefab) as GameObject;

            enemy.transform.position = new Vector3(Random.Range(transform.position.x, transform.position.x+15f), Random.Range(transform.position.x, transform.position.x + 10f), Random.Range(transform.position.z, transform.position.z + 15f));

            lastGenerateTime = Time.time;
            currentEnemies++;
        }
    }
}
