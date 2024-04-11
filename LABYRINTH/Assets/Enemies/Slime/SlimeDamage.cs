using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeDamage : MonoBehaviour
{
    public float damage;
    public float damagecd;
    public float damagediff;
    public float instdiff;
    public bool colliding;
    public float collct;
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health -= damage;
        damage = 0;
        if (health <= 0)
        {
            GetComponent<Animator>().SetBool("IsDead", true);
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
