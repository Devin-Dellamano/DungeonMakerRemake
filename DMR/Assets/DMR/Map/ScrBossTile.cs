using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrBossTile : ScrTile {

    private ScrTile[,] dungeonTileGrid;
    public int gridWidth;
    public int gridHeight;

	// Use this for initialization
	void Start () {
        InitializeGrid();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitializeGrid()
    {
        dungeonTileGrid = new ScrTile[gridWidth, gridHeight];
        dungeonTileGrid[(int)gridPosition.x, (int)gridPosition.y] = this;
    }
}
