using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    public float del;
    // Start is called before the first frame update
    void Start()
    {
        del = 12;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(del <= 0)
        {
            Destroy(gameObject);
        }
        del -= 1;
    }
}
