using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowvel : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel;
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
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.layer != 6)
            if(GameObject.FindWithTag("Player").GetComponent<Movement>().bowexp == true)
            {
                Instantiate(explosion, transform.position, Quaternion.identity);
                GameObject.FindWithTag("Player").GetComponent<ManaManager>().mana -= GameObject.FindWithTag("Player").GetComponent<ManaManager>().bowc;
            }
            Destroy(gameObject);

    }
}
