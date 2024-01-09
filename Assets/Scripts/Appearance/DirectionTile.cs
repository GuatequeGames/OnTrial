using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionTile : MonoBehaviour
{

    [SerializeField] private List<Transform> listPositions;
    [SerializeField] private List<float> listRotations;
    [SerializeField] private int currentIndex;


    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MovingBox>() == null) return;

        other.GetComponent<MovingBox>().SetNextPosition(listPositions[currentIndex]);
    }


    public void Rotate()
    {
        currentIndex = (currentIndex + 1) % listPositions.Count;
        Vector3 rotation = new Vector3(transform.rotation.eulerAngles.x, listRotations[currentIndex], transform.rotation.eulerAngles.z);
        transform.rotation = Quaternion.Euler(rotation);
    }




}

public enum Orientation
{
    North,
    South,
    East,
    West
}
