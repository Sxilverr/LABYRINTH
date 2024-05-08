using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjBeh : MonoBehaviour
{
    public Rigidbody2D rb;
    public float vel;
    public float tick;
    public float damage;
    public float upvel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * vel + new Vector3 (0, upvel, 0)* -1;
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerDamage>().damage = damage;
        }
        if (collision.gameObject.tag != "Enemy")
            Destroy(gameObject);

    }
}
