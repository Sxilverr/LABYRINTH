using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagetest : MonoBehaviour
{
    public float damage;
    public float damagecd;
    public float damagediff;
    public float instdiff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        damagecd -= 1;
        if(damage != instdiff)
        {
            damagecd = 10;
            instdiff = damage;
        }
        if (damage != damagediff && damagecd == 0)
        {
            Debug.Log(damage-damagediff);
            damagediff = damage;
        }
    }
    private void OnTriggerStay2D(Collider2D hitbox)
    {
        if (hitbox.sharedMaterial != null)
        {
            damage += (1 / (1 - hitbox.sharedMaterial.friction) - 1) * hitbox.gameObject.GetComponent<StatManager>().strength;
            GetComponent<Rigidbody2D>().AddForce(10 * Vector3.Normalize(transform.position - hitbox.gameObject.transform.position) * (1 / (1 - hitbox.sharedMaterial.bounciness) - 1));
        }
    }
}
