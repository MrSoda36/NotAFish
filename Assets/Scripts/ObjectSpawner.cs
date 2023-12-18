using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{   
    public GameObject[] obstacleLine1;
    public GameObject[] obstacleLine2;

    public int difficulty = 1;
    int objectToSpawn = 0;

    void Start() {
        DesactivateAllObstacles();
        SetupDifficulty();
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

    void SetupDifficulty() {
        
        switch (FishingGameManager.Instance.fishingSceneName)
        {
            case "Beach":
                difficulty = 1;
                break;
            case "Forest":
                difficulty = 2;
                break;
            case "Cave":
                difficulty = 3;
                break;
        }
        objectToSpawn = 2 + difficulty;
    }
    
    void SpawnObstacleLines(int lineIndex) {
        if(lineIndex == 1) {
            int obstacleSpawned = 0;
            while (obstacleSpawned != objectToSpawn) {
                int randomIndex = Random.Range(0, obstacleLine1.Length);
                while (obstacleLine1[randomIndex].activeInHierarchy) {
                    randomIndex = Random.Range(0, obstacleLine1.Length);
                }
                obstacleLine1[randomIndex].SetActive(true);
                obstacleSpawned++;
            }
            Debug.Log("Spawned all " + objectToSpawn + " obstacles in Line 1");
        }
        if(lineIndex == 2) {
            int obstacleSpawned = 0;
            while (obstacleSpawned != objectToSpawn) {
                int randomIndex = Random.Range(0, obstacleLine2.Length);
                while (obstacleLine2[randomIndex].activeInHierarchy) {
                    randomIndex = Random.Range(0, obstacleLine2.Length);
                }
                obstacleLine2[randomIndex].SetActive(true);
                obstacleSpawned++;
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
