using System.Collections.Generic;
using UnityEngine;

public class FishCollected : MonoBehaviour
{

    public GameStatusUI gameStatusUI;


    public void CheckFishCollected(List<FishScriptableObjects> list) {
        if(list.Count == 2) { // Status : You collected enough items access to next level
            gameStatusUI.gameStatusPanel.SetActive(true);
            gameStatusUI.statusText.text = "You collected enough items, you can now have access to the next level.";


        }
        if(list.Count == 0) { // Status : You collected all items 
            gameStatusUI.gameStatusPanel.SetActive(true);
            gameStatusUI.statusText.text = "You collected all items here.";
            gameStatusUI.goBackFishingButton.SetActive(false);

            FishingGameManager.Instance.FishesCollected();
        }
    }
}
