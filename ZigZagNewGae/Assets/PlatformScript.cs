using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    Vector3 distanceToLerp = new Vector3(0, +5f, 0);

    int framesToLerp;


    // Start is called before the first frame update
    void Start()
    {
        

        
    }

    // Update is called once per frame
    void Update()
    {
        UpMove();
    }

    void UpMove()
    {
        Vector3 nextPos = transform.position;
        Vector3 nextPosLerped = nextPos + distanceToLerp;




        transform.position = Vector3.Lerp(nextPos, nextPosLerped, 20f);
    }
}
