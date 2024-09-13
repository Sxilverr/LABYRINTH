using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatAdder : MonoBehaviour
{
    public GameObject Player;
    public int id;
    public UnityEngine.UI.Button btn;
    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.FindWithTag("Player");
        btn = GetComponent<UnityEngine.UI.Button>();
        btn.onClick.AddListener(Activated);
    }

    // Update is called once per frame
    void Activated()
    {
        
        if (Player.GetComponent<StatManager>().levelpoints >= 1) {
            
            if (id == 1)
            {
                Player.GetComponent<StatManager>().manaCa += 10;
                
            }
            if (id == 2)
            {
                Player.GetComponent<StatManager>().strengtha += 0.15f;
            }
            if (id == 3)
            {
                Player.GetComponent<StatManager>().healthCa += 5;
            }
            if (id == 4)
            {
                Player.GetComponent<StatManager>().armor += 10;
            }
            if (id == 5)
            {
                Player.GetComponent<StatManager>().mobilitya += 3;
            }
            if (id == 6)
            {
                Player.GetComponent<StatManager>().manaRm += 0.05f;
            }
            if (id == 7)
            {
                Player.GetComponent<StatManager>().healthRa += 20;
            }
            Player.GetComponent<StatManager>().levelpoints -= 1;
        }
    }
}
