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

    public FishCollected fishCollected;

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
                index = Random.Range(0, FishingObjectsList.Instance.beachObjects.Count - 1);
                PrintFishCaught(FishingObjectsList.Instance.beachObjects[index]);
                fishCollected.beachFishCount++;

                FishingObjectsList.Instance.beachObjects.Remove(FishingObjectsList.Instance.beachObjects[index]);
                fishCollected.CheckFishCollected(FishingObjectsList.Instance.beachObjects);

                break;
            case "Forest":
                index = Random.Range(0, FishingObjectsList.Instance.pondObjects.Count - 1);
                PrintFishCaught(FishingObjectsList.Instance.pondObjects[index]);
                fishCollected.pondFishCount++;

                FishingObjectsList.Instance.pondObjects.Remove(FishingObjectsList.Instance.pondObjects[index]);
                fishCollected.CheckFishCollected(FishingObjectsList.Instance.pondObjects);

                break;
            case "Cave":
                index = Random.Range(0, FishingObjectsList.Instance.caveRiverObjects.Count - 1);
                PrintFishCaught(FishingObjectsList.Instance.caveRiverObjects[index]);
                fishCollected.caveRiverFishCount++;

                FishingObjectsList.Instance.caveRiverObjects.Remove(FishingObjectsList.Instance.caveRiverObjects[index]);
                fishCollected.CheckFishCollected(FishingObjectsList.Instance.caveRiverObjects);

                break;
        } 


    }

}
