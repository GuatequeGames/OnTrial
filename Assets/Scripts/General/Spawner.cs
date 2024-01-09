using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    //Debe haber referencia a lo que se iluminará -> una luz con una animación


    [SerializeField] private Transform transformSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetTransformSpawn()
    {
        return transformSpawn;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.Instance.SetActiveSpawner(this);
        }
    }
}
