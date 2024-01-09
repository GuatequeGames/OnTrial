using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{

    [SerializeField] private Transform playerCamera;

    [SerializeField] private LayerMask layers;
    [SerializeField] private float distanceToInteract;

    InputAction interactAction;

    private void Awake()
    {
        interactAction = InputManager.Instance.GetPlayerInput().actions["Interact"];
    }
    void Start()
    {
        interactAction.performed += Interact;
    }

    void Update()
    {


    }


    public void Interact(InputAction.CallbackContext ctx)
    {

        RaycastHit hit;
        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out hit, distanceToInteract, layers))
        {
            Activator _activator = hit.transform.gameObject.GetComponent<Activator>();
            if (_activator != null) _activator.Activate();
            Debug.Log("hit: " + hit.transform.gameObject.name);
        }

    }
}
