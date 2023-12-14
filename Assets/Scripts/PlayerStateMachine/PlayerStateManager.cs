using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : MonoBehaviour
{
    PlayerBaseState currentState;

    public PlayerMovingState movingState = new PlayerMovingState();
    public PlayerNearWaterState nearWaterState = new PlayerNearWaterState();
    public PlayerFishingState fishingState = new PlayerFishingState();



    void Start() {

        currentState = movingState;
        currentState.OnEnterState(this);
    }

    void Update() {
        
        currentState.OnUpdateState(this);
    }

    public void OnCollisionEnter2D(Collision2D collision2D)
    {
        currentState.CollisionEnter(this, collision2D);
    }

    public void SwitchState(PlayerBaseState state) {

        currentState.OnExitState(this);

        currentState = state;
        currentState.OnEnterState(this);

    }
}
