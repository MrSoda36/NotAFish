using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startfishing : MonoBehaviour
{
    public ParticleSystem bubble;
    public Animator fishingRodAnimation;
    public Animator hookAnimation;

    public void Start()
    {
        fishingRodAnimation.GetComponent<Animation>();
        hookAnimation.GetComponent<Animation>();
    }
    public void PlayParticles()
    {
        bubble.Play();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fishingRodAnimation.SetTrigger("TriggerFishingRod");
            hookAnimation.SetTrigger("TriggerHook");

        }
    }
}
