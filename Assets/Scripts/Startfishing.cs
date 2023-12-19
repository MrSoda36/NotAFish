using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startfishing : MonoBehaviour
{
    public ParticleSystem bubble;

    public void PlayParticles()
    {
        bubble.Play();
    }
}
