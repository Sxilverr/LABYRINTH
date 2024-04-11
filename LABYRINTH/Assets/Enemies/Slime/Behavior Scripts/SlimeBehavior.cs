using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehavior : MonoBehaviour
{
    public float jumpheight;
    public float jumpwait;
    public float jt;
    public float jumpvelx;
    public Animator anim;
    public Rigidbody2D rb;
    public float dtg;
    public float dtx;
    public float dto;
    public GameObject player;
    public GameObject Death;
    public float ParticleAmount;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        dtg = GetComponent<Collider2D>().bounds.extents.y;
        dtx = GetComponent<Collider2D>().bounds.extents.x;
        dto = -GetComponent<Collider2D>().offset.y;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Delete"))
        {
            int i = 0;
            while (i < ParticleAmount)
            {
                Instantiate(Death, transform.position, Quaternion.identity);
                i++;
            }
            Destroy(gameObject);
        }
            dtg = GetComponent<Collider2D>().bounds.extents.y;
            dto = -GetComponent<Collider2D>().offset.y;
            dtx = GetComponent<Collider2D>().bounds.extents.x;
            if (jumpenabled() == true)
            {
                anim.SetBool("IsUp", false);
                if (jt > 0)
                {
                    jt -= 1;
                }
                else if(anim.GetBool("IsDead") == false)
                {
                    if (player.transform.position.x - transform.position.x > 0)
                    {
                        rb.AddForce(new Vector2(jumpvelx, jumpheight));
                    }
                    else
                    {
                        rb.AddForce(new Vector2(-jumpvelx, jumpheight));
                    }
                    jt = jumpwait;
                }
            }
            else
            {
                anim.SetBool("IsUp", true);
                //jt = jumpwait;
            }
        if (rb.velocity.y < 0)
        {
            anim.SetBool("NegVel", true);
        }
        else
        {
            anim.SetBool("NegVel", false);
        }
    }
    public bool jumpenabled()
    {
        if (Physics2D.Raycast(transform.position, -Vector3.up, dtg + transform.localScale.y * dto + dtg + 0.05f) == true)
            return Physics2D.Raycast(transform.position, -Vector3.up, dtg + transform.localScale.y * dto + dtg + 0.05f);
        if (Physics2D.Raycast(new Vector3(transform.position.x - dtx + 0.05f, transform.position.y, transform.position.z), -Vector3.up, dtg + transform.localScale.y * dto + dtg + 0.05f))
            return Physics2D.Raycast(new Vector3(transform.position.x - dtx + 0.05f, transform.position.y, transform.position.z), -Vector3.up, dtg + transform.localScale.y * dto + dtg + 0.05f);
        if (Physics2D.Raycast(new Vector3(transform.position.x + dtx - 0.05f, transform.position.y, transform.position.z), -Vector3.up, dtg + transform.localScale.y * dto + dtg + 0.05f))
            return Physics2D.Raycast(new Vector3(transform.position.x + dtx - 0.05f, transform.position.y, transform.position.z), -Vector3.up, dtg + transform.localScale.y * dto + dtg + 0.05f);
        return false;
    }
}
