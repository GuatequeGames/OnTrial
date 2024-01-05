using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [SerializeField] private int rows;
    [SerializeField] private int columns;
    [SerializeField] private GameObject TilePrefab;
    [SerializeField] private float size;
    // Start is called before the first frame update
    void Start()
    {


        for(int i = 0; i<rows; i++)
        {
            for(int j = 0; j<columns; j++)
            {
                Vector3 position = new Vector3(size * j, 0, size * i);
                Instantiate(TilePrefab, position, Quaternion.identity,transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
