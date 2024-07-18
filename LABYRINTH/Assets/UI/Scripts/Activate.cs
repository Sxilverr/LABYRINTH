using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activate : MonoBehaviour
{
    public GameObject Ui;
    public UnityEngine.UI.Button Gobutton;
    public UnityEngine.UI.Button Nobutton;
    public UnityEngine.UI.Button Nobutton2;
    public UnityEngine.UI.Button Nobutton3;
    public UnityEngine.UI.Button Nobutton4;
    public UnityEngine.UI.Button Nobutton5;
    public UnityEngine.UI.Button Nobutton6;
    public UnityEngine.UI.Button Nobutton7;
    // Start is called before the first frame update
    void Awake()
    {
        Gobutton.onClick.AddListener(Activated);
        Nobutton.onClick.AddListener(DeActivated);
        Nobutton2.onClick.AddListener(DeActivated);
        Nobutton3.onClick.AddListener(DeActivated);
        Nobutton4.onClick.AddListener(DeActivated);
        Nobutton5.onClick.AddListener(DeActivated);
        Nobutton6.onClick.AddListener(DeActivated);
        Nobutton7.onClick.AddListener(DeActivated);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Activated()
    {
        Ui.SetActive(true);
    }
    void DeActivated()
    {
        Ui.SetActive(false);
    }
}
