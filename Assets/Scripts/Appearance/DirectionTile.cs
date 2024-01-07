using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionTile : MonoBehaviour
{

    [SerializeField] private List<Transform> listPositions;
    [SerializeField] private List<Orientation> listOrientations;
    [SerializeField] private int currentIndex;


    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovingBox>() == null) return;

        other.GetComponent<MovingBox>().SetNextPosition(listPositions[currentIndex]);
    }







}

public enum Orientation
{
    North,
    South,
    East,
    West
}
