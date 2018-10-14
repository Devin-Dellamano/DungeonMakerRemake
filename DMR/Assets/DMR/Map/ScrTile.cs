using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrTile : MonoBehaviour
{
    private ScrGrid gridReference;
    public int[] gridCoord;

    private void Awake()
    {
        gridReference = GameObject.Find("Map").GetComponent<ScrGrid>();
    }

    public ScrTile[] GetNeighbors()
    {
       return gridReference.GetNeighbors(gridCoord[0], gridCoord[1]);
    }
}
