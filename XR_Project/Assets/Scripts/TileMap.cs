using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour
{

    public GameObject tile;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int k = 0; k < 10; k++)
            {
                GameObject temp = (GameObject)Instantiate(tile);
                temp.transform.position = new Vector3(i, 0, k);
            }
        }

    }


}
