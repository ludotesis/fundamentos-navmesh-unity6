using System;
using UnityEngine;

public class Meta : MonoBehaviour
{
    [SerializeField] private Material winMaterial;
    [SerializeField] private Material defaultMaterial;
    [SerializeField] private AudioManager audioManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("GANASTE");
            GetComponent<Renderer>().material = winMaterial;
            audioManager.TriggerWinSFX();
            Invoke(nameof(ResetMaterial), 2);
        }
    }
    void ResetMaterial()
    {
        GetComponent<Renderer>().material = defaultMaterial;
    }
}
