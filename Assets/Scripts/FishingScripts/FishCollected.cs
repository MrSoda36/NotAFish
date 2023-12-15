using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FishCollected : MonoBehaviour
{
    public int beachFishCount;
    public int pondFishCount;
    public int caveRiverFishCount;

    public GameStatusUI gameStatusUI;


    public void CheckFishCollected(List<FishScriptableObjects> list) {

        if(list.Count == 2) { // Status : You collected enough items, you can now access to next level
            gameStatusUI.gameStatusPanel.SetActive(true);
            gameStatusUI.statusText.text = "You collected enough items, you can now have access to the next level.";


            FishingGameManager.Instance.levelUnlocked++;
            FishingGameManager.Instance.UnlockNewLevel();
        }
        if(list.Count == 0) { // Status : You collected all items here
            gameStatusUI.gameStatusPanel.SetActive(true);
            gameStatusUI.statusText.text = "You collected all items here.";



        }
    }
}
