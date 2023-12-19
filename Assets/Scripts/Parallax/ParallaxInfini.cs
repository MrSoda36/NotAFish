using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxInfini : MonoBehaviour
{
    private float length, startpos;
    public GameObject Cam;
    public float parallaxEffect; // Valeur servant comme t�moin du Parallax vis-�-vis de la cam�ra
    

    void Start()
    {
        // R�cup�re au d�part la position x de la Cam�ra et sa taille 
        startpos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y;

    }

    void Update()
    {
        float temp = Cam.transform.position.y * (1 - parallaxEffect); // Calcule la distance parcourue par rapport � la cam�ra
        float dist = Cam.transform.position.y * parallaxEffect; // Mesure la distance parcourue par la cam�ra multipli� par l'effet de Parallax
        transform.position = new Vector3 (transform.position.x, startpos + dist, transform.position.z);

        // Permet le Parallax infini en ajoutant le background manquant pour �viter de se retrouver avec le fond de sc�ne visible
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
