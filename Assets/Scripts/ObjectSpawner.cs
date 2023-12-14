using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{   
    public GameObject[] obstacleLine1;
    public GameObject[] obstacleLine2;

    List<GameObject> activeObstacles1;
    List<GameObject> activeObstacles2;

    void Start() {
        DesactivateAllObstacles();
        SpawnObstacleLines(1);
        SpawnObstacleLines(2);
    }

    void Update() {
        if (Input.GetKeyUp(KeyCode.T)) {
            SpawnObstacleLines(1);
            SpawnObstacleLines(2);
        }
        if(Input.GetKeyUp(KeyCode.Y)) {
            DesactivateAllObstacles();
        }
    }
    
    void SpawnObstacleLines(int lineIndex) {
        if(lineIndex == 1) {
            int obstacleSpawned = 0;
            while (obstacleSpawned != 3) {
                int randomIndex = Random.Range(0, obstacleLine1.Length);
                if (obstacleLine1[randomIndex].activeInHierarchy) {
                    return;
                }
                obstacleLine1[randomIndex].SetActive(true);
                obstacleSpawned++;
                Debug.Log("Spawned obstacle " + randomIndex);
            }
        }
        if(lineIndex == 2) {
            int obstacleSpawned = 0;
            while (obstacleSpawned != 3) {
                int randomIndex = Random.Range(0, obstacleLine2.Length);
                if (obstacleLine2[randomIndex].activeInHierarchy) {
                    return;
                }
                obstacleLine2[randomIndex].SetActive(true);
                obstacleSpawned++;
                Debug.Log("Spawned obstacle " + randomIndex);
            }
        }

             
    }

    private void DesactivateAllObstacles() {
        for(int i = 0; i < obstacleLine1.Length; i++) {
            obstacleLine1[i].SetActive(false);
        }
        for(int i = 0; i < obstacleLine2.Length; i++) {
            obstacleLine2[i].SetActive(false);
        }
    }
}
