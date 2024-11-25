using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordActivator : MonoBehaviour
{
    public UnityEngine.UI.Button btn;
    public GameObject whole;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<UnityEngine.UI.Button>();
        btn.onClick.AddListener(Activated);
    }

    // Update is called once per frame
    void Activated()
    {
        whole.SetActive(true);
    }
}
