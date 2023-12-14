using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FishCaught : MonoBehaviour
{
    public GameObject FishSprite;
    public TextMeshProUGUI FishName;
    public TextMeshProUGUI FishDescription;
    
    public void PrintFishCaught()
    {
        FishSprite.GetComponent<Image>().sprite = null;
        FishName.text = "blabla";
        FishDescription.text = "Description";
    }
}
