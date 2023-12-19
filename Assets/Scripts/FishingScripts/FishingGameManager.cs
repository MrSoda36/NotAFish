using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class FishingGameManager : MonoBehaviour
{
  
    public static FishingGameManager Instance { get; private set; }

    public void Awake() {
        if(Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        
    }



    public string fishingSceneName;
    public bool isFishCaught;

    public bool allBeachFishesCollected;
    public bool allForestFishesCollected;
    public bool allCaveFishesCollected;

    public bool allFishesCollected;


    // D�marrer le jeu
    public void LaunchFishingGame() {

        fishingSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("HookMiniGame");
    }

    // jeu termin� avec Poisson attrap�
    public void FishingGameWon() {

        isFishCaught= true;
        SceneManager.LoadScene(fishingSceneName);
    }

    // jeu termin� avec poisson rat�
    public void FishingGameLost() {

        SceneManager.LoadScene(fishingSceneName);
    }

    public void FishesCollected() {
        switch (fishingSceneName) {
            case "Beach":
                allBeachFishesCollected = true;
                break;

            /* case "Forest":
                allForestFishesCollected = true;
                break;

            case "Cave":
                allCaveFishesCollected = true;
                break; */
        }

        if (allBeachFishesCollected /* && allForestFishesCollected && allCaveFishesCollected */) {

            allFishesCollected = true;
        }
    }
}
