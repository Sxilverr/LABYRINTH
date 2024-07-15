using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daggervel : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel;
    public float tick;
    public float rot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * vel;
        //Debug.Log((1 - (transform.rotation.z + 0.5f)));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, rot);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.layer != 6)
        {
            Destroy(gameObject);
        }
            

    }
}
