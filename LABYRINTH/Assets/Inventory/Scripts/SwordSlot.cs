using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class SwordSlot : MonoBehaviour
{
    public GameObject slot;
    public SwordTemplate id;
    public UnityEngine.UI.Button btn;
    public GameObject whole;
    public GameObject text;
    public GameObject texte;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<UnityEngine.UI.Button>();
        btn.onClick.AddListener(Activated);
        whole = GameObject.FindWithTag("ScrollS");
    }
    private void Update()
    {
        texte.GetComponent<TMP_Text>().text = slot.GetComponent<SlotManager>().selectedSword.itemName + "\n\n" + slot.GetComponent<SlotManager>().selectedSword.strengthBonus + " Strength\n" + slot.GetComponent<SlotManager>().selectedSword.manabonus + " Mana\n" + slot.GetComponent<SlotManager>().selectedSword.speedbonus + " Speed";
    }
    // Update is called once per frame
    void Activated()
    {
        id = slot.GetComponent<SlotManager>().selectedSword;
        GameObject.FindWithTag("Player").GetComponent<StatManager>().SelectedSword = id;
        text.SetActive(false);
        whole.SetActive(false);
    }

    public void HoverOn()
    {
        text.SetActive(true);
    }
    public void HoverOff()
    {
        text.SetActive(false);
    }
}
