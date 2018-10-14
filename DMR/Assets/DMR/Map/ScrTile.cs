using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrTile : MonoBehaviour
{
    public ScrGrid gridReference;
    public int[] gridCoord;

    private void Awake()
    {
        gridReference = GameObject.Find("Map").GetComponent<ScrGrid>();
    }
}
