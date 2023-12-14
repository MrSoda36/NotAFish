using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFishingState : PlayerBaseState
{
    public bool hasHookedFish = false;

    public override void OnEnterState(PlayerStateManager state) {
        Debug.Log("Fishing State");
        // lancer l'animation de jet de l'hameçon
    }

    public override void OnUpdateState(PlayerStateManager state)
    {
        if(hasHookedFish && Input.GetKeyDown(KeyCode.Space)) { 

            FishingGameManager.Instance.LaunchFishingGame();
        }
    }

    public override void OnExitState(PlayerStateManager state)
    {
        hasHookedFish = false;

    }

    public override void CollisionEnter(PlayerStateManager state, Collision2D collision2D)
    { // aucune collision envisagée
    }

    public override void CollisionExit(PlayerStateManager state, Collider2D collision2D)
    { // aucune collision envisagée
    }


    public void HookedFish() {
        hasHookedFish = true;
    }
}

