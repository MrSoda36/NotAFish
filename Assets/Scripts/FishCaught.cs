using TMPro;
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
        // switch pour future compatiblité de futurs niveaux
        switch (FishingGameManager.Instance.fishingSceneName) {
            case "Beach":
                index = Random.Range(0, FishingObjectsList.Instance.beachObjects.Count - 1);
                PrintFishCaught(FishingObjectsList.Instance.beachObjects[index]);

                FishingObjectsList.Instance.beachObjects.Remove(FishingObjectsList.Instance.beachObjects[index]);
                fishCollected.CheckFishCollected(FishingObjectsList.Instance.beachObjects);
            break;

        }
    } 
}

