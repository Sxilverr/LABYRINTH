using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject Abislot;
    public int id;
    public UnityEngine.UI.Button btn;
    // Start is called before the first frame update
    void Awake()
    {
        btn = GetComponent<UnityEngine.UI.Button>();
        btn.onClick.AddListener(Activated);
    }

    // Update is called once per frame
    void Activated()
    {
        Abislot.GetComponent<AbilitySlot>().id_self = id;
    }
}
