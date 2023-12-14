using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNearWaterState : PlayerBaseState
{
    public bool canFish;
    public int speed;

    public override void OnEnterState(PlayerStateManager state) {
        Debug.Log("Fishing State");
        canFish = true;
    }

    public override void OnUpdateState(PlayerStateManager state)
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            state.SwitchState(state.fishingState);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;

        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;

        }

    }
    public override void OnExitState(PlayerStateManager state) {
        
        canFish = false;
    }

    public override void CollisionEnter(PlayerStateManager state, Collision2D collision2D) { 
        // Aucune collision à avoir avec cet état
    }
    

    public override void CollisionExit(PlayerStateManager state, Collider2D collision2D) {
        if(collision2D.tag != null /* tag de l'eau */) {
            state.SwitchState(state.movingState);
        }
    }
}
