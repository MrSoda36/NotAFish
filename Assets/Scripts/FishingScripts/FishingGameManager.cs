using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FishingGameManager : MonoBehaviour
{
  
    private static FishingGameManager _instance;
    public static FishingGameManager Instance {
        get {
            if (_instance == null) { 
                Debug.Log("FishingGameManager is null"); 
            }
            return _instance;
        } 
    }

    private void Awake() {
        DontDestroyOnLoad(this);
        _instance = this;
    }



    public FishCaught fishCaught;
    public string fishingSceneName;


    // Démarrer le jeu
    public void LaunchFishingGame() {

        fishingSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("HookMiniGame");
    }

    // jeu terminé avec Poisson attrapé
    public void FishingGameWon() {

        SceneManager.LoadScene(fishingSceneName);
        int index = 0;

        switch (fishingSceneName)
        {
            case "Beach":

                index = Random.Range(0, FishingObjectsList.Instance.oceanObjects.Count - 1);
                fishCaught.PrintFishCaught(FishingObjectsList.Instance.oceanObjects[index]);

                FishingObjectsList.Instance.oceanObjects.Remove(FishingObjectsList.Instance.oceanObjects[index]);
                break;
            case "Forest":

                index = Random.Range(0, FishingObjectsList.Instance.poundObjects.Count - 1);
                fishCaught.PrintFishCaught(FishingObjectsList.Instance.poundObjects[index]);

                FishingObjectsList.Instance.poundObjects.Remove(FishingObjectsList.Instance.poundObjects[index]);
                break;
            case "Cave":

                index = Random.Range(0, FishingObjectsList.Instance.caveRiverObjects.Count - 1);
                fishCaught.PrintFishCaught(FishingObjectsList.Instance.caveRiverObjects[index]);

                FishingObjectsList.Instance.caveRiverObjects.Remove(FishingObjectsList.Instance.caveRiverObjects[index]);
                break;
        }
    }

    // jeu terminé avec poisson raté
    public void FishingGameLost() {

        SceneManager.LoadScene(fishingSceneName);
    }
}
