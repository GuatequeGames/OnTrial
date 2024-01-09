using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private Spawner activeSpawner;

    public static GameManager Instance;


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
        }

        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetActiveSpawner(Spawner _spawner)
    {
        activeSpawner = _spawner;
    }

    public Spawner GetActiveSpawner()
    {
        return activeSpawner;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
