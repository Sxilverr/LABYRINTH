using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

[CreateAssetMenu(fileName = "New Sword", menuName = "SwordItem")]
public class SwordTemplate : ScriptableObject
{
    public Sprite baseTexture;
    public Sprite diagTexture;
    public float strengthBonus;
    public int id;
    public string itemName;
    public float manabonus;
    public float speedbonus;
    public string Lore;

}
