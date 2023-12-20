using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchStartFishingParticle : MonoBehaviour
{
    public Startfishing startfishing;
    public Animator transitionAnim;

    public void LaunchParticleEffect() {
        startfishing.PlayParticles();
        StartCoroutine(StartGame(1));
        
    }
   
    IEnumerator StartGame(int i) {
        transitionAnim.SetTrigger("EnterScene");
        yield return new WaitForSeconds(i);
        FishingGameManager.Instance.LaunchFishingGame();
    }
}
