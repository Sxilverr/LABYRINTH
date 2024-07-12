using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vortex : MonoBehaviour
{
    public float kill;
    public GameObject[] enemies;
    public Rigidbody2D rb;
    public float range;
    public float accel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        kill += 1;
        if(kill >= 150)
        {
            Destroy(gameObject);
        }
        foreach(GameObject i in enemies){
            if (Vector3.Distance(transform.position, i.transform.position) < range)
            {
                rb = i.GetComponent<Rigidbody2D>();
                Vector2 bbbbbb = accel * Vector3.Normalize(transform.position - i.transform.position);
                rb.velocity = bbbbbb;
            }
        }
    }
}
