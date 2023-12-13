using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject fish;
    public GameObject obstacle;

    void Start() {
        StartCoroutine(SpawnObstacle());
    }

    IEnumerator SpawnObstacle() {
        while(true) {
            yield return new WaitForSeconds(Random.Range(1, 3));
            Instantiate(obstacle);
            obstacle.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 0, 0);
        }
    }
}
