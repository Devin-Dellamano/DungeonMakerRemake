using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrHamsterSpawnTile : ScrTile {

    public GameObject[] hamsters;
    public float spawnDelay;
    private float spawnTimer;
    public int maxHamsterToSpawn;
    private int spawnCount;

	// Use this for initialization
	void Start () {

        spawnTimer = 0.0f;
        spawnCount = 0;
	}
	
	// Update is called once per frame
	void Update () {

        if (spawnCount < maxHamsterToSpawn)
        {
            if (spawnTimer >= spawnDelay)
            {
                spawnTimer = 0.0f;
                SpawnHamster();
            }
            else
            {
                spawnTimer += Time.deltaTime;
            }
        }
	}

    private void SpawnHamster()
    {
        GameObject randomHamster = hamsters[Random.Range(0, hamsters.Length)];
        randomHamster = Instantiate(randomHamster, transform.position, randomHamster.transform.rotation);

        ScrTile[] neighbors = GetNeighbors();
        randomHamster.GetComponent<ScrBaseeHamsterBehaviour>().InitializeHamster(neighbors[0]);

        spawnCount++;
    }
}
