using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    [SerializeField] private int maxSnowballs = 20;

    [SerializeField] private float delay = 3f;

    public int currentSnowballs = 0;

    private float lastGenerateTime;

    // Start is called before the first frame update
    void Start()
    {
        lastGenerateTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentSnowballs < maxSnowballs && Time.time - lastGenerateTime > delay)
        {
            var snowball = Instantiate(prefab) as GameObject;

            snowball.transform.position = transform.position;

            lastGenerateTime = Time.time;
            currentSnowballs++;
        }
    }
}
