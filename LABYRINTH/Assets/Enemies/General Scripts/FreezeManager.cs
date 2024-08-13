using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeManager : MonoBehaviour
{
    public bool freeze;
    public float freezeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if(freezeTime > 0)
            freezeTime -= 1;
        if(freezeTime <= 0)
        {
            freeze = false;
        } else
        {
            freeze = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (freeze == true)
        {
            if(GetComponent<SlimeBehavior>() != null)
                GetComponent<SlimeBehavior>().enabled = false;
            if (GetComponent<LostAdventurerBehavior>() != null)
                GetComponent<LostAdventurerBehavior>().enabled = false;
            if (GetComponent<SnakeBehavior>() != null)
                GetComponent<SnakeBehavior>().enabled = false;
            if (GetComponent<SpawnerBehavior>() != null)
                GetComponent<SpawnerBehavior>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color (0.5f, 1, 1);
        } else
        {
            if (GetComponent<SlimeBehavior>() != null)
                GetComponent<SlimeBehavior>().enabled = true;
            if (GetComponent<LostAdventurerBehavior>() != null)
                GetComponent<LostAdventurerBehavior>().enabled = true;
            if (GetComponent<SnakeBehavior>() != null)
                GetComponent<SnakeBehavior>().enabled = true;
            if (GetComponent<SpawnerBehavior>() != null)
                GetComponent<SpawnerBehavior>().enabled = true;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
