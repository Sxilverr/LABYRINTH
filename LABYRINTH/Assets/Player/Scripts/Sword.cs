using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Sword : MonoBehaviour
{
    public GameObject Parent;
    public SpriteRenderer self;
    public SpriteRenderer checker;
    public Sprite hh;
    public Sprite dg;
    public string sn;
    public GameObject holder;
    // Start is called before the first frame update
    void Start()
    {
        checker = Parent.GetComponent<SpriteRenderer>();
        self = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Parent.GetComponent<Movement>().left == true)
        {
            holder.transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            holder.transform.localScale = new Vector3(1, 1, 1);
        }
        sn = checker.sprite.name;
        self.enabled = true;
        self.flipX = false;
        if (sn == "SwordSwingRt" || sn == "RA")
        {
            self.sprite = hh;
            transform.localPosition = new Vector3(0.78125f, -0.25f, 0);
            transform.localRotation = Quaternion.identity;
        } 
        else if (sn == "SwordJabRt") {
            self.sprite = hh;
            transform.localPosition = new Vector3(0.84375f, -0.25f, 0);
            transform.localRotation = Quaternion.identity;
        }
        else if (sn == "SwordJabRt2")
        {
            self.sprite = hh;
            transform.localPosition = new Vector3(0.90625f, -0.25f, 0);
            transform.localRotation = Quaternion.identity;
        }
        else if (sn == "SwordSwingUp")
        {
            self.sprite = hh;
            transform.localPosition = new Vector3(0.125f, 0.53125f, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (sn == "SwordJabUp")
        {
            self.sprite = hh;
            transform.localPosition = new Vector3(0.125f, 0.65625f, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (sn == "SwordJabUp2")
        {
            self.sprite = hh;
            transform.localPosition = new Vector3(0.125f, 0.78125f, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (sn == "UA")
        {
            self.sprite = hh;
            transform.localPosition = new Vector3(0.1875f, 0.59375f, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (sn == "DownAir")
        {
            self.sprite = hh;
            transform.localPosition = new Vector3(0.0625f, -0.78125f, 0);
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
        else if (sn == "SwordSwingUpRt")
        {
            self.sprite = dg;
            transform.localPosition = new Vector3(0.625f, 0.21875f, 0);
            transform.localRotation = Quaternion.identity;
        }
        else if (sn == "URA")
        {
            self.sprite = dg;
            transform.localPosition = new Vector3(0.6875f, 0.21875f, 0);
            transform.localRotation = Quaternion.identity;
        }
        else if (sn == "DRA")
        {
            self.sprite = dg;
            transform.localPosition = new Vector3(0.46875f, -0.625f, 0);
            transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
        else if (sn == "SwordSwingUpRtBack")
        {
            self.sprite = dg;
            transform.localPosition = new Vector3(-0.40625f, 0.3125f, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (sn == "ULA")
        {
            self.sprite = dg;
            transform.localPosition = new Vector3(-0.34375f, 0.3125f, 0);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (sn == "SwordSwingLt")
        {
            self.sprite = hh;
            transform.localPosition = new Vector3(-0.78125f, -0.25f, 0);
            transform.localRotation = Quaternion.identity;
            self.flipX = true;
        }
        else if (sn == "SwordJabLt")
        {
            self.sprite = hh;
            transform.localPosition = new Vector3(-0.84375f, -0.25f, 0);
            transform.localRotation = Quaternion.identity;
            self.flipX = true;
        }
        else
        {
            self.enabled = false;
        }
    }
}
