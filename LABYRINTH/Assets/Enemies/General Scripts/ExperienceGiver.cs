using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGiver : MonoBehaviour
{
    public float experience;
    public bool dead;
    public ExperienceGiver self;
    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<ExperienceGiver>();
    }

    // Update is called once per frame
    void Update()
    {
        if(dead == true)
        {
            GameObject.FindWithTag("Player").GetComponent<StatManager>().xp += experience;
            self.enabled = false;
        }
    }
}
