using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SlotManager : MonoBehaviour
{
    public SwordTemplate selectedSword;
    public Image SwordImage;
    public Vector2 imagesize;
    public float maxe;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwordImage.sprite = selectedSword.diagTexture;
        imagesize = new Vector2(selectedSword.diagTexture.bounds.size.x, selectedSword.diagTexture.bounds.size.y);
        maxe = Mathf.Max(imagesize[0], imagesize[1]);
        imagesize /= maxe;
        imagesize *= 125;
        SwordImage.gameObject.transform.localScale = imagesize / 125;
    }
}
