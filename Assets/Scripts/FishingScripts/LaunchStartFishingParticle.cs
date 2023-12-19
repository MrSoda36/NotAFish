using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchStartFishingParticle : MonoBehaviour
{
    public Startfishing startfishing;

    public void LaunchParticleEffect()
    {
        startfishing.PlayParticles();
        StartCoroutine(StartGame(1));
        
    }
   
    IEnumerator StartGame(int i)
    {
        yield return new WaitForSeconds(i);
        FishingGameManager.Instance.LaunchFishingGame();
    }
}
