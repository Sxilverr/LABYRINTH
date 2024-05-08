using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snakeboxes : MonoBehaviour
{
    public GameObject Parent;
    public Animator anim;
    public string names;
    public bool left;
    public float attackdmg;
    public BoxCollider2D r1;
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
        left = Parent.GetComponent<SnakeBehavior>().left;
        names = Parent.GetComponent<SpriteRenderer>().sprite.name;
        if(left == true)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if(names == "OpenMouth" || names == "OpenMouthRun")
        {
            r1.enabled = true;
        } else
        {
            r1.enabled = false;
        }
    }
    private void OnTriggerStay2D(Collider2D hitbox)
    {
        hitbox.gameObject.GetComponent<PlayerDamage>().damage += attackdmg;
        hitbox.gameObject.GetComponent<Rigidbody2D>().AddForce(-k * Vector3.Normalize(transform.position - hitbox.gameObject.transform.position));
    }
}
