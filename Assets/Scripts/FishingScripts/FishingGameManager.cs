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



    public string fishingSceneName;
    public bool isFishCaught;

    public int levelUnlocked = 1;

    // Démarrer le jeu
    public void LaunchFishingGame() {

        fishingSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("HookMiniGame");
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

    public void UnlockNewLevel() {

        switch(levelUnlocked)
        {
            case 2: // Niveau 2 unlocked

                break;
            case 3: // Niveau 3 Unlocked

                break;
            case 4: // Last Level Unlocked

                break;
        }
    }
}
