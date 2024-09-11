using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public GameObject Parent;
    public SpriteRenderer self;
    public GameObject Backs;
    public GameObject Orbit;
    public GameObject Orbit2;
    public SpriteRenderer selfBack;
    public SpriteRenderer selfOrbit;
    public SpriteRenderer selfOrbit2;
    public SpriteRenderer checker;
    public BoxCollider2D col1;
    public BoxCollider2D col2;
    public float spin;
    public string sn;
    // Start is called before the first frame update
    void Start()
    {
        checker = Parent.GetComponent<SpriteRenderer>();
        self = GetComponent<SpriteRenderer>();
        selfBack = Backs.GetComponent<SpriteRenderer>();
        selfOrbit = Orbit.GetComponent<SpriteRenderer>();
        selfOrbit2 = Orbit2.GetComponent<SpriteRenderer>();
        col1 = Orbit.GetComponent<BoxCollider2D>();
        col2 = Orbit2.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sn = checker.sprite.name;
        self.enabled = true;
        if (Parent.GetComponent<ManaManager>().backshield == true) {
            selfBack.enabled = true;
        }
        if (Parent.GetComponent<ManaManager>().shorbit == true || Parent.GetComponent<ManaManager>().orbitpummel == true)
        {
            selfOrbit.enabled = true;
            selfOrbit2.enabled = true;
            col1.enabled = true;
            col2.enabled = true;
        }
        spin += 50 * Time.deltaTime;
        spin %= 50;
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
            if (selfBack != null)
            {
                selfBack.enabled = false;
            }
        }
        if (Parent.GetComponent<ManaManager>().shorbit == true || Parent.GetComponent<ManaManager>().orbitpummel == true)
        {
            if (sn == "BaseShield" || sn == "SBack" || sn == "SIdleCycle" || sn == "SRunCycle" || sn == "SRunMid")
            {
                if (Parent.GetComponent<Movement>().left == false)
                {
                    Orbit2.transform.localPosition = new Vector3(3 * Mathf.Cos(spin * Mathf.PI / 25), 3 * Mathf.Sin(spin * Mathf.PI / 25), 0);
                    Orbit.transform.localPosition = new Vector3(-3 * Mathf.Cos(spin * Mathf.PI / 25), -3 * Mathf.Sin(spin * Mathf.PI / 25), 0);
                }
                else
                {
                    Orbit2.transform.localPosition = new Vector3(3 * Mathf.Cos(spin * Mathf.PI / 25), -3 * Mathf.Sin(spin * Mathf.PI / 25), 0);
                    Orbit.transform.localPosition = new Vector3(-3 * Mathf.Cos(spin * Mathf.PI / 25), 3 * Mathf.Sin(spin * Mathf.PI / 25), 0);
                }
            }
            else
            {
                selfOrbit2.enabled = false;
                selfOrbit.enabled = false;
                col1.enabled = false;
                col2.enabled = false;
            }
        }
    }
    private void FixedUpdate()
    {
        
    }
}
