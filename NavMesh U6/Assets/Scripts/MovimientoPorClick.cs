using UnityEngine;
using UnityEngine.AI;

public class MovimientoPorClick : MonoBehaviour
{
    private NavMeshAgent agente;
    
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
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
    }
}
