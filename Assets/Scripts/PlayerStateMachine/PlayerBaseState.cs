using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState : MonoBehaviour
{

    public abstract void OnEnterState(PlayerStateManager state);

    public abstract void OnUpdateState(PlayerStateManager state);
    
    public abstract void OnExitState(PlayerStateManager state);

    public abstract void CollisionEnter(PlayerStateManager state, Collision2D collision2D);

    public abstract void CollisionExit(PlayerStateManager state, Collider2D collision2D);
}
