using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostAdventurerBehavior : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        truedist = Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);
        if(attackstate == 0) {
            if(truedist >= bowdist && truedist <= followdist && anim.GetBool("Bowing") == false)
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
                if(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name == "BowFullState") {
                    anim.SetBool("Bowing", false);
                    if(left == false)
                    {
                        Instantiate(arrow, transform.position + new Vector3(0.5f, -0.0625f, 0), Quaternion.identity);
                    } else
                    {
                        Instantiate(arrow, transform.position + new Vector3(-0.5f, -0.25f, 0), Quaternion.Euler(0, 0, 180));
                    }
                    attackstate = 1;
                }
            }
        }
        if (attackstate == 1)
        {
            anim.SetBool("Bowing", false);
            if (truedist <= followdist && truedist > mindist)
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
            }
            else
            {
                anim.SetBool("Running", false);
            }
            if (truedist <= followdist + 5)
            {
                if (transform.position.x - GameObject.FindWithTag("Player").transform.position.x < 0)
                {
                    left = false;
                }
                else
                {
                    left = true;
                }
            }

        }
        if (truedist <= followdist + 5)
        {
            if (transform.position.x - GameObject.FindWithTag("Player").transform.position.x < 0)
            {
                left = false;
            }
            else
            {
                left = true;
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
