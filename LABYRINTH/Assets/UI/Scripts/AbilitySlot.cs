using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilitySlot : MonoBehaviour
{
    public GameObject Plus;
    public TMP_Text Name;
    public int id_self;
    public Image self;
    public Sprite[] idimages;
    public int abilityid;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(id_self == 0)
        {
            Plus.SetActive(true);
            Name.text = "Active Ability";
            self.color = new Color(36f/255, 36f/255, 36f/255);
        } else
        {
            self.color = new Color(1, 1, 1);
            Plus.SetActive(false);
        }
        if (id_self == 1)
        {
            Name.text = "Fireball";
        }
        if (id_self == 2)
        {
            Name.text = "Big Fireball";
        }
        if (id_self == 3)
        {
            Name.text = "Explosion";
        }
        if (id_self == 4)
        {
            Name.text = "Beam";
        }
        if (id_self == 5)
        {
            Name.text = "Lightning";
        }
        if (id_self == 6)
        {
            Name.text = "Health Burst";
        }
        if (id_self == 7)
        {
            Name.text = "Vortex";
        }
        self.sprite = idimages[id_self];
    }
}
