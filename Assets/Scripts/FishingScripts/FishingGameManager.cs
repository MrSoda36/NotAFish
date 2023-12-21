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
    public int wallHit;

    public bool isFishCaught;
    public bool allBeachFishesCollected;
    public bool allFishesCollected;


    // Démarrer le jeu
    public void LaunchFishingGame() {

        fishingSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("HookMiniGame");
        wallHit = 0;
    }

    // jeu terminé avec Poisson attrapé
    public void FishingGameWon() {

        isFishCaught= true;
        SceneManager.LoadScene(fishingSceneName);
    }

    // jeu terminé avec poisson raté
    public void FishingGameLost() {

        SceneManager.LoadScene(fishingSceneName);
    }

    public void FishesCollected() {
        allBeachFishesCollected = true;

        // Pour future compatibilité pour de futurs niveaux
        if (allBeachFishesCollected) {

            allFishesCollected = true;
        }
    }
}
