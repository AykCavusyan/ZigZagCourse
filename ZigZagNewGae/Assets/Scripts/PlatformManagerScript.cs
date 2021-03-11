using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManagerScript : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }

     void FixedUpdate()
    {
        
            if (transform.position.y < 0)
            {
                transform.Translate(0, 1f, 0);
            }
        
           
        
    }
}
