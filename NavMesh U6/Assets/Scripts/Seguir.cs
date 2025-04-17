using UnityEngine;
using UnityEngine.AI;

public class Seguir : MonoBehaviour
{
    [SerializeField]
    private Transform objetivo;
    
    [SerializeField]
    private float rangoDeSeguimiento = 5f; 
    
    private NavMeshAgent agente;
    private Vector3 ultimaPosicionObjetivo; 
    
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();

        if (objetivo != null)
        {
            ultimaPosicionObjetivo = objetivo.position;
        }
    }
    
    void Update()
    {
        if (objetivo == null) return;
        
        float distancia = Vector3.Distance(transform.position, objetivo.position);

        if (distancia <= rangoDeSeguimiento)
        {
            if (Vector3.Distance(ultimaPosicionObjetivo, objetivo.position) > 0.1f)
            {
                ultimaPosicionObjetivo = objetivo.position;
                agente.SetDestination(objetivo.position);
            }else if (!agente.isStopped)
            {
                agente.ResetPath();
            }
        }
    }
}
