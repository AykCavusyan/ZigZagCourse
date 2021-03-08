using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TriggerScript : MonoBehaviour
{

    [SerializeField] GameObject newPlatform;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            SpawnPlatform();
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
        Destroy(transform.parent.gameObject, 2f);
    }

    void SpawnPlatform()
    {
        
        
        Vector3[] nextPoses = new Vector3[2];
        nextPoses[0] = new Vector3(0, -5, 2);
        nextPoses[1] = new Vector3(2, -5, 0);
        Vector3 nextPos = transform.position + nextPoses[(Random.Range(0,2))];
        Instantiate(newPlatform, nextPos, Quaternion.identity);

    }

}
