using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    public GameObject fishingGameCanvas;

    public HookBehaviour hookBehaviour;


    // Démarrer le jeu
    public void LaunchFishingGame() {

        // Méthode pour faire apparaître le poisson caché
        // Méthode pour faire apparître les obstacles
        hookBehaviour.GoBackAtTop();
        // Méthode pour définir l'objet a attraper

        fishingGameCanvas.SetActive(true);
    }

    // Poisson attrapé ou raté -> Fin du jeu
    public void FishingGameEnded() {


        fishingGameCanvas.SetActive(false);
        // faut savoir dans quel point d'eau le joueur se situe

    }
}
