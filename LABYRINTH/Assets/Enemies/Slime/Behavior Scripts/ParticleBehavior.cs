using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehavior : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public float rotspeed;
    public float particletimer;
    public float normaltimer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.Normalize(new Vector3(Random.Range(-100, 100), Random.Range(-10, 100), 0))*Random.Range(0.5f*speed, 1.5f*speed);
        rb.AddTorque(Random.Range(-100, 100)*rotspeed);
        particletimer = normaltimer * Random.Range(50, 150) / 100;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        particletimer -= 0.02f;
        if (particletimer <= 1)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, particletimer);
        }
        if (particletimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
