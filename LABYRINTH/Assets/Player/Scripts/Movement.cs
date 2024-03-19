using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float speed;
    public bool doublejump;
    public float dtg;
    public Rigidbody2D rb;
    public static float jump;
    public float ff;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dtg = GetComponent<Collider2D>().bounds.extents.y;
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
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(new Vector3(0, -ff, 0));
        }
    }
    void Update()
    {
        ff = jump / 2;
        if (jumpenabled() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 4*jump, 0));
        }
        if (!jumpenabled() && Input.GetKeyDown(KeyCode.Space) && doublejump == true)
        {
            rb.velocity=(new Vector3(rb.velocity.x, jump/10f, 0));
            doublejump = false;
        }
        if (jumpenabled())
        {
            doublejump = true;
        }
    }
    public bool jumpenabled()
    {
        if(Physics2D.Raycast(transform.position, -Vector3.up, dtg + 0.05f)==true)
            return Physics2D.Raycast(transform.position, -Vector3.up, dtg + 0.05f);
        if (Physics2D.Raycast(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), -Vector3.up, dtg + 0.05f))
            return Physics2D.Raycast(new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), -Vector3.up, dtg + 0.05f);
        if (Physics2D.Raycast(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), -Vector3.up, dtg + 0.05f))
            return Physics2D.Raycast(new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), -Vector3.up, dtg + 0.05f);
        return false;
    }
}