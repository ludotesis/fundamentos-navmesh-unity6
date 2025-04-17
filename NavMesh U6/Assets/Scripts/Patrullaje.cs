using UnityEngine;
using UnityEngine.AI;

public class Patrullaje : MonoBehaviour
{
    [SerializeField] private Transform[] puntos;
    
    private int indiceActual = 0;
    private NavMeshAgent agente;  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();

        if (puntos.Length > 0)
        {
            IrAlPuntoActual();
        }
        
    }
    void Update()
    {
        if (!agente.pathPending && agente.remainingDistance < 0.2f)
        {
            AvanzarAlSiguientePunto();
        }
    }
    
    void IrAlPuntoActual()
    {
        agente.SetDestination(puntos[indiceActual].position);
    }

    void AvanzarAlSiguientePunto()
    {
        indiceActual = (indiceActual + 1) % puntos.Length;
        IrAlPuntoActual();
    }
}
