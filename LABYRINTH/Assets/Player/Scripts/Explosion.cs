using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Animator anim;
    public string animst;
    public string spr;
    public BoxCollider2D l1;
    public BoxCollider2D l2;
    public BoxCollider2D l3;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animst = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        spr = GetComponent<SpriteRenderer>().sprite.name;
        if(animst == "Gonestate" || animst == "BGonestate") {
            Destroy(gameObject);
        }
        if(spr == "Pop1" || spr == "Explosion1")
        {
            l1.enabled = true;
        } else
        {
            l1.enabled = false;
        }
        if (spr == "Pop2" || spr == "Explosion2")
        {
            l2.enabled = true;
        }
        else
        {
            l2.enabled = false;
        }
        if (spr == "Pop3" || spr == "Explosion2")
        {
            l3.enabled = true;
        }
        else
        {
            l3.enabled = false;
        }
    }
}
