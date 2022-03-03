using System.Collections;
using System.Collections.Generic;
using TigerTail;
using UnityEngine;

public class RetrieveSnowballs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") 
        { 
            StartCoroutine(ColorChange());
            
            GameObject[] snowballs = GameObject.FindGameObjectsWithTag("tSnowball");
            GameObject generator = GameObject.FindGameObjectWithTag("SBG");
        
            foreach (GameObject GO in snowballs)
            {

                
                GO.transform.position = generator.transform.position;
                GO.GetComponent<ThrowableSnowball>().state = ThrowableSnowball.State.Pickup;
                GO.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

            }
        }
    }

    IEnumerator ColorChange()
    {
        GameObject sun = GameObject.FindGameObjectWithTag("Sun");
        var orig = sun.GetComponent<Light>().color;

     
        sun.GetComponent<Light>().color = new Color(0.01176471f, 0.1372549f, 0.7568628f);

        yield return new WaitForSeconds(5f);
        sun.GetComponent<Light>().color = orig;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
