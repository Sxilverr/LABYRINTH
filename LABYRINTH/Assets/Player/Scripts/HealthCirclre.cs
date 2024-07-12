using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCirclre : MonoBehaviour
{
    public float kil;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (kil >= 20)
        {
            Destroy(gameObject);
        }
        kil += 1;
        
    }
}
