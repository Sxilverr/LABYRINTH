using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatManager : MonoBehaviour
{
    public float lightC;
    public float lightCm;
    public float lightCa;

    public float manaC;
    public float manaCa;
    public float manaCm;
    public float manaCe;

    public float manaR;
    public float manaRm;

    public float manaE;
    public float manaEa;
    public float manaEm;

    public float healthC;
    public float healthCa;

    public float healthR;
    public float healthRm;
    public float healthRa;

    public float armor;
    public float shield;
    public float shieldalloc;
    public float shieldm;

    public float strength;
    public float strengthalloc;
    public float strengthm;
    public float strengtha;

    public float speed;
    public float jumph;
    public float mobilitym;
    public float mobilitya;
    public float speedalloc;
    public float jumpalloc;

    public float drawspd;
    public float fps;
    public float ffps;
    public float manafree;
    public float usablemana;

    public float xp;
    public float level;
    public float xpleft;
    public float plvlamt;
    public float nlvlamt;
    public float pctl;
    public float nlvpg;    public Image XPBAR;
    public TMP_Text XPtext;
    public TMP_Text LVtext;
    public float initwidth;
    public float prevlevel;
    public TMP_Text LVLup;
    public float leveltimer;
    public float prevlevelchecker;
    // Start is called before the first frame update
    void Start()
    {
        initwidth = XPBAR.rectTransform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        lightC = (25+level+Mathf.Floor(0.0125f*level*level))/25*(1 + lightCm) * (100 + lightCa);
        manaC = Mathf.Pow((1 + manaCm), (1 + manaCe))*(lightC+manaCa);
        manaR = (1 + manaRm) * manaC / 100f;
        manaE = (1 + manaEm) * (100 + manaEa);
        healthC = 100f + healthCa+level*4;
        healthR = (1 + healthRm) * (Mathf.Log10(lightC) - 1) * (healthC + healthRa) / 100f;
        shield = healthC*(1 + shieldm) * shieldalloc / 1000f;
        strength = (1 + strengthm) * (strengthalloc + 100 * (1 + strengtha));
        speed = 0.5f * (1 + mobilitym) * (100*Mathf.Log10(lightC) + mobilitya + 60*Mathf.Log(speedalloc/100+1));
        jumph = 0.25f * (1 + mobilitym) * (100*Mathf.Log10(lightC) + mobilitya + 60*Mathf.Log(jumpalloc/100+1))+50;
        Movement.speed = speed*3f;
        Movement.jump = jumph;
        drawspd = speed + Mathf.Sqrt(strength) - 10;
        fps = 1/Time.deltaTime;
        GetComponent<Animator>().SetFloat("DrawMult", drawspd / 100);
        manafree = manaC - shieldalloc - strengthalloc - jumpalloc - speedalloc;
        if (xp < 500000)
        {
            level = Mathf.Floor(Mathf.Sqrt(xp / 50));
            nlvlamt = 50 * Mathf.Ceil(Mathf.Sqrt((xp + 0.5f) / 50)) * Mathf.Ceil(Mathf.Sqrt((xp + 0.5f) / 50));
            xpleft = nlvlamt - xp;
            plvlamt = 50 * Mathf.Floor(Mathf.Sqrt(xp / 50)) * Mathf.Floor(Mathf.Sqrt(xp / 50));
            nlvpg = nlvlamt - plvlamt - xpleft;
            pctl = nlvpg / (nlvlamt - plvlamt);
            XPtext.text = nlvpg.ToString() + " / " + (nlvlamt - plvlamt).ToString();
            XPBAR.rectTransform.localScale = new Vector2(pctl, 1);
            LVtext.text = "LVL " + level.ToString();
        } else
        {
            level = 100;
            XPtext.text = "9950 / 9950";
            XPBAR.rectTransform.localScale = new Vector2(1, 1);
            LVtext.text = "LVL 100";
        }
    }
    void FixedUpdate()
    {
        ffps = 1 / Time.deltaTime;
        if (level != prevlevel)
        {
            LVLup.enabled = true;
            LVLup.text = "Level Up! \n +" + (4*(level-prevlevel)) + " HP \n +" + ((25 + (level) + Mathf.Floor(0.0125f * (level) * (level))) / 25 * (1 + lightCm) * (100 + lightCa) - ((25 + prevlevel + Mathf.Floor(0.0125f * prevlevel * prevlevel)) / 25 * (1 + lightCm) * (100 + lightCa))).ToString() + " Mana";
            if(prevlevelchecker != level)
            {
                leveltimer = 100;
                prevlevelchecker = level;
            }
            
        }
        if(leveltimer <= 0)
        {
                leveltimer = 0;
                LVLup.enabled = false;
                prevlevel = level;
        }
        else
        {
            leveltimer -= 1;
        }
    }
}
