using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    [SerializeField] private float timeEffect;
    [SerializeField] private float timeGlowLight;

    [Header("Material Effects")]
    [SerializeField] private float timeToLoseLight;
    [SerializeField] private float innerLightQuantityOn;
    [SerializeField] private float innerLightQuantityOff;

    [SerializeField] private TileCreator tileCreator;

    [SerializeField] private bool charged;

    [SerializeField] private MeshRenderer meshMaterial;

    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = meshMaterial.material;
    }



    public void AbsorbLight()
    {
        StartCoroutine(GainLight());
        charged = true;
    }


    IEnumerator LoseLight()
    {
        float actualInnerLight = mat.GetFloat("_InnerLightTightness");

        while (actualInnerLight < innerLightQuantityOff)
        {
            Debug.Log("innerlight: " + actualInnerLight);
            actualInnerLight += (innerLightQuantityOff - innerLightQuantityOn) / timeToLoseLight * Time.deltaTime;
            mat.SetFloat("_InnerLightTightness", actualInnerLight);
            yield return null;
        }
    }

    IEnumerator GainLight()
    {
        float actualInnerLight = mat.GetFloat("_InnerLightTightness");

        while (actualInnerLight > innerLightQuantityOn)
        {
            Debug.Log("innerlight: " + actualInnerLight);
            actualInnerLight -= (innerLightQuantityOff - innerLightQuantityOn) / timeToLoseLight * Time.deltaTime;
            mat.SetFloat("_InnerLightTightness", actualInnerLight);
            yield return null;
        }
    }
}
