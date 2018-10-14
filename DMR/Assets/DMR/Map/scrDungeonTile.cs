using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrDungeonTile : ScrTile {

    public enum TileType { NORMAL = 0, TRAP, ALTAR, ERROR, NUMTYPES}
    public TileType currTileType;

    public Sprite[] tileSprites;

	// Use this for initialization
	void Start () {
        InitializeTile();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitializeTile()
    {
        InitializeSprite();
    }

    private void InitializeSprite()
    {
        currTileType = (TileType)Random.Range(0, (int)TileType.NUMTYPES - 1);
        GetComponent<SpriteRenderer>().sprite = tileSprites[(int)currTileType];
    }
}
