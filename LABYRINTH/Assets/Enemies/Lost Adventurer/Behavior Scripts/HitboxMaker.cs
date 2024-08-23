using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxMaker : MonoBehaviour
{
    public GameObject Parent;
    public Animator anim;
    public string names;
    public bool left;
    public float attackdmg;
    public BoxCollider2D r1;
    public BoxCollider2D r2;
    public BoxCollider2D r3;
    public BoxCollider2D l1;
    public BoxCollider2D l2;
    public BoxCollider2D l3;
    public float k;
    // Start is called before the first frame update
    void Start()
    {
        Parent = gameObject.transform.parent.gameObject;
        anim = Parent.GetComponent<Animator>();
        names = Parent.GetComponent<SpriteRenderer>().sprite.name;
    }

    // Update is called once per frame
    void Update()
    {
        left = Parent.GetComponent<LostAdventurerBehavior>().left;
        names = Parent.GetComponent<SpriteRenderer>().sprite.name;
        if (names == "Jab1" && left == true)
        {
            l1.enabled = true;
        } else
        {
            l1.enabled = false;
        }
        if (names == "Jab2" && left == true)
        {
            l2.enabled = true;
        }
        else
        {
            l2.enabled = false;
        }
        if (names == "Jab3" && left == true)
        {
            l3.enabled = true;
        }
        else
        {
            l3.enabled = false;
        }
        if (names == "Jab1" && left == false)
        {
            r1.enabled = true;
        }
        else
        {
            r1.enabled = false;
        }
        if (names == "Jab2" && left == false)
        {
            r2.enabled = true;
        }
        else
        {
            r2.enabled = false;
        }
        if (names == "Jab3" && left == false)
        {
            r3.enabled = true;
        }
        else
        {
            r3.enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D hitbox)
    {
        if (hitbox.sharedMaterial == null)
        {
            hitbox.gameObject.GetComponent<PlayerDamage>().damage += attackdmg;
        }
        else
        {
            Parent.GetComponent<Rigidbody2D>().AddForce(k * Vector3.Normalize(transform.position - hitbox.gameObject.transform.position));
        }
            
        hitbox.gameObject.GetComponent<Rigidbody2D>().AddForce(-k*Vector3.Normalize(transform.position - hitbox.gameObject.transform.position));
    }
}
