using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soverlay : MonoBehaviour
{
    public Sprite diag;
    public Sprite horiz;
    public float pos;
    public SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {
        pos = 0;
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pos == 0)
        {
            sp.enabled = false;
        } else
        {
            sp.enabled = true;
        }
        if(pos == 1)
        {
            sp.sprite = horiz;
            transform.rotation = Quaternion.identity;
            transform.localPosition = new Vector3(0.78125f, -0.25f, 0);
        }
        if (pos == 2)
        {
            sp.sprite = horiz;
            transform.rotation = Quaternion.identity;
            transform.localPosition = new Vector3(0.84375f, -0.25f, 0);
        }
        if (pos == 3)
        {
            sp.sprite = horiz;
            transform.rotation = Quaternion.identity;
            transform.localPosition = new Vector3(0.90625f, -0.25f, 0);
        }
    }
}
