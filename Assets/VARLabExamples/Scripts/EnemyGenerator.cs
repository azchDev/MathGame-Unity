using System.Collections;
using System.Collections.Generic;
using TigerTail;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject snowballTh;
    [SerializeField] private GameObject snowballPositionAnchor;

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
            var throwSnowball = Instantiate(snowballTh) as GameObject;
            var getres = enemy.GetComponent<Enemy>();
          
           
            var setres = throwSnowball.GetComponent<ThrowableSnowball>();
            setres.result = getres.sum.R;

            throwSnowball.transform.position = snowballPositionAnchor.transform.position;
            enemy.transform.position = new Vector3(Random.Range(transform.position.x, transform.position.x+20f), Random.Range(transform.position.y, transform.position.y + 20f), Random.Range(transform.position.z, transform.position.z + 20f));

            lastGenerateTime = Time.time;
            currentEnemies++;
        }
    }
}
