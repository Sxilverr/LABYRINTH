using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowvel : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel;
    public float tick;
    public GameObject explosion;
    public bool home;
    public GameObject enemy;
    public bool tp;
    public bool ghost;
    public bool freeze;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * vel;
        //Debug.Log((1 - (transform.rotation.z + 0.5f)));
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindWithTag("Enemy");
        if(home == true)
            rb.velocity = vel*(enemy.transform.position - transform.position);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && freeze == true)
        {
            collision.gameObject.GetComponent<FreezeManager>().freezeTime = 25;
        }
        if (collision.gameObject.tag != "Player" && collision.gameObject.layer != 6) {
            if (GameObject.FindWithTag("Player").GetComponent<Movement>().bowexp == true && GameObject.FindWithTag("Player").GetComponent<ManaManager>().mana >= GameObject.FindWithTag("Player").GetComponent<ManaManager>().bowc)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                GameObject.FindWithTag("Player").GetComponent<ManaManager>().mana -= GameObject.FindWithTag("Player").GetComponent<ManaManager>().bowc;
            }
            if (tp == true)
            {
                GameObject.FindWithTag("Player").transform.position = transform.position - new Vector3(rb.velocity.x / vel, rb.velocity.y / vel, 0);
            }
            if (ghost == false || collision.gameObject.tag == "Enemy")
                Destroy(gameObject);
        }
            

    }
}
