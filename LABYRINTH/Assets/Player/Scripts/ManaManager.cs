using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ManaManager : MonoBehaviour
{
    public float manamax;
    public float mana;
    public float regen;
    public Image Manabar;
    public TMP_Text Manatext;
    public float initwidth;
    public bool doneyet;
    public KeyCode fireball;
    public KeyCode bigfireballk;
    public KeyCode explodek;
    public KeyCode toggles;
    public KeyCode be;
    public KeyCode beam;
    public KeyCode lightning;
    public KeyCode heal;
    public KeyCode vort;
    public KeyCode ts;
    public KeyCode dagge;
    public GameObject Fireball;
    public GameObject bigfireball;
    public GameObject explosion;
    public GameObject beamp;
    public GameObject bolt;
    public GameObject healthanim;
    public GameObject vortex;
    public Animator anim;
    public string animst;
    public float sfbc;
    public float lfbc;
    public float spc;
    public float expc;
    public float bowc;
    public float beac;
    public float boltc;
    public float healc;
    public float heala;
    public float vortc;
    public float tsc;
    public float daggc;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        manamax = GetComponent<StatManager>().manafree;
        regen = GetComponent<StatManager>().manaR;
        mana = manamax;
        initwidth = Manabar.rectTransform.rect.width;
        anim = GetComponent<Animator>();
        GetComponent<Movement>().swingcost = spc;
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (mana < manamax)
        {
            mana += regen / 25;
        }
        if(mana > manamax)
        {
            mana = manamax;
        }
        if (mana < 0)
        {
            mana = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(be))
        {
            if (GetComponent<Movement>().bowexp == true)
            {
                GetComponent<Movement>().bowexp = false;
            }
            else
            {
                GetComponent<Movement>().bowexp = true;
            }
        }
        if (Input.GetKeyDown(ts))
        {
            if (GetComponent<Movement>().tripleshot == true)
            {
                GetComponent<Movement>().tripleshot = false;
            }
            else
            {
                GetComponent<Movement>().tripleshot = true;
            }
        }
        if (Input.GetKeyDown(dagge))
        {
            if (GetComponent<Movement>().daggers == true)
            {
                GetComponent<Movement>().daggers = false;
            }
            else
            {
                GetComponent<Movement>().daggers = true;
            }
        }
        if (Input.GetKeyDown(heal) && mana >= healc * manamax && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
        {
            if (manamax >= 100)
            {
                anim.SetBool("Magic", true);
                heala = healc * GetComponent<PlayerDamage>().maxhealth;
                if (GetComponent<PlayerDamage>().maxhealth - GetComponent<PlayerDamage>().health >= heala)
                {
                    GetComponent<PlayerDamage>().health += heala;
                }
                else
                {
                    heala -= (GetComponent<PlayerDamage>().maxhealth - GetComponent<PlayerDamage>().health);
                    GetComponent<PlayerDamage>().health = GetComponent<PlayerDamage>().maxhealth;
                    GetComponent<PlayerDamage>().shield += heala;
                }
                mana -= healc * manamax;
                Instantiate(healthanim, transform.position, Quaternion.identity);
            } else if (mana >= healc*100)
            {
                anim.SetBool("Magic", true);
                heala = healc * GetComponent<PlayerDamage>().maxhealth;
                if (GetComponent<PlayerDamage>().maxhealth - GetComponent<PlayerDamage>().health >= heala)
                {
                    GetComponent<PlayerDamage>().health += heala;
                }
                else
                {
                    heala -= (GetComponent<PlayerDamage>().maxhealth - GetComponent<PlayerDamage>().health);
                    GetComponent<PlayerDamage>().health = GetComponent<PlayerDamage>().maxhealth;
                    GetComponent<PlayerDamage>().shield += heala;
                }
                mana -= healc * 100;
                Instantiate(healthanim, transform.position, Quaternion.identity);
            }
        }
        animst = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if (manamax != 0 && doneyet == false)
        {
            mana = manamax;
            doneyet = true;
        }
        if (Input.GetKeyDown(toggles))
        {
            if(GetComponent<Movement>().swordproj == true)
            {
                GetComponent<Movement>().swordproj = false;
            } else
            {
                GetComponent<Movement>().swordproj = true;
            }
        }
        anim.SetBool("Magic", false);
        manamax = GetComponent<StatManager>().manafree;
        regen = GetComponent<StatManager>().manaR;
        Manabar.rectTransform.localScale = new Vector2(mana / manamax, 1);
        Manabar.rectTransform.position = Manatext.transform.position;
        Manatext.text = (Mathf.Round(mana * 10) / 10) + " / " + Mathf.Round(manamax * 10) / 10;
        if (Input.GetKeyDown(vort) && mana >= vortc && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
        {
            mana -= vortc;
            anim.SetBool("Magic", true);
            if (GetComponent<Movement>().left == false)
            {
                Instantiate(vortex, new Vector3(transform.position.x + 2, transform.position.y, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(vortex, new Vector3(transform.position.x - 2, transform.position.y, 0), Quaternion.identity);
            }
        }
        if (Input.GetKeyDown(fireball) && mana >= sfbc && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
        {
            anim.SetBool("Magic", true);
            mana -= sfbc;
            Debug.Log("BALL");
            if (GetComponent<Movement>().left == false)
            {
                GameObject ball = Instantiate(Fireball, transform.position, Quaternion.identity);
          
            } else
            {
                GameObject ball = Instantiate(Fireball, transform.position, Quaternion.identity);
                ball.transform.Rotate(0, 0, 180);
            }
        }
        if (Input.GetKeyDown(lightning) && mana >= boltc && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
        {
            anim.SetBool("Magic", true);
            mana -= boltc;
            Debug.Log("BALL");
            if (GetComponent<Movement>().left == false)
            {
                GameObject ball = Instantiate(bolt, transform.position, Quaternion.identity, Player);
                ball.transform.position += new Vector3(2.09375f, -0.1875f, 0);
            }
            else
            {
                GameObject ball = Instantiate(bolt, transform.position, Quaternion.identity, Player);
                ball.transform.position -= new Vector3(2.09375f, 0.1875f, 0);
                ball.GetComponent<SpriteRenderer>().flipY = true;
                ball.transform.Rotate(0, 0, 180);
            }
        }
        if (Input.GetKeyDown(bigfireballk) && mana >= lfbc && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
        {
            anim.SetBool("Magic", true);
            mana -= lfbc;
            if (GetComponent<Movement>().left == false)
            {
                GameObject ball = Instantiate(bigfireball, transform.position, Quaternion.identity);
                ball.transform.position += new Vector3(0.5f, 0, 0);
            }
            else
            {
                GameObject ball = Instantiate(bigfireball, transform.position, Quaternion.identity);
                ball.transform.Rotate(0, 0, 180);
                ball.transform.position -= new Vector3(0.5f, 0, 0);
            }
            Debug.Log("BIG BALL");
        }
        if (Input.GetKeyDown(beam) && mana >= beac && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
        {
            anim.SetBool("Magic", true);
            mana -= beac;
            if (GetComponent<Movement>().left == false)
            {
                GameObject ball = Instantiate(beamp, transform.position, Quaternion.identity);
                ball.transform.position += new Vector3(32.5f, -0.25f, 0);
            }
            else
            {
                GameObject ball = Instantiate(beamp, transform.position, Quaternion.identity);
                ball.transform.Rotate(0, 0, 180);
                ball.transform.position -= new Vector3(32.5f, 0.25f, 0);
            }
            Debug.Log("BIG BALL");
        }
        if (Input.GetKeyDown(explodek) && mana >= expc && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
        {
            anim.SetBool("Magic", true);
            mana -= expc;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Debug.Log("BIG BALL");
        }

    }
}
