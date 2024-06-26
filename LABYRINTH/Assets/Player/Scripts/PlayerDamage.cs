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
    public Image Healthbar;
    public TMP_Text Healthtext;
    public float initwidth;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = gameObject.GetComponent<StatManager>().healthC;
        armor = gameObject.GetComponent<StatManager>().armor;
        shield = gameObject.GetComponent<StatManager>().shield;
        health = maxhealth;
        hrtimer = 0;
        initwidth = Healthbar.rectTransform.rect.width;
    }

    private void FixedUpdate()
    {
        if (hrtimer == 0)
        {
            hrtimer = 100;
            health += healthregen;
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
        Healthbar.rectTransform.localScale = new Vector2(health/maxhealth, 1);
        Healthbar.rectTransform.position = new Vector2(106 - 0f*(initwidth*(1 - health / maxhealth)), 22);
        Healthtext.text = (Mathf.Round(health*10)/10) + " / " + Mathf.Round(maxhealth*10)/10;
        if (check == false && maxhealth != 0) {
            maxhealth = gameObject.GetComponent<StatManager>().healthC;
            armor = gameObject.GetComponent<StatManager>().armor;
            shield = gameObject.GetComponent<StatManager>().shield;
            health = maxhealth;
            check = true;
        }
        maxhealth = gameObject.GetComponent<StatManager>().healthC;
        lightc = gameObject.GetComponent<StatManager>().lightC;
        armor = gameObject.GetComponent<StatManager>().armor;
        shield = gameObject.GetComponent<StatManager>().shield;
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
                GetComponent<StatManager>().shieldalloc -= 10*damage;
                damage = 0;
            } else
            {
                damage -= shield;
                GetComponent<StatManager>().shieldalloc = 0;
                health -= damage;
                damage = 0;
            }
        }
    }
}
