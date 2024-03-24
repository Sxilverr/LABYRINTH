using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance((transform.position + new Vector3(0, -1f, 0)), Player.transform.position) >= 1)
        {
            Vector2 v2 = (Player.transform.position - (transform.position + new Vector3(0, -1f, 0)));
            Vector3 v3 = v2;
            transform.position += v3 /20f;
        }
    }
}
