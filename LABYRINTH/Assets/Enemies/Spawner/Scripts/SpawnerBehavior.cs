using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    public GameObject spawner;
    public float spawnamt;
    public float spawntimer;
    public float tt;
    public float smid;
    public float xdist;
    // Start is called before the first frame update
    void Start()
    {
        tt = spawntimer;
        smid = (spawnamt + 1)/2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(tt == 84)
        {
            GetComponent<Animator>().SetBool("Spawn", true);
            Debug.Log("KJDAHGHFDHUAG");
        } else if (GetComponent<SpriteRenderer>().sprite.name == "Base" && tt > 100)
        {
            GetComponent<Animator>().SetBool("Spawn", false);
        }
        if (tt == 0)
        {
            tt = spawntimer;
            int i = 1;
            while (i <= spawnamt){
                Instantiate(spawner, transform.position - new Vector3((smid - i)*xdist, 0, 0), Quaternion.identity);
                i++;
            }
        }
        if(GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "BaseState" || tt < 100)
            tt -= 1;
    }
}
