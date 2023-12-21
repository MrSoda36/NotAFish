using System.Collections;
using UnityEngine;

public class LaunchStartFishingParticle : MonoBehaviour
{
    public Startfishing startfishing;
    public Animator transitionAnim;

    [Header("Audio")]
    [SerializeField] AudioClip pouicClip;
    [SerializeField] AudioClip splashClip;
    [SerializeField] AudioClip ambientWavesClip;

    private void Start()
    {
        SoundManager.SoundInstance.PlayAmbiantSound(ambientWavesClip);
    }


    public void LaunchParticleEffect() {
        startfishing.PlayParticles();
        StartCoroutine(StartGame(1));
        
    }
   
    IEnumerator StartGame(int i) {
        SoundManager.SoundInstance.PlaySound(pouicClip);
        SoundManager.SoundInstance.PlaySound(splashClip);
        transitionAnim.SetTrigger("EnterScene");
        yield return new WaitForSeconds(i);
        FishingGameManager.Instance.LaunchFishingGame();
    }
}
