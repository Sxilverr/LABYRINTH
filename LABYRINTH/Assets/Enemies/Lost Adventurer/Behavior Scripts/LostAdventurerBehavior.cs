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
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        truedist = Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);
        if (truedist <= followdist)
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
        if (left == true)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}
