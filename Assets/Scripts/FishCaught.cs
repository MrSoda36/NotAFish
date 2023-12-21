using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FishCaught : MonoBehaviour
{
    public GameObject catchBox;
    [SerializeField] AudioClip applauseClip;

    [Header("Fish caught info")]
    public GameObject FishSprite;
    public TextMeshProUGUI FishName;
    public TextMeshProUGUI FishDescription;

    public FishCollected fishCollected;

    [Header("Stars")]
    public GameObject starOne;
    public GameObject starTwo;
    public GameObject starThree;

    public void Start()
    {
        if (FishingGameManager.Instance.isFishCaught) {
            GetFish();
            FishingGameManager.Instance.isFishCaught = false;
        }
    }


    public void PrintFishCaught(FishScriptableObjects fishScriptableObjects) {

        catchBox.SetActive(true);
        SoundManager.SoundInstance.PlaySound(applauseClip);

        FishSprite.GetComponent<Image>().sprite = fishScriptableObjects.itemSprite;
        FishName.text = fishScriptableObjects.itemName;
        FishDescription.text = fishScriptableObjects.itemDescription;
        
        if(FishingGameManager.Instance.wallHit == 0) {
            //Debug.Log("3 Star");
            starOne.SetActive(true);
            starTwo.SetActive(true);
            starThree.SetActive(true);
        }
        else if(FishingGameManager.Instance.wallHit == 1) {
            //Debug.Log("2 Star");
            starOne.SetActive(true);
            starTwo.SetActive(true);
            starThree.SetActive(false);
        }
        else if (FishingGameManager.Instance.wallHit == 2){
            //Debug.Log("1 Star");
            starOne.SetActive(true);
            starTwo.SetActive(false);
            starThree.SetActive(false);
        }
        else if (FishingGameManager.Instance.wallHit >= 3) {
            //Debug.Log("0 Star");
            starOne.SetActive(false);
            starTwo.SetActive(false);
            starThree.SetActive(false);
        }

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

