using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    public GameObject Fireball;
    public GameObject bigfireball;
    public GameObject explosion;
    public Animator anim;
    public string animst;
    // Start is called before the first frame update
    void Start()
    {
        manamax = GetComponent<StatManager>().manafree;
        regen = GetComponent<StatManager>().manaR;
        mana = manamax;
        initwidth = Manabar.rectTransform.rect.width;
        anim = GetComponent<Animator>();
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
        animst = anim.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if (manamax != 0 && doneyet == false)
        {
            mana = manamax;
            doneyet = true;
        }
        anim.SetBool("Magic", false);
        manamax = GetComponent<StatManager>().manafree;
        regen = GetComponent<StatManager>().manaR;
        Manabar.rectTransform.localScale = new Vector2(mana / manamax, 1);
        Manabar.rectTransform.position = Manatext.transform.position;
        Manatext.text = (Mathf.Round(mana * 10) / 10) + " / " + Mathf.Round(manamax * 10) / 10;
        if (Input.GetKeyDown(fireball) && mana >= 10 && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
        {
            anim.SetBool("Magic", true);
            mana -= 10;
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
        if (Input.GetKeyDown(bigfireballk) && mana >= 20 && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
        {
            anim.SetBool("Magic", true);
            mana -= 20;
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
        if (Input.GetKeyDown(explodek) && mana >= 100 && animst != "FwdSwing" && animst != "Jab" && animst != "UpJab" && animst != "DownSlash" && animst != "DownAir" && animst != "Nair" && animst != "Fair" && animst != "UpAir" && animst != "BowDraw" && animst != "BowFull" && animst != "NBow" && animst != "NBowFull" && anim.GetBool("Nbow") == false && anim.GetBool("BowF") == false && animst != "MagicCast")
        {
            anim.SetBool("Magic", true);
            mana -= 100;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Debug.Log("BIG BALL");
        }

    }
}
