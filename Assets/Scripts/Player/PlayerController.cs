using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    bool hasFish;
    [SerializeField] FishBehaviour fish;

    [SerializeField] GameObject minigame; 

    private void Start()                  
    {                                     
        minigame.SetActive(false);       
    }                                     

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.UpArrow)) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.DownArrow)) {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) /* && check si on est devant un point d'eau */ ) {
            if(!hasFish) {
                StartCoroutine(LaunchFishingRod());
                // lancer une animation de pêche
            }
            else {
                // lancer le jeu de pêche
                minigame.SetActive(true); 
                hasFish = false;
            }

           

        }

        /*if (hasFish)
        {
            if (Input.GetKeyDown(KeyCode.Space)) {
                Debug.Log("Fish caught: " + fish.fishName);
                hasFish = false;
                StopAllCoroutines();
            }
        }*/
    }

    IEnumerator LaunchFishingRod() { // Remplacer ça par l'animation
        Debug.Log("Fishing rod launched");
        yield return new WaitForSeconds(Random.Range(1,3));
        hasFish = true;
        Debug.Log("IT'S A FISH");
        StartCoroutine(TimeToCatch());
        
        
    }

    IEnumerator TimeToCatch() { // Si le joueur ne réagit pas assez vite, le poisson commence à s'enfuir
        if (minigame.activeSelf) {
            StopCoroutine(TimeToCatch());
        }
        else {
            yield return new WaitForSeconds(5);
            Debug.Log("Le poisson s'est enfui");
        }

        
    }
}
