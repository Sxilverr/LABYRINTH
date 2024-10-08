using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiter : MonoBehaviour
{
    public float k;
    public float damage;
    public BoxCollider2D hitbox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && GameObject.FindWithTag("Player").GetComponent<Movement>().jumpenabled() == true && (GameObject.FindWithTag("Player").GetComponent<ManaManager>().shorbit == true || GameObject.FindWithTag("Player").GetComponent<ManaManager>().orbitpummel == true))
        {
            hitbox.enabled = true;
        } else
        {
            hitbox.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            hit.gameObject.GetComponent<Rigidbody2D>().velocity = (-k*(GameObject.FindWithTag("Player").transform.position - hit.gameObject.transform.position));
            if(GameObject.FindWithTag("Player").GetComponent<ManaManager>().orbitpummel == true)
            {
                if(hit.GetComponent<SlimeDamage>() != null)
                {
                    hit.GetComponent<SlimeDamage>().damage += damage * GameObject.FindWithTag("Player").GetComponent<StatManager>().strength;
                }
                if (hit.GetComponent<LADamage>() != null)
                {
                    hit.GetComponent<LADamage>().damage += damage * GameObject.FindWithTag("Player").GetComponent<StatManager>().strength;
                }
                if (hit.GetComponent<SnakeDamage>() != null)
                {
                    hit.GetComponent<SnakeDamage>().damage += damage * GameObject.FindWithTag("Player").GetComponent<StatManager>().strength;
                }
                if (hit.GetComponent<SpawnerDamage>() != null)
                {
                    hit.GetComponent<SpawnerDamage>().damage += damage * GameObject.FindWithTag("Player").GetComponent<StatManager>().strength;
                }
            }
        }
        
    }
}
