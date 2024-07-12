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
    public PolygonCollider2D rdj1;
    public PolygonCollider2D rdj2;
    public PolygonCollider2D rdj3;
    public PolygonCollider2D rdj4;
    public PolygonCollider2D ldj1;
    public PolygonCollider2D ldj2;
    public PolygonCollider2D ldj3;
    public PolygonCollider2D ldj4;
    public PolygonCollider2D daoir;
    public PolygonCollider2D ac1;
    public PolygonCollider2D ac2;
    public PolygonCollider2D ac3;
    public PolygonCollider2D ac4;
    public PolygonCollider2D ac5;
    public PolygonCollider2D ac6;
    public PolygonCollider2D ac7;
    public PolygonCollider2D ac8;
    public PolygonCollider2D sr;
    public PolygonCollider2D sl;
    public GameObject arrow;
    public float vel;
    public LayerMask particles;
    public bool swordproj;
 
    public GameObject SP;
    public float swingcost;
    public bool bowexp;
    public bool tripleshot;

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
        dtg = GetComponent<Collider2D>().bounds.extents.y;
        if (animst == "DownAir" || animst == "Nair" || animst == "Fair" || animst == "UpAir" || (animst == "MagicCast" && jumpenabled() == false))
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += new Vector3(speed / 2500f, 0, 0);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= new Vector3(speed / 2500f, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                rb.AddForce(new Vector3(0, -ff, 0));
            }
        }
        if (animst != "FwdSwing" && animst != "Jab" && cd <= 0 && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
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
        if (animst == "DownSlash")
        {
            cd = 8;
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
        if (Input.GetKey(KeyCode.LeftShift) && jumpenabled() == true)
        {
            anim.SetBool("Shielding", true);
            if (left == false)
            {
                sr.enabled = true;
            }
            else
            {
                sl.enabled = true;
            }
        }
        else
        {
            anim.SetBool("Shielding", false);
            sr.enabled = false;
            sl.enabled = false;
        }
        vel = Mathf.Abs(rb.velocity.y);
        daoir.sharedMaterial.friction = (0.95f * vel) / (1f * vel + 1)-0.1f;
        asp = GetComponent<SpriteRenderer>().sprite;
        if (animst != "FwdSwing" && animst != "Jab" && cd <= 0 && animst != "DownSlash" && animst != "UpJab" && animst != "Shidle" && animst != "Shrun" && animst != "ShackRun" && animst != "MagicCast")
        {
            if (Input.GetKeyDown(KeyCode.E) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
            {
                Debug.Log("ATK");
                anim.SetBool("Attack", true);
                anim.SetBool("Nair", true);
                if (GetComponent<ManaManager>().mana >= swingcost && swordproj == true && animst != "FwdSwing" && animst != "Jab" && cd <= 0 && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
                {
                    GetComponent<ManaManager>().mana -= swingcost;
                    if (left == true)
                    {
                        GameObject narrow = Instantiate(SP, transform.position, Quaternion.identity);
                        narrow.transform.Rotate(0, 0, 90);
                    }
                    else
                    {
                        Instantiate(SP, transform.position, Quaternion.identity);
                    }
                }
                
            }
            if (Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            {
                Debug.Log("ATK");
                anim.SetBool("Jab", true);
                anim.SetBool("Fair", true);
                if (GetComponent<ManaManager>().mana >= swingcost && swordproj == true && animst != "FwdSwing" && animst != "Jab" && cd <= 0 && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
                {
                    GetComponent<ManaManager>().mana -= swingcost;
                    if (left == true)
                    {
                        GameObject narrow = Instantiate(SP, transform.position, Quaternion.identity);
                        narrow.transform.Rotate(0, 0, 135);
                    }
                    else
                    {
                        GameObject narrow = Instantiate(SP, transform.position, Quaternion.identity);
                        narrow.transform.Rotate(0, 0, -45);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.UpArrow)))
            {
                Debug.Log("ATK");
                anim.SetBool("UpJab", true);
                anim.SetBool("Uair", true);
                if (GetComponent<ManaManager>().mana >= swingcost && swordproj == true && animst != "FwdSwing" && animst != "Jab" && cd <= 0 && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
                {
                    GetComponent<ManaManager>().mana -= swingcost;
                    GameObject narrow = Instantiate(SP, transform.position, Quaternion.identity);
                    narrow.transform.Rotate(0, 0, 45);
                }
            }
            if (Input.GetKeyDown(KeyCode.E) && (Input.GetKey(KeyCode.DownArrow)))
            {
                Debug.Log("ATK");
                anim.SetBool("DownSlash", true);
                anim.SetBool("Dair", true);
                if (GetComponent<ManaManager>().mana >= swingcost && swordproj == true && animst != "FwdSwing" && animst != "Jab" && cd <= 0 && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
                {
                  
                    if (jumpenabled() == true && GetComponent<ManaManager>().mana >= 2*swingcost)
                    {
                        GetComponent<ManaManager>().mana -= 2*swingcost;
                        GameObject narrow = Instantiate(SP, transform.position, Quaternion.identity);
                        narrow.transform.Rotate(0, 0, -45);
                        GameObject nearrow = Instantiate(SP, transform.position, Quaternion.identity);
                        nearrow.transform.Rotate(0, 0, 135);
                    }
                    else if (jumpenabled() == false)
                    {
                        GetComponent<ManaManager>().mana -= swingcost;
                        GameObject narrow = Instantiate(SP, transform.position, Quaternion.identity);
                        narrow.transform.Rotate(0, 0, -135);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Q) && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
            {
                anim.SetBool("BowF", true);
            }
            if (Input.GetKeyDown(KeyCode.Q) && (Input.GetKey(KeyCode.UpArrow)) && animst != "NBow" && animst != "NBowFull" && animst != "BowDraw" && animst != "BowFull" && animst != "FwdSwing" && animst != "Jab" && cd <= 0 && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "MagicCast")
            {
                if (left == true)
                {
                    left = false;
                    anim.SetBool("Nbow", true);
                } else
                {
                    left = true;
                    anim.SetBool("Nbow", true);
                }
            }
            if (Input.GetKeyDown(KeyCode.Q) && (Input.GetKey(KeyCode.DownArrow)) && animst != "NBow" && animst != "NBowFull" && animst != "BowDraw" && animst != "BowFull" && animst != "FwdSwing" && animst != "Jab" && cd <= 0 && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "MagicCast")
            {
                if (left == true)
                {
                    left = false;
                    anim.SetBool("BowF", true);
                }
                else
                {
                    left = true;
                    anim.SetBool("BowF", true);
                }
            }
            if (Input.GetKeyDown(KeyCode.Q) && !(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)))
            {
                anim.SetBool("Nbow", true);
            }
            if (!Input.GetKey(KeyCode.Q))
            {
                if (animst == "BowFull")
                {
                    if (anim.GetBool("BowF") == true)
                    {
                        if (left == false)
                        {
                            
                            Instantiate(arrow, transform.position + new Vector3(0.5f, -0.0625f, 0), Quaternion.identity);
                            if(tripleshot == true && GetComponent<ManaManager>().mana >= GetComponent<ManaManager>().tsc)
                            {
                                Instantiate(arrow, transform.position + new Vector3(0.5f, -0.0625f, 0), Quaternion.Euler(0, 0, 15));
                                Instantiate(arrow, transform.position + new Vector3(0.5f, -0.0625f, 0), Quaternion.Euler(0, 0, -15));

                                GetComponent<ManaManager>().mana -= GetComponent<ManaManager>().tsc;
                            }
                        } else
                        {
                            Instantiate(arrow, transform.position + new Vector3(-0.5f, -0.25f, 0), Quaternion.Euler(0, 0, 180));
                            if (tripleshot == true && GetComponent<ManaManager>().mana >= GetComponent<ManaManager>().tsc)
                            {
                                Instantiate(arrow, transform.position + new Vector3(-0.5f, -0.25f, 0), Quaternion.Euler(0, 0, 195));
                                Instantiate(arrow, transform.position + new Vector3(-0.5f, -0.25f, 0), Quaternion.Euler(0, 0, 165));
                                GetComponent<ManaManager>().mana -= GetComponent<ManaManager>().tsc;
                            }
                        }
                    }
                    anim.SetBool("BowF", false);
                }
                if (animst == "NBowFull")
                {
                    if (anim.GetBool("Nbow") == true)
                    {
                        if (left == false)
                        {
                            Instantiate(arrow, transform.position + new Vector3(0.4375f, .1875f, 0), Quaternion.Euler(0, 0, 45));
                            if (tripleshot == true && GetComponent<ManaManager>().mana >= GetComponent<ManaManager>().tsc)
                            {
                                Instantiate(arrow, transform.position + new Vector3(0.4375f, .1875f, 0), Quaternion.Euler(0, 0, 60));
                                Instantiate(arrow, transform.position + new Vector3(0.4375f, .1875f, 0), Quaternion.Euler(0, 0, 30));
                                GetComponent<ManaManager>().mana -= GetComponent<ManaManager>().tsc;
                            }
                        }
                        else
                        {
                            Instantiate(arrow, transform.position + new Vector3(-0.4375f, -0.0625f, 0), Quaternion.Euler(0, 0, 135));
                            if (tripleshot == true && GetComponent<ManaManager>().mana >= GetComponent<ManaManager>().tsc)
                            {
                                Instantiate(arrow, transform.position + new Vector3(-0.4375f, -0.0625f, 0), Quaternion.Euler(0, 0, 150));
                                Instantiate(arrow, transform.position + new Vector3(-0.4375f, -0.0625f, 0), Quaternion.Euler(0, 0, 120));
                                GetComponent<ManaManager>().mana -= GetComponent<ManaManager>().tsc;
                            }
                        }
                    }
                    anim.SetBool("Nbow", false);
                }
            }
            if(animst == "BowFull")
            {
                cd = 5;
            }
        }
        if (!Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("Attack", false);
            anim.SetBool("Jab", false);
            anim.SetBool("UpJab", false);
            anim.SetBool("DownSlash", false);
            anim.SetBool("Dair", false);
            anim.SetBool("Fair", false);
            anim.SetBool("Nair", false);
            anim.SetBool("Uair", false);
        }
        if(left == true)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        ff = jump / 2;
        if (jumpenabled() && Input.GetKeyDown(KeyCode.Space) && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && animst != "MagicCast")
        {
            rb.AddForce(new Vector3(0, 4*jump, 0));
        }
        if (!jumpenabled() && Input.GetKeyDown(KeyCode.Space) && doublejump == true && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && animst != "MagicCast")
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
            if (asp.name == "SwordSwingRt" && animst == "DownSlash")
            {
                rdj1.enabled = true;
            }
            else
            {
                rdj1.enabled = false;
            }
            if (asp.name == "SwordJabRt" && animst == "DownSlash")
            {
                rdj2.enabled = true;
            }
            else
            {
                rdj2.enabled = false;
            }
            if (asp.name == "SwordSwingLt" && animst == "DownSlash")
            {
                rdj3.enabled = true;
            }
            else
            {
                rdj3.enabled = false;
            }
            if (asp.name == "SwordJabLt" && animst == "DownSlash")
            {
                rdj4.enabled = true;
            }
            else
            {
                rdj4.enabled = false;
            }
            if (asp.name == "UA")
            {
                ac1.enabled = true;
            }
            else
            {
                ac1.enabled = false;
            }
            if (asp.name == "URA")
            {
                ac2.enabled = true;
            }
            else
            {
                ac2.enabled = false;
            }
            if (asp.name == "RA")
            {
                ac3.enabled = true;
            }
            else
            {
                ac3.enabled = false;
            }
            if (asp.name == "DRA")
            {
                ac4.enabled = true;
            }
            else
            {
                ac4.enabled = false;
            }
            if (asp.name == "DownAir" && animst != "DownAir")
            {
                ac5.enabled = true;
            }
            else
            {
                ac5.enabled = false;
            }
            if (asp.name == "ULA")
            {
                ac8.enabled = true;
            }
            else
            {
                ac8.enabled = false;
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
            if (asp.name == "SwordSwingRt" && animst == "DownSlash")
            {
                ldj1.enabled = true;
            }
            else
            {
                ldj1.enabled = false;
            }
            if (asp.name == "SwordJabRt" && animst == "DownSlash")
            {
                ldj2.enabled = true;
            }
            else
            {
                ldj2.enabled = false;
            }
            if (asp.name == "SwordSwingLt" && animst == "DownSlash")
            {
                ldj3.enabled = true;
            }
            else
            {
                ldj3.enabled = false;
            }
            if (asp.name == "SwordJabLt" && animst == "DownSlash")
            {
                ldj4.enabled = true;
            }
            else
            {
                ldj4.enabled = false;
            }
            if (asp.name == "UA")
            {
                ac1.enabled = true;
            }
            else
            {
                ac1.enabled = false;
            }
            if (asp.name == "URA")
            {
                ac8.enabled = true;
            }
            else
            {
                ac8.enabled = false;
            }
            if (asp.name == "RA")
            {
                ac7.enabled = true;
            }
            else
            {
                ac7.enabled = false;
            }
            if (asp.name == "DRA")
            {
                ac6.enabled = true;
            }
            else
            {
                ac6.enabled = false;
            }
            if (asp.name == "DownAir" && animst != "DownAir")
            {
                ac5.enabled = true;
            }
            else
            {
                ac5.enabled = false;
            }
            if (asp.name == "ULA")
            {
                ac1.enabled = true;
            }
            else
            {
                ac1.enabled = false;
            }
        }
        if (asp.name == "DownAir" && animst == "DownAir")
        {
            daoir.enabled = true;
        }
        else
        {
            daoir.enabled = false;
        }
    }
    public bool jumpenabled()
    {
        if(Physics2D.Raycast(transform.position, -Vector3.up, dtg + 0.05f, ~particles)==true)
            return Physics2D.Raycast(transform.position, -Vector3.up, dtg + 0.05f, ~particles);
        if (Physics2D.Raycast(new Vector3(transform.position.x - 0.3125f, transform.position.y, transform.position.z), -Vector3.up, dtg + 0.05f, ~particles))
            return Physics2D.Raycast(new Vector3(transform.position.x - 0.3125f, transform.position.y, transform.position.z), -Vector3.up, dtg + 0.05f, ~particles);
        if (Physics2D.Raycast(new Vector3(transform.position.x + 0.3125f, transform.position.y, transform.position.z), -Vector3.up, dtg + 0.05f, ~particles))
            return Physics2D.Raycast(new Vector3(transform.position.x + 0.3125f, transform.position.y, transform.position.z), -Vector3.up, dtg + 0.05f, ~particles);
        return false;
    }
}
