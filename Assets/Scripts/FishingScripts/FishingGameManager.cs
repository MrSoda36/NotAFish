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


    // D�marrer le jeu
    public void LaunchFishingGame() {

        // M�thode pour faire appara�tre le poisson cach�
        // M�thode pour faire appar�tre les obstacles
        hookBehaviour.GoBackAtTop();
        // M�thode pour d�finir l'objet a attraper

        fishingGameCanvas.SetActive(true);
    }

    // Poisson attrap� ou rat� -> Fin du jeu
    public void FishingGameEnded() {


        fishingGameCanvas.SetActive(false);
        // faut savoir dans quel point d'eau le joueur se situe

    }
}
