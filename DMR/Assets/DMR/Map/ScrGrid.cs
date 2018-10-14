using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrGrid : MonoBehaviour {

    private ScrTile[,] dungeonTileGrid;
    public int gridWidth;
    public int gridHeight;

    public ScrBossTile bossTile;
    public ScrHamsterSpawnTile hamsterSpawnTile;
    public Transform dungeonTileRoot;

    // Use this for initialization
    void Start()
    {
        InitializeGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitializeGrid()
    {
        dungeonTileGrid = new ScrTile[gridWidth, gridHeight];

        dungeonTileGrid[bossTile.gridCoord[0], bossTile.gridCoord[1]] = bossTile;
        dungeonTileGrid[hamsterSpawnTile.gridCoord[0], hamsterSpawnTile.gridCoord[1]] = hamsterSpawnTile;

        foreach (Transform dungeonTile in dungeonTileRoot)
        {
            ScrDungeonTile dTile = dungeonTile.GetComponent<ScrDungeonTile>();
            dungeonTileGrid[dTile.gridCoord[0], dTile.gridCoord[1]] = dTile;
        }
    }

    public ScrTile[] GetNeighbors(int xGridCoord, int yGridCoord)
    {
        List<ScrTile> neighbors = new List<ScrTile>();
        ScrTile tempTile = null;

        if (xGridCoord + 1 < gridWidth)
        {
            tempTile = dungeonTileGrid[xGridCoord + 1, yGridCoord];
            if ( tempTile != null)
            {
                if (tempTile.tag != "Blocked Tile")
                {
                    neighbors.Add(tempTile);
                }
            }
        }

        if (xGridCoord - 1 > -1)
        {
            tempTile = dungeonTileGrid[xGridCoord - 1, yGridCoord];
            if (tempTile != null)
            {
                if (tempTile.tag != "Blocked Tile")
                {
                    neighbors.Add(tempTile);
                }
            }
        }

        if (yGridCoord + 1 < gridHeight)
        {
            tempTile = dungeonTileGrid[xGridCoord, yGridCoord + 1];
            if (tempTile != null)
            {
                if (tempTile.tag != "Blocked Tile")
                {
                    neighbors.Add(tempTile);
                }
            }
        }

        if (yGridCoord - 1 > -1)
        {
            tempTile = dungeonTileGrid[xGridCoord, yGridCoord - 1];
            if (tempTile != null)
            {
                if (tempTile.tag != "Blocked Tile")
                {
                    neighbors.Add(tempTile);
                }
            }
        }

        return neighbors.ToArray();
    }
} 
