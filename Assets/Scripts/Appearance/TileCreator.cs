using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCreator : MonoBehaviour
{
    [SerializeField] private bool isActive;
    [SerializeField] private Vector3 initialPos;
    [SerializeField] private Vector3 desactivePos;


    private void Start()
    {
        initialPos = transform.position;
        desactivePos = transform.position + Vector3.up * 10;

        if (!isActive) SetActive(false);
    }
    public void SetActive(bool _active)
    {
        isActive = _active;
        if (isActive)
        {
            transform.position = initialPos;
        }
        else
        {
            transform.position = desactivePos;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
