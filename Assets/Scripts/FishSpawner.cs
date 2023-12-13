using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fish;

    void Start() {
        StartCoroutine(SpawnFish());
    }

    IEnumerator SpawnFish() {
        while(true) {
            yield return new WaitForSeconds(Random.Range(1, 3));
            Instantiate(fish);
            fish.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 0, 0);
        }
    }
}
