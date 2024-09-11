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
        
        if (gameObject.name.StartsWith("Ab")){
            if (id_self == 0)
            {
                Plus.SetActive(true);
                Name.text = "Active Ability";
                self.color = new Color(36f / 255, 36f / 255, 36f / 255);
            }
            else
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
        }
        if (gameObject.name.StartsWith("Pa"))
        {
            if (id_self == 0)
            {
                Plus.SetActive(true);
                Name.text = "Passive Ability";
                self.color = new Color(36f / 255, 36f / 255, 36f / 255);
            }
            else
            {
                self.color = new Color(1, 1, 1);
                Plus.SetActive(false);
            }
            if (id_self == 1)
            {
                Name.text = "Damage Aura";
            }
            if (id_self == 2)
            {
                Name.text = "Health Aura";
            }
            if (id_self == 3)
            {
                Name.text = "Ice Aura";
            }
            if (id_self == 4)
            {
                Name.text = "Lifesteal Aura";
            }
            if (id_self == 5)
            {
                Name.text = "Flight";
            }
            if (id_self == 6)
            {
                Name.text = "Health Burst";
            }
            if (id_self == 7)
            {
                Name.text = "Vortex";
            }
        }
        if (gameObject.name.StartsWith("Sw"))
        {
            if (id_self == 0)
            {
                Plus.SetActive(true);
                Name.text = "Sword Ability";
                self.color = new Color(36f / 255, 36f / 255, 36f / 255);
            }
            else
            {
                self.color = new Color(1, 1, 1);
                Plus.SetActive(false);
            }
            if (id_self == 1)
            {
                Name.text = "Dagger Throw";
            }
            if (id_self == 2)
            {
                Name.text = "Slash Projectile";
            }
            if (id_self == 3)
            {
                Name.text = "Ice-Cold Blade";
            }
            if (id_self == 4)
            {
                Name.text = "Mana Steal";
            }
            if (id_self == 5)
            {
                Name.text = "Lifesteal";
            }
            if (id_self == 6)
            {
                Name.text = "Health Burst";
            }
            if (id_self == 7)
            {
                Name.text = "Vortex";
            }
        }
        if (gameObject.name.StartsWith("Bo"))
        {
            if (id_self == 0)
            {
                Plus.SetActive(true);
                Name.text = "Bow Ability";
                self.color = new Color(36f / 255, 36f / 255, 36f / 255);
            }
            else
            {
                self.color = new Color(1, 1, 1);
                Plus.SetActive(false);
            }
            if (id_self == 1)
            {
                Name.text = "Ghost Arrows";
            }
            if (id_self == 2)
            {
                Name.text = "Exploding Arrows";
            }
            if (id_self == 3)
            {
                Name.text = "Triple Shot";
            }
            if (id_self == 4)
            {
                Name.text = "Teleportation";
            }
            if (id_self == 5)
            {
                Name.text = "Auto Aim";
            }
            if (id_self == 6)
            {
                Name.text = "Health Burst";
            }
            if (id_self == 7)
            {
                Name.text = "Vortex";
            }
        }
        if (gameObject.name.StartsWith("Shi"))
        {
            if (id_self == 0)
            {
                Plus.SetActive(true);
                Name.text = "Shield Ability";
                self.color = new Color(36f / 255, 36f / 255, 36f / 255);
            }
            else
            {
                self.color = new Color(1, 1, 1);
                Plus.SetActive(false);
            }
            if (id_self == 1)
            {
                Name.text = "2-Sided Shield";
            }
            if (id_self == 2)
            {
                Name.text = "Mana Shield";
            }
            if (id_self == 3)
            {
                Name.text = "Counter Attack";
            }
            if (id_self == 4)
            {
                Name.text = "Orbit";
            }
            if (id_self == 5)
            {
                Name.text = "Death Orbit";
            }
            if (id_self == 6)
            {
                Name.text = "Health Burst";
            }
            if (id_self == 7)
            {
                Name.text = "Vortex";
            }
        }
        self.sprite = idimages[id_self];
    }
}
