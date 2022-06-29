using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMoveForwardEnemyUnit : MonoBehaviour, Spawnable {

    [Header("This component will spawn train of basic enemies")]
    [Header("Interval at which next enemy will be spawned")]
    public float spawnInterval = 1.5f;
    public int numberOfEnemiesToSpawn = 5;
    public GameObject prefab;
    public float secondsToCompleteSpawning { get; private set; }

    private bool isSpawning = false;
    private int enemiesSpawned = 0;

    private void Awake() {
        secondsToCompleteSpawning = numberOfEnemiesToSpawn * spawnInterval;
    }

    void Start() {
        GameObject player = GameManager.instance.GetPlayer();
        transform.rotation = Utils.instance.GetRotationAngleTowardsTarget(transform.position, player.transform.position);

    }

    void Update() {
        if(!isSpawning && enemiesSpawned < numberOfEnemiesToSpawn) {
            StartCoroutine(SpawnNextEnemy());
        }

        if(enemiesSpawned >= numberOfEnemiesToSpawn) {
            Destroy(gameObject);
        }
    }

    IEnumerator SpawnNextEnemy() {
        isSpawning = true;
        yield return new WaitForSeconds(spawnInterval);

        GameObject enemy = Instantiate(prefab, transform.position, transform.rotation);
        BasicMoveForwardEnemy basicMoveForwardEnemy = enemy.GetComponent<BasicMoveForwardEnemy>();
        basicMoveForwardEnemy.isRotationUpdated = true;
        enemiesSpawned++;
        isSpawning = false;
    }
}
