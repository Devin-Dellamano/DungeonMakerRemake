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

        nextTile = neighbors[Random.Range(0, neighbors.Length)];
        agent.SetDestination(nextTile.transform.position);
    }
}

