using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel;
    public float accel;
    public float tick;
    public GameObject explosion;
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
        Vector2 bhlo = transform.right * accel;
        rb.velocity = rb.velocity + bhlo;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player" && collision.gameObject.layer != 6)
        {
            GameObject pop = Instantiate(explosion, transform.position, Quaternion.identity);
            if(transform.name == "Small Fireball(Clone)")
            {
                pop.transform.position += new Vector3(0.25f, 0, 0);
            } else
            {
                pop.transform.position += new Vector3(0.75f, 0, 0);
            }
            Destroy(gameObject);
        }
    }
}
