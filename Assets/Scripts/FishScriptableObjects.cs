using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FishItem", menuName = "ScriptableObject/FishItem")]

public class FishScriptableObjects : ScriptableObject
{
    public string itemName;
    public string itemDescription;

    public Sprite itemSprite;

}
