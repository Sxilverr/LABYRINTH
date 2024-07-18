using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDamage : MonoBehaviour
{
    public float damage;
    public float health;
    public float maxhealth;
    public float shield;
    public float armor;
    public bool check;
    public float healthregen;
    public float hrtimer;
    public float lightc;
    public GameObject BV;
    public GameObject Cover;
    public Image Healthbar;
    public Image Healthunder;
    public Image ManaOver;
    public Image ManaUnder;
    public Image XpOver;
    public Image XpUnder;
    public TMP_Text Healthtext;
    public float initwidth;
    public Sprite heal;
    public Sprite over;
    public float shieldcap;
    public float res;
    public Image XPtext;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = gameObject.GetComponent<StatManager>().healthC;
        armor = gameObject.GetComponent<StatManager>().armor;
        shieldcap = gameObject.GetComponent<StatManager>().shield;
        health = maxhealth;
        hrtimer = 0;
        initwidth = Healthbar.rectTransform.rect.width;
    }

    private void FixedUpdate()
    {
        if (hrtimer <= 0)
        {
            if(health < maxhealth)
            {
                hrtimer = 100;
                health += healthregen;
            }
            else if(shield < shieldcap)
            {
                hrtimer = 100;
                shield += healthregen;
            }
        }
        if (healthregen != 0)
        {
            hrtimer -= 1;
        }
        if(health > maxhealth)
        {
            health = maxhealth;
        }
    }
    // Update is called once per frame
    void Update()
    {
        res = Screen.width;
        if (shield > shieldcap)
        {
            shield = shieldcap;
        }
        if (maxhealth != 0)
        {
            Healthbar.rectTransform.localScale = new Vector2(res / 1920*health / maxhealth, res / 1920);
            Healthbar.rectTransform.position = new Vector2(212*res/1920, 44*res/1920);
        }
        Healthunder.rectTransform.localScale = new Vector2(res / 1920, res / 1920);
        Healthunder.rectTransform.position = new Vector2(212 * res / 1920, 44 * res / 1920);
        Healthtext.rectTransform.localScale = new Vector2(res / 1920, res / 1920);
        Healthtext.rectTransform.position = new Vector2(212 * res / 1920, 44 * res / 1920);
        ManaUnder.rectTransform.localScale = new Vector2(res / 1920, res / 1920);
        ManaUnder.rectTransform.position = new Vector2(res-(212 * res / 1920), 44 * res / 1920);
        XpOver.rectTransform.position = new Vector2(212 * res / 1920, Screen.height-(44 * res / 1920));
        XpUnder.rectTransform.localScale = new Vector2(res / 1920, res / 1920);
        XPtext.rectTransform.localScale = new Vector2(res / 1920, res / 1920);
        XpUnder.rectTransform.position = new Vector2(212 * res / 1920, Screen.height-(44 * res / 1920));
        Healthtext.text = (Mathf.Round(health*10 + shield * 10)/10) + " / " + Mathf.Round(maxhealth*10)/10;
        XPtext.rectTransform.position = new Vector2(212 * res / 1920, Screen.height - (44 * res / 1920));
        if (shield == 0)
        {
            Healthtext.color = new Color(255/255, 119f/255, 119f/255, 255/255);
            Healthbar.sprite = heal;
        } else
        {
            Healthtext.color = new Color(0, 255/255, 228f/255, 255/255);
            Healthbar.sprite = over;
        }
        if (check == false && maxhealth != 0) {
            maxhealth = gameObject.GetComponent<StatManager>().healthC;
            armor = gameObject.GetComponent<StatManager>().armor;
            shieldcap = gameObject.GetComponent<StatManager>().shield;
            health = maxhealth;
            check = true;
        }
        if(health < 0)
        {
            health = 0;
        }
        Cover.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, Mathf.Pow(Mathf.Sqrt(maxhealth)-Mathf.Sqrt(health), 2)/maxhealth);
        maxhealth = gameObject.GetComponent<StatManager>().healthC;
        lightc = gameObject.GetComponent<StatManager>().lightC;
        armor = gameObject.GetComponent<StatManager>().armor;
        shieldcap = gameObject.GetComponent<StatManager>().shield;
        healthregen = gameObject.GetComponent<StatManager>().healthR;
        BV.transform.localScale = new Vector3(0.3f+Mathf.Pow(10*lightc, 0.33333333333f)*health/maxhealth/10f*0.7f, 0.3f + Mathf.Pow(10 * lightc, 0.33333333333f) * health / maxhealth / 10f * 0.7f, 0.3f + Mathf.Pow(10 * lightc, 0.33333333333f) * health / maxhealth / 10f * 0.7f);
        damage /= (100+armor);
        if(damage > 0 && shield == 0)
        {
            health -= damage;
            damage = 0;
        }
        if(damage > 0 && shield > 0)
        {
            if(damage < shield)
            {
                shield -= damage;
                damage = 0;
            } else
            {
                damage -= shield;
                shield = 0;
                health -= damage;
                damage = 0;
            }
        }
    }
}
