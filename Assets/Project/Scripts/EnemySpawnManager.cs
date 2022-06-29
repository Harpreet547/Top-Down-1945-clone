using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {

    public GameObject[] spawnPoints;
    public GameObject enemy;

    private bool isSpawnCoroutineRunning = false;

    void Awake() {
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        spawnPoints[0].transform.position = new Vector2(-screenBounds.x - (screenBounds.x / 2), 0);

        spawnPoints[1].transform.position = new Vector2(-screenBounds.x - (screenBounds.x / 2), screenBounds.y + screenBounds.y / 2);

        spawnPoints[2].transform.position = new Vector2(screenBounds.x + (screenBounds.x / 2), screenBounds.y + screenBounds.y / 2);
        
        spawnPoints[3].transform.position = new Vector2(screenBounds.x + (screenBounds.x / 2), 0);
    }

    void Update() {
        if(!isSpawnCoroutineRunning)
            StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy() {
        int randomEdge = Random.Range(1, 4);
        Vector2 point1;
        Vector2 point2;
        switch(randomEdge) {
            case 1:
                point1 = spawnPoints[0].transform.position;
                point2 = spawnPoints[0].transform.position - spawnPoints[1].transform.position;
                break;
            case 2:
                point1 = spawnPoints[1].transform.position;
                point2 = spawnPoints[1].transform.position - spawnPoints[2].transform.position;
                break;
            case 3:
                point1 = spawnPoints[2].transform.position;
                point2 = spawnPoints[2].transform.position - spawnPoints[3].transform.position;
                break;
            default:
                point1 = spawnPoints[0].transform.position;
                point2 = spawnPoints[0].transform.position - spawnPoints[1].transform.position;
                break;
        }
        Vector2 target = point1 - point2 * Random.value;
        Instantiate(enemy, target, transform.rotation);
        isSpawnCoroutineRunning = true;
        yield return new WaitForSeconds(2.0f);
        isSpawnCoroutineRunning = false;
    }

    private void OnDrawGizmos() {
        if(spawnPoints == null) return;
        for(int i = 0; i < spawnPoints.Length - 1; i++) {
            Debug.DrawLine(spawnPoints[i].transform.position, spawnPoints[i + 1].transform.position, Color.green);
        }
    }
}
