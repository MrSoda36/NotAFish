using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{   
    public GameObject[] obstacleLine1;
    public GameObject[] obstacleLine2;

    List<GameObject> activeObstacles1;
    List<GameObject> activeObstacles2;

    public int difficulty = 1;
    int objectToSpawn = 0;

    void Start() {
        DesactivateAllObstacles();
        SetupDifficulty(difficulty);
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

    void SetupDifficulty(int newDifficulty) {
        difficulty = newDifficulty;
        objectToSpawn = 2 + difficulty;
    }
    
    void SpawnObstacleLines(int lineIndex) {
        if(lineIndex == 1) {
            int obstacleSpawned = 0;
            while (obstacleSpawned != objectToSpawn) {
                int randomIndex = Random.Range(0, obstacleLine1.Length);
                while (obstacleLine1[randomIndex].activeInHierarchy) {
                    Debug.Log("Obstacle " + randomIndex + " already active in Line 1");
                }
                obstacleLine1[randomIndex].SetActive(true);
                obstacleSpawned++;
                Debug.Log("Spawned " + obstacleSpawned + " obstacles in Line 1");
            }
            Debug.Log("Spawned all " + objectToSpawn + " obstacles in Line 1");
        }
        if(lineIndex == 2) {
            int obstacleSpawned = 0;
            while (obstacleSpawned != objectToSpawn) {
                int randomIndex = Random.Range(0, obstacleLine2.Length);
                while (obstacleLine2[randomIndex].activeInHierarchy) {
                    Debug.Log("Obstacle " + randomIndex + " already active in Line 2");
                }
                obstacleLine2[randomIndex].SetActive(true);
                obstacleSpawned++;
                Debug.Log("Spawned " + obstacleSpawned + " obstacles in Line 2");
            }
            Debug.Log("Spawned all " + objectToSpawn + " obstacles in Line 2");
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
