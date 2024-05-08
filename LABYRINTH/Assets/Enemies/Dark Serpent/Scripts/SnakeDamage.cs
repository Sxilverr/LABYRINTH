using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeDamage : MonoBehaviour
{
    public float damage;
    public float damagecd;
    public float damagediff;
    public float instdiff;
    public bool colliding;
    public float collct;
    public float health;
    public GameObject OB;
    public GameObject Health;
    public float OBS;
    public float maxhealth;
    // Start is called before the first frame update
    void Start()
    {
        OBS = OB.transform.localScale.x;
        health = maxhealth;
        Health.transform.localScale = new Vector3(Health.transform.localScale.x, 0.1f / transform.localScale.y, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == maxhealth || health <= 0)
        {
            OB.SetActive(false);
            Health.SetActive(false);
        }
        else
        {
            OB.SetActive(true);
            Health.SetActive(true);
            OB.transform.localScale = new Vector3(health / maxhealth * OBS, 0.1f / transform.localScale.y, 1);
            OB.transform.localPosition = new Vector3((1 - health / maxhealth) * OBS / 2, 0.3f, 0);
        }
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
        if (hitbox.sharedMaterial != null && hitbox.isTrigger == true)
        {
            damage += (1 / (1 - hitbox.sharedMaterial.friction) - 1) * GameObject.FindWithTag("Player").GetComponent<StatManager>().strength;
            GetComponent<Rigidbody2D>().AddForce(100 * Vector3.Normalize(transform.position - GameObject.FindWithTag("Player").transform.position) * (1 / (1 - hitbox.sharedMaterial.bounciness) - 1));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.sharedMaterial != null)
        {
            collct += 1;
        }
    }
}
