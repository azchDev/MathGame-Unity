using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetrieveSnowballs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(ColorChange());
        GameObject[] snowballs = GameObject.FindGameObjectsWithTag("tSnowball");
        GameObject[] generator = GameObject.FindGameObjectsWithTag("SBG");
        
        foreach (GameObject GO in snowballs)
        {
            GO.transform.position = generator[0].transform.position;
        }
    }//-0.5 .075 23.1           D1 58.6 3.34 48.37

    IEnumerator ColorChange()
    {
        GameObject sun = GameObject.FindGameObjectWithTag("Sun");
        var orig = sun.GetComponent<Light>().color;

        Debug.Log(orig);
        sun.GetComponent<Light>().color = new Color(0.01176471f, 0.1372549f, 0.7568628f);

        yield return new WaitForSeconds(5f);
        sun.GetComponent<Light>().color = orig;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
