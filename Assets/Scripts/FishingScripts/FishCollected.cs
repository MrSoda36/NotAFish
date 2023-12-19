using System.Collections.Generic;
using UnityEngine;

public class FishCollected : MonoBehaviour
{

    public GameStatusUI gameStatusUI;


    public void CheckFishCollected(List<FishScriptableObjects> list) {
        if(list.Count == 2) { // Status : You collected enough items access to next level
            gameStatusUI.gameStatusPanel.SetActive(true);
            gameStatusUI.statusText.text = "You have collected enough items! \n You can have an access to the next level now!";


        }
        if(list.Count == 0) { // Status : You collected all items 
            gameStatusUI.gameStatusPanel.SetActive(true);
            gameStatusUI.statusText.text = "You have collected all items here, congrats!";
            gameStatusUI.goBackFishingButton.SetActive(false);

            FishingGameManager.Instance.FishesCollected();
        }
    }
}
