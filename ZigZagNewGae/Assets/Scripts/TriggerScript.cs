using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TriggerScript : MonoBehaviour
{

    public GameObject newPlatform;
    public GameObject ball;

    float size;
    Vector3 currentPos;
    

    // Start is called before the first frame update
    void Start()
    {
       size = newPlatform.transform.localScale.x;
       currentPos = newPlatform.transform.position;
       ball = GameObject.Find("Ball");

    }

    void FirstSpawn()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (ball.GetComponent<Rigidbody>().velocity.x == 0 && ball.GetComponent<Rigidbody>().velocity.z == 0)
            {
                SpawnPlatform();

            }
        }
    }


    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < 10; i++)
        {
             FirstSpawn();
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            if (!Physics.Raycast(transform.position, Vector3.right, 2f) && !Physics.Raycast(transform.position, Vector3.forward, 2f))
            {
                int rand = Random.Range(0,6);

            if (rand == 3)
            {
                for (int i = 0; i < 10; i++)
                {
                    SpawnPlatform();
                }
            }
           

            else 
            { 
                SpawnPlatform(); 
            }

            }

        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Invoke("FallDown", 0.5f);
        }
            
                
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2f);
    }

    public void SpawnPlatform()
    {
        int rand = Random.Range(0, 20);

        if (rand == 9)
        {
            Vector3[] nextPoses = new Vector3[2];
            nextPoses[0] = new Vector3(0, 0, size*2);
            nextPoses[1] = new Vector3(size*2, 0, 0);
            Vector3 nextPos = currentPos + nextPoses[(Random.Range(0, 2))];
            GameObject nextSpawnedPlatform = Instantiate(newPlatform, nextPos, Quaternion.identity);
            currentPos = nextSpawnedPlatform.transform.position;
        }
        else  
            {

            Vector3[] nextPoses = new Vector3[2];
            nextPoses[0] = new Vector3(0, 0, size);
            nextPoses[1] = new Vector3(size, 0, 0);
            Vector3 nextPos = currentPos + nextPoses[(Random.Range(0, 2))];
            GameObject nextSpawnedPlatform = Instantiate(newPlatform, nextPos, Quaternion.identity);
            currentPos = nextSpawnedPlatform.transform.position;
        }





        //intancePlatform.GetComponent<Transform>().position += new Vector3(0, 1, 0);
    }

    

}
