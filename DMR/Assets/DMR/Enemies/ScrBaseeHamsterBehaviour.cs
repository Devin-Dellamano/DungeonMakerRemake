using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScrBaseeHamsterBehaviour : MonoBehaviour {

    private NavMeshAgent agent;
    private ScrTile nextTile;
	
	// Update is called once per frame
	void Update () {
        if (nextTile != null)
        {
            CheckTravelProgress();
        }	
	}

    public void InitializeHamster(ScrTile _destinationTile)
    {
        nextTile = _destinationTile;
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(nextTile.transform.position);
    }

    private void CheckTravelProgress()
    {
        Vector3 toNextTile = nextTile.transform.position - transform.position;
        float distance = toNextTile.magnitude;
        float distanceSqr = distance * distance;

        if (distanceSqr <= 1)
        {
            if (nextTile.name == "Boss Tile")
            {
                Destroy(gameObject);
            }
            else
            {
                GoToNextTile();
            }
        }
    }

    private void GoToNextTile()
    {
        ScrTile[] neighbors = nextTile.GetNeighbors();

        foreach (ScrTile tile in neighbors)
        {
            if (tile.name == "Boss Tile")
            {
                nextTile = tile;
                agent.SetDestination(nextTile.transform.position);
                return;
            }
        }

        nextTile = GetRandomNeighborWeighted(neighbors);
        agent.SetDestination(nextTile.transform.position);
    }

    private ScrTile GetRandomNeighborWeighted(ScrTile[] _neighbors)
    {
        float frontWeight = 55.0f;
        float sideWeight = 30.0f;
        float backWeight = 15.0f;

        do
        {
            ScrTile randomNeighbor = _neighbors[Random.Range(0, _neighbors.Length)];

            float randomValue = Random.Range(0.0f, 100.0f);
            int randNeighborGridX = randomNeighbor.gridCoord[0];
            if (randNeighborGridX < nextTile.gridCoord[0]) //Check if neighbor is in front
            {
                if (randomValue <= frontWeight)
                {
                    return randomNeighbor;
                }
            }

            if (randNeighborGridX == nextTile.gridCoord[0]) //Check if neighbor is on side
            {
                if (randomValue <= sideWeight)
                {
                    return randomNeighbor;
                }
            }

            if (randNeighborGridX > nextTile.gridCoord[0]) //Check if neighbor is in back
            {
                if (randomValue <= backWeight)
                {
                    return randomNeighbor;
                }
            }
        } while (true);
    }
}

