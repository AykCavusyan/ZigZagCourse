using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{



    float posInitial;

    // Start is called before the first frame update


    void Start()
    {

        posInitial = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {
        

        if (posInitial <= 0)
        {
            posInitial += 1f;
        }
    }

    
}
