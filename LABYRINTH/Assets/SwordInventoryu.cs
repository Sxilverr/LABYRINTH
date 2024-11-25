using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordInventoryu : MonoBehaviour
{
    public List<SwordTemplate> swords;
    public int swn;
    public GameObject Slot;
    public GameObject newslot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(swn != swords.Count)
        {
            swn += 1;
            newslot = Instantiate(Slot, transform.position, Quaternion.identity, gameObject.transform);
            if(swn % 2 == 0)
            {
                newslot.GetComponent<RectTransform>().anchoredPosition = new Vector2(100, -115 - ((swn / 2) - 1) * 200);
            }
            else
            {
                newslot.GetComponent<RectTransform>().anchoredPosition = new Vector2(-100, -115 - ((swn / 2)) * 200);
            }
            newslot.GetComponent<SlotManager>().selectedSword = swords[swn - 1];
        }
    }
}
