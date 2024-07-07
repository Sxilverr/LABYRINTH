using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject Parent;
    public SpriteRenderer self;
    public SpriteRenderer checker;
    public string sn;
    // Start is called before the first frame update
    void Start()
    {
        checker = Parent.GetComponent<SpriteRenderer>();
        self = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sn = checker.sprite.name;
        self.enabled = true;
        if (sn == "BaseShield" || sn == "SBack")
        {
            transform.localPosition = new Vector3(0.5f, -0.1875f, 0);
            transform.localRotation = Quaternion.identity;
        }
        else if (sn == "SIdleCycle")
        {
            transform.localPosition = new Vector3(0.5f, -0.25f, 0);
            transform.localRotation = Quaternion.identity;
        }
        else if (sn == "SRunCycle" || sn == "SRunMid")
        {
            transform.localPosition = new Vector3(0.5f, -0.3125f, 0);
            transform.localRotation = Quaternion.identity;
        }
        else
        {
            self.enabled = false;
        }
    }
}
