using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxInfini : MonoBehaviour
{
    private float length, startpos;
    public GameObject Cam;
    public float parallaxEffect; // Valeur servant comme témoin du Parallax vis-à-vis de la caméra
    

    void Start()
    {
        // Récupère au départ la position x de la Caméra et sa taille 
        startpos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;

    }

    void Update()
    {
        float temp = Cam.transform.position.y * (1 - parallaxEffect); // Calcule la distance parcourue par rapport à la caméra
        float dist = Cam.transform.position.y * parallaxEffect; // Mesure la distance parcourue par la caméra multiplié par l'effet de Parallax
        transform.position = new Vector3 (transform.position.x, startpos + dist, transform.position.z);

        // Permet le Parallax infini en ajoutant le background manquant pour éviter de se retrouver avec le fond de scène visible
        if(temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
