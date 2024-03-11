using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.D)){
            transform.position += new Vector3(speed/2500f,0,0);
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position -= new Vector3(speed/2500f,0,0);
        }
    }
}
