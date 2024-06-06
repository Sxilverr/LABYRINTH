using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordProjVel : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel;
    public float tick;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.Normalize(transform.right+transform.up) * vel;
        //Debug.Log((1 - (transform.rotation.z + 0.5f)));
    }

    // Update is called once per frame
    void Update()
    {

    }
}