using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FishCaught : MonoBehaviour
{
    public GameObject catchBox;

    public GameObject FishSprite;
    public TextMeshProUGUI FishName;
    public TextMeshProUGUI FishDescription;

    public void Start()
    {
        if (FishingGameManager.Instance.isFishCaught) {
            GetFish();
            FishingGameManager.Instance.isFishCaught = false;
        }
    }


    public void PrintFishCaught(FishScriptableObjects fishScriptableObjects) {

        catchBox.SetActive(true);

        FishSprite.GetComponent<Image>().sprite = fishScriptableObjects.itemSprite;
        FishName.text = fishScriptableObjects.itemName;
        FishDescription.text = fishScriptableObjects.itemDescription;
    }

    public void GetFish() {

        int index = 0;

        switch (FishingGameManager.Instance.fishingSceneName)
        {
            case "Beach":

                index = Random.Range(0, FishingObjectsList.Instance.oceanObjects.Count - 1);
                PrintFishCaught(FishingObjectsList.Instance.oceanObjects[index]);

                FishingObjectsList.Instance.oceanObjects.Remove(FishingObjectsList.Instance.oceanObjects[index]);
                break;
            case "Forest":

                index = Random.Range(0, FishingObjectsList.Instance.poundObjects.Count - 1);
                PrintFishCaught(FishingObjectsList.Instance.poundObjects[index]);

                FishingObjectsList.Instance.poundObjects.Remove(FishingObjectsList.Instance.poundObjects[index]);
                break;
            case "Cave":

                index = Random.Range(0, FishingObjectsList.Instance.caveRiverObjects.Count - 1);
                PrintFishCaught(FishingObjectsList.Instance.caveRiverObjects[index]);

                FishingObjectsList.Instance.caveRiverObjects.Remove(FishingObjectsList.Instance.caveRiverObjects[index]);
                break;
        } 
    }
}
