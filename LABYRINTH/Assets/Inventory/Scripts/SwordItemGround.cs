using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwordItemGround : MonoBehaviour
{
    public GameObject inv;
    public SwordTemplate sword;
    // Start is called before the first frame update
    void Start()
    {
        inv = GameObject.FindWithTag("Player").GetComponent<Movement>().swinv;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().sprite = sword.diagTexture;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inv.GetComponent<SwordInventoryu>().swords.Add(sword);
            Destroy(gameObject);
        }
    }
}
