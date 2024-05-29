using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightC = (1 + lightCm) * (100 + lightCa);
        manaC = Mathf.Pow((1 + manaCm), (1 + manaCe))*(lightC+manaCa);
        manaR = (1 + manaRm) * manaC / 100f;
        manaE = (1 + manaEm) * (100 + manaEa);
        healthC = 100f + healthCa;
        healthR = (1 + healthRm) * (Mathf.Log10(lightC) - 1) * (healthC + healthRa) / 100f;
        shield = (1 + shieldm) * shieldalloc / 10f;
        strength = (1 + strengthm) * (strengthalloc + 100 * (1 + strengtha));
        speed = 0.5f * (1 + mobilitym) * (100*Mathf.Log10(lightC) + mobilitya + 60*Mathf.Log(speedalloc/100+1));
        jumph = 0.25f * (1 + mobilitym) * (100*Mathf.Log10(lightC) + mobilitya + 60*Mathf.Log(jumpalloc/100+1))+50;
        Movement.speed = speed*3f;
        Movement.jump = jumph;
        drawspd = speed + Mathf.Sqrt(strength) - 10;
        fps = 1/Time.deltaTime;
        GetComponent<Animator>().SetFloat("DrawMult", drawspd / 100);
        manafree = manaC - shieldalloc - strengthalloc - jumpalloc - speedalloc;
    }
    void FixedUpdate()
    {
        ffps = 1 / Time.deltaTime;
    }
}
