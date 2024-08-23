using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earrowvel : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel;
    public float tick;
    public float damage;
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
        if (collision.gameObject.tag == "Player" && collision.gameObject.layer != 6)
        {
            if(collision.sharedMaterial == null)
                collision.gameObject.GetComponent<PlayerDamage>().damage = damage;
        }
        if (collision.gameObject.tag != "Enemy" && collision.gameObject.layer != 6)
            Destroy(gameObject);
        
    }
}
