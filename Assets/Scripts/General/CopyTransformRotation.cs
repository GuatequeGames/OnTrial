using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyTransformRotation : MonoBehaviour
{
    [SerializeField] Transform transformToCopy;

    private void Update()
    {
        transform.rotation = transformToCopy.rotation;
    }
}
