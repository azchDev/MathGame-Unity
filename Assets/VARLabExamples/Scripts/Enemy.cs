using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TigerTail
{

    public class Enemy : MonoBehaviour, IDamageable
    {
        [SerializeField] private float movementSpeed = 3f;
        [SerializeField] private float rotationSpeed = 100f;

        private bool isWandering = false;
        private bool isRotatingLeft = false;
        private bool isRotatingRight = false;
        private bool isMoving = false;

        private Vector3 startPosition;
        [SerializeField] private int counter=5;
        private int moves=0;

        public void TakeDamage(float damage)
        {
            Destroy(gameObject);
        }



        // Start is called before the first frame update
        void Start()
        {
            startPosition = new Vector3(transform.position.x,1.0f,transform.position.z);
        }



        // Update is called once per frame
        void Update()
        {
            if (!isWandering && moves!=counter)
            {
              
                StartCoroutine(Wander());
                moves++;
            }
            if (isRotatingRight)
            {
                transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
            }
            if (isRotatingLeft)
            {
                transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
            }
            if (isMoving)
            {
                
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
                
            }
            if (moves == counter)
            {
                
                transform.position = Vector3.MoveTowards(transform.position, startPosition, movementSpeed * Time.deltaTime);
              
                if (Vector3.Distance(new Vector3(transform.position.x,1.0f,transform.position.z), startPosition) < 0.1f)
                {
                 
                    moves = 0;
                }
               
            }
        }

        IEnumerator Wander()
        {
            int rotTime = Random.Range(1, 3);
            int rotateWait = Random.Range(0, 1);
            int rotateLR = Random.Range(0, 3);
            int walkWait = Random.Range(1, 2);
            int walkTime = Random.Range(1, 3);
            isWandering = true;

            yield return new WaitForSeconds(walkWait);
            isMoving = true;
            yield return new WaitForSeconds(walkTime);
            isMoving = false;
            yield return new WaitForSeconds(rotateWait);
            if (rotateLR == 1)
            {
                isRotatingRight = true;
                yield return new WaitForSeconds(rotTime);
                isRotatingRight = false;
            }
            if (rotateLR == 2)
            {
                isRotatingLeft = true;
                yield return new WaitForSeconds(rotTime);
                isRotatingLeft = false;
            }
            isWandering = false;
        }
        
        
    }

}