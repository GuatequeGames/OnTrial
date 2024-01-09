using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Activator : MonoBehaviour
{
    [SerializeField] private UnityEvent eventsToActivate;


    

    public void Activate()
    {
        eventsToActivate.Invoke();
    }
}
