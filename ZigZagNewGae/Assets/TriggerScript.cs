﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
