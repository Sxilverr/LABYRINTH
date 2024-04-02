using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagetest : MonoBehaviour
{
    public float damage;
    public float damagecd;
    public float damagediff;
    public float instdiff;
    public bool colliding;
    public float collct;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (colliding == false)
            damagecd -= 1;
        if(damage != instdiff)
        {
            damagecd = 20;
            instdiff = damage;
        }
        if (damage != damagediff && colliding == false)
        {
            Debug.Log(damage-damagediff);
            damagediff = damage;
        }
        if(collct == 0)
        {
            colliding = false;
        }
        else
        {
            colliding = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.sharedMaterial != null)
            collct -= 1;
    }
    private void OnTriggerStay2D(Collider2D hitbox)
    {
        if (hitbox.sharedMaterial != null)
        {
            damage += (1 / (1 - hitbox.sharedMaterial.friction) - 1) * GameObject.FindWithTag("Player").GetComponent<StatManager>().strength;
            GetComponent<Rigidbody2D>().AddForce(18 * Vector3.Normalize(transform.position - GameObject.FindWithTag("Player").transform.position) * (1 / (1 - hitbox.sharedMaterial.bounciness) - 1));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.sharedMaterial != null)
        {
            collct += 1;
        }
    }
}
