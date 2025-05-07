using System;
using UnityEngine;

public class Meta : MonoBehaviour
{
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material defaultMaterial;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("GANASTE");
            GetComponent<Renderer>().material = winMaterial;
            Invoke("ResetMaterial", 2);
        }
    }
    void ResetMaterial()
    {
        GetComponent<Renderer>().material = defaultMaterial;
    }
}
