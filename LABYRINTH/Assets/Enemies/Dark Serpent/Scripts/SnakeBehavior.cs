using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBehavior : MonoBehaviour
{
    public float speed;
    public float followdist;
    public Animator anim;
    public float truedist;
    public bool left;
    public float mindist;
    public float attackstate;
    public float bowdist;
    public GameObject arrow;
    public float minattackdist;
    public GameObject earrow;
    public float arrowdamage;
    public GameObject DeathParticle;
    public float particleamt;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("DeathState") == true)
        {
            Destroy(gameObject);
        }
        if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Death")
        {
            int i = 0;
            while (i < particleamt)
            {
                Instantiate(DeathParticle, transform.position, Quaternion.identity);
                i++;
            }
            attackstate = 7;
        }
        truedist = Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);
        if(attackstate == 0 && truedist <= followdist + 5) {
            anim.SetBool("Jab", false);
            if (truedist >= bowdist && truedist <= followdist && anim.GetBool("Bowing") == false)
            {
                if (transform.position.x - GameObject.FindWithTag("Player").transform.position.x < 0)
                {
                    left = false;
                    transform.position += new Vector3(speed / 50, 0, 0);
                }
                else
                {
                    left = true;
                    transform.position -= new Vector3(speed / 50, 0, 0);
                }
                anim.SetBool("Running", true);
                anim.SetBool("Bowing", false);
            }
            else
            {
                anim.SetBool("Running", false);
                anim.SetBool("Bowing", true);
                if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Shooting") {
                    anim.SetBool("Bowing", false);
                    if (left == false)
                    {
                        earrow = Instantiate(arrow, transform.position + new Vector3(1f, -0.0625f, 0), Quaternion.identity);
                    } else
                    {
                        earrow = Instantiate(arrow, transform.position + new Vector3(-1f, -0.25f, 0), Quaternion.Euler(0, 0, 180));
                    }
                    earrow.GetComponent<ProjBeh>().damage = arrowdamage;
                    if (truedist <= minattackdist)
                    {
                        attackstate = 1;
                        Debug.Log("Changed");
                    }
                }
            }
        }
        if (attackstate == 1)
        {
            anim.SetBool("Bowing", false);
            if (truedist <= followdist && truedist > mindist && anim.GetBool("Jab") == false)
            {
                if (transform.position.x - GameObject.FindWithTag("Player").transform.position.x < 0)
                {
                    left = false;
                    transform.position += new Vector3(speed / 50, 0, 0);
                }
                else
                {
                    left = true;
                    transform.position -= new Vector3(speed / 50, 0, 0);
                }
                anim.SetBool("Running", true);
                anim.SetBool("Jab", false);
                if (truedist >= minattackdist)
                {
                    attackstate = 0;
                }
            }
            else
            {
                anim.SetBool("Running", false);
                if (transform.position.y - GameObject.FindWithTag("Player").transform.position.y < 1)
                {
                    anim.SetBool("Jab", true);
                    if (left == true)
                    {
                        transform.position -= new Vector3(speed / 40, 0, 0);
                    }
                    else
                    {
                        transform.position += new Vector3(speed / 40, 0, 0);
                    }
                    if (anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Jabend")
                    {
                        anim.SetBool("Jab", false);
                    }
                } else
                {
                    //neutral swing to hit above
                }
            }
        }
        if (left == true)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
