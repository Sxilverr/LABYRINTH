using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public float time = 63;
    public BoxCollider2D self;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(time == 0)
        {
            Destroy(gameObject);
        }
        time -= 1;
        if(time < 50)
        {
            if (time < 13)
            {
                self.enabled = true;
            }
        }
    }
}
