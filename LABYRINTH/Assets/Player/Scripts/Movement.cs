using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public static float speed;
    public bool doublejump;
    public float dtg;
    public Rigidbody2D rb;
    public static float jump;
    public float ff;
    public Animator anim;
    public bool left = false;
    public string animst;
    public float cd;
    public Sprite asp;
    public PolygonCollider2D rupbacks;
    public PolygonCollider2D rups;
    public PolygonCollider2D rupfwds;
    public PolygonCollider2D rfwds;
    public PolygonCollider2D lupbacks;
    public PolygonCollider2D lups;
    public PolygonCollider2D lupfwds;
    public PolygonCollider2D lfwds;
    public PolygonCollider2D rj1;
    public PolygonCollider2D rj2;
    public PolygonCollider2D rj3;
    public PolygonCollider2D lj1;
    public PolygonCollider2D lj2;
    public PolygonCollider2D lj3;
    public PolygonCollider2D ruj1;
    public PolygonCollider2D ruj2;
    public PolygonCollider2D ruj3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dtg = GetComponent<Collider2D>().bounds.extents.y;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (animst != "FwdSwing" && animst != "Jab" && cd <= 0 && animst != "UpJab")
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(speed / 2500f, 0, 0);
                if (!Input.GetKey(KeyCode.LeftArrow))
                    left = false;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(speed / 2500f, 0, 0);
                if (!Input.GetKey(KeyCode.RightArrow))
                    left = true;
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -ff, 0));
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool("Running", true);
            }
            else
            {
                anim.SetBool("Running", false);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                left = true;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                left = false;
            }
            if (Input.GetKey(KeyCode.A) == true && Input.GetKey(KeyCode.RightArrow) == true)
            {
                anim.SetBool("RevDir", true);
            }
            else if ((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftArrow)))
            {
                anim.SetBool("RevDir", true);
            }
            else
            {
                anim.SetBool("RevDir", false);
            }
        } else
        if (animst == "FwdSwing")
        {
            cd = 5;
        }
        if (animst == "UpJab")
        {
            cd = 5;
        }
        if (animst == "Jab")
        {
            if (left == true)
                transform.position -= new Vector3(speed / 2500f, 0, 0);
            if (left == false)
                transform.position += new Vector3(speed / 2500f, 0, 0);
            cd = 8;
        }
        cd -= 1;
        animst = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
    }
    void Update()
    {
        asp = GetComponent<SpriteRenderer>().sprite;
        if (animst != "FwdSwing" && animst != "Jab" && cd <= 0)
        {
            if (Input.GetKeyDown(KeyCode.E) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
            {
                Debug.Log("ATK");
                anim.SetBool("Attack", true);
            }
            if (Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            {
                Debug.Log("ATK");
                anim.SetBool("Jab", true);
            }
            if (Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.UpArrow)))
            {
                Debug.Log("ATK");
                anim.SetBool("UpJab", true);
            }
        }
        if (!Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Jab", false);
            anim.SetBool("UpJab", false);
        }
        if(left == true)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        ff = jump / 2;
        if (jumpenabled() && Input.GetKeyDown(KeyCode.Space) && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab")
        {
            rb.AddForce(new Vector3(0, 4*jump, 0));
        }
        if (!jumpenabled() && Input.GetKeyDown(KeyCode.Space) && doublejump == true && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab")
        {
            rb.velocity=(new Vector3(rb.velocity.x, jump/10f, 0));
            doublejump = false;
        }
        if (jumpenabled())
        {
            doublejump = true;
            anim.SetBool("IsUp", false);
        } else
        {
            anim.SetBool("IsUp", true);
            if(rb.velocity.y >= 1)
            {
                anim.SetBool("NegVel", false);
            } else
            {
                anim.SetBool("NegVel", true);
            }
        }
        if (left == false)
        {
            if (asp.name == "SwordSwingUpRt" && animst == "FwdSwing")
            {
                rupfwds.enabled = true;
            }
            else
            {
                rupfwds.enabled = false;
            }
            if (asp.name == "SwordSwingUp" && animst == "FwdSwing")
            {
                rups.enabled = true;
            }
            else
            {
                rups.enabled = false;
            }
            if (asp.name == "SwordSwingUpRtBack" && animst == "FwdSwing")
            {
                rupbacks.enabled = true;
            }
            else
            {
                rupbacks.enabled = false;
            }
            if (asp.name == "SwordSwingRt" && animst == "FwdSwing")
            {
                rfwds.enabled = true;
            }
            else
            {
                rfwds.enabled = false;
            }
            if (asp.name == "SwordSwingRt" && animst == "Jab")
            {
                rj1.enabled = true;
            }
            else
            {
                rj1.enabled = false;
            }
            if (asp.name == "SwordJabRt" && animst == "Jab")
            {
                rj2.enabled = true;
            }
            else
            {
                rj2.enabled = false;
            }
            if (asp.name == "SwordJabRt2" && animst == "Jab")
            {
                rj3.enabled = true;
            }
            else
            {
                rj3.enabled = false;
            }
            if (asp.name == "SwordSwingUp" && animst == "UpJab")
            {
                ruj1.enabled = true;
            }
            else
            {
                ruj1.enabled = false;
            }
            if (asp.name == "SwordJabUp" && animst == "UpJab")
            {
                ruj2.enabled = true;
            }
            else
            {
                ruj2.enabled = false;
            }
            if (asp.name == "SwordJabUp2" && animst == "UpJab")
            {
                ruj3.enabled = true;
            }
            else
            {
                ruj3.enabled = false;
            }
        } else
        {
            if (asp.name == "SwordSwingUpRt" && animst == "FwdSwing")
            {
                lupfwds.enabled = true;
            }
            else
            {
                lupfwds.enabled = false;
            }
            if (asp.name == "SwordSwingUp" && animst == "FwdSwing")
            {
                lups.enabled = true;
            }
            else
            {
                lups.enabled = false;
            }
            if (asp.name == "SwordSwingUpRtBack" && animst == "FwdSwing")
            {
                lupbacks.enabled = true;
            }
            else
            {
                lupbacks.enabled = false;
            }
            if (asp.name == "SwordSwingRt" && animst == "FwdSwing")
            {
                lfwds.enabled = true;
            }
            else
            {
                lfwds.enabled = false;
            }
            if (asp.name == "SwordSwingRt" && animst == "Jab")
            {
                lj1.enabled = true;
            }
            else
            {
                lj1.enabled = false;
            }
            if (asp.name == "SwordJabRt" && animst == "Jab")
            {
                lj2.enabled = true;
            }
            else
            {
                lj2.enabled = false;
            }
            if (asp.name == "SwordJabRt2" && animst == "Jab")
            {
                lj3.enabled = true;
            }
            else
            {
                lj3.enabled = false;
            }
            if (asp.name == "SwordSwingUp" && animst == "UpJab")
            {
                ruj1.enabled = true;
            }
            else
            {
                ruj1.enabled = false;
            }
            if (asp.name == "SwordJabUp" && animst == "UpJab")
            {
                ruj2.enabled = true;
            }
            else
            {
                ruj2.enabled = false;
            }
            if (asp.name == "SwordJabUp2" && animst == "UpJab")
            {
                ruj3.enabled = true;
            }
            else
            {
                ruj3.enabled = false;
            }
        }
    }
    public bool jumpenabled()
    {
        if(Physics2D.Raycast(transform.position, -Vector3.up, dtg + 0.05f)==true)
            return Physics2D.Raycast(transform.position, -Vector3.up, dtg + 0.05f);
        if (Physics2D.Raycast(new Vector3(transform.position.x - 0.3125f, transform.position.y, transform.position.z), -Vector3.up, dtg + 0.05f))
            return Physics2D.Raycast(new Vector3(transform.position.x - 0.3125f, transform.position.y, transform.position.z), -Vector3.up, dtg + 0.05f);
        if (Physics2D.Raycast(new Vector3(transform.position.x + 0.3125f, transform.position.y, transform.position.z), -Vector3.up, dtg + 0.05f))
            return Physics2D.Raycast(new Vector3(transform.position.x + 0.3125f, transform.position.y, transform.position.z), -Vector3.up, dtg + 0.05f);
        return false;
    }
}
