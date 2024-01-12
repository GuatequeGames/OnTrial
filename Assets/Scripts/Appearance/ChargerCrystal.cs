using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChargerCrystal : MonoBehaviour
{
    [SerializeField] private float timeToLoseLight;
    [SerializeField] private float innerLightQuantityOn;
    [SerializeField] private float innerLightQuantityOff;
    [SerializeField] private MeshRenderer meshMaterial;

    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = meshMaterial.material;
    }


    IEnumerator LoseLight()
    {
        float actualInnerLight = mat.GetFloat("_InnerLightTightness");

        while(actualInnerLight < innerLightQuantityOff)
        {
            Debug.Log("innerlight: " + actualInnerLight);
            actualInnerLight += (innerLightQuantityOff - innerLightQuantityOn) / timeToLoseLight * Time.deltaTime;
            mat.SetFloat("_InnerLightTightness", actualInnerLight);
            yield return null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Crystal _crystal = other.GetComponent<Crystal>();
        if (_crystal == null) return;

        _crystal.AbsorbLight();
        StartCoroutine(LoseLight());
    }
}
