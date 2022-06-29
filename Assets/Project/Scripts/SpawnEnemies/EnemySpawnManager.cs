using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {

    public GameObject basicEnemyUnit;
    public float delayBetweenSpawns = 2.0f;

    private EnemySpawnArea enemySpawnArea;
    private bool isSpawning = false;

    void Start() {
        enemySpawnArea = GetComponentInChildren<EnemySpawnArea>();
    }

    void Update() {
        if(!isSpawning) {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy() {
        isSpawning = true;
        Vector2 spawnPoint = enemySpawnArea.GetSpawnPoint();
        GameObject enemy = Instantiate(basicEnemyUnit, spawnPoint, transform.rotation);
        Spawnable spawnable = enemy.GetComponent<Spawnable>();

        yield return new WaitForSeconds(delayBetweenSpawns + spawnable.secondsToCompleteSpawning);

        isSpawning = false;
    }
}
