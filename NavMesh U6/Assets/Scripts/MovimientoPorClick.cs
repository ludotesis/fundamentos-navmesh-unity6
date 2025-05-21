using UnityEngine;
using UnityEngine.AI;

public class MovimientoPorClick : MonoBehaviour
{
    private NavMeshAgent agente;

    [SerializeField]
    [Range(3f, 20f)] 
    private float factorRotacion = 5f; 
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.updateRotation = false;
        agente.angularSpeed = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(rayo, out RaycastHit impacto))
            {
                agente.SetDestination(impacto.point);
            }
        }

        ActualizarRotacionManual();
    }

    void ActualizarRotacionManual()
    {
        if (agente.remainingDistance > agente.stoppingDistance && agente.velocity.magnitude > 0.1f)
        {
            Vector3 direccion = agente.velocity.normalized;
            Quaternion rotacionDeseada = Quaternion.LookRotation(direccion);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionDeseada, Time.deltaTime * factorRotacion);
        }
    }
}
