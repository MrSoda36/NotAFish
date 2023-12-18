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
        
        // Si les niveaux n'ont pas été complétés au moins une fois :
        if (!FishingGameManager.Instance.allFishesCollected) {
                switch (FishingGameManager.Instance.fishingSceneName) {
                    case "Beach":
                        index = Random.Range(0, FishingObjectsList.Instance.beachObjects.Count - 1);
                        PrintFishCaught(FishingObjectsList.Instance.beachObjects[index]);

                        FishingObjectsList.Instance.beachObjects.Remove(FishingObjectsList.Instance.beachObjects[index]);
                        fishCollected.CheckFishCollected(FishingObjectsList.Instance.beachObjects);

                        break;
                    case "Forest":
                        index = Random.Range(0, FishingObjectsList.Instance.pondObjects.Count - 1);
                        PrintFishCaught(FishingObjectsList.Instance.pondObjects[index]);

                        FishingObjectsList.Instance.pondObjects.Remove(FishingObjectsList.Instance.pondObjects[index]);
                        fishCollected.CheckFishCollected(FishingObjectsList.Instance.pondObjects);

                        break;
                    case "Cave":
                        index = Random.Range(0, FishingObjectsList.Instance.caveRiverObjects.Count - 1);
                        PrintFishCaught(FishingObjectsList.Instance.caveRiverObjects[index]);

                        FishingObjectsList.Instance.caveRiverObjects.Remove(FishingObjectsList.Instance.caveRiverObjects[index]);
                        fishCollected.CheckFishCollected(FishingObjectsList.Instance.caveRiverObjects);

                        break;
                }
        }
        // Sinon on utilise les listes secondaires pour continuer à jouer
        else {
            switch (FishingGameManager.Instance.fishingSceneName) {
                case "Beach":
                    index = Random.Range(0, FishingObjectsList.Instance.beachObjectsClone.Count - 1);
                    PrintFishCaught(FishingObjectsList.Instance.beachObjectsClone[index]);

                    break;
                case "Forest":
                    index = Random.Range(0, FishingObjectsList.Instance.pondObjectsClone.Count - 1);
                    PrintFishCaught(FishingObjectsList.Instance.pondObjectsClone[index]);


                    break;
                case "Cave":
                    index = Random.Range(0, FishingObjectsList.Instance.caveRiverObjectsClone.Count - 1);
                    PrintFishCaught(FishingObjectsList.Instance.caveRiverObjectsClone[index]);

                    break;
            }
        }
    } 
}

