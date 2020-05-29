using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshControl : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float distance;
    private NavMeshAgent m_NavMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        m_NavMeshAgent = this.GetComponent<NavMeshAgent>();
        m_NavMeshAgent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_NavMeshAgent.enabled)
        {
            var dis = Vector3.Distance(target.transform.position, this.transform.position);
            if (dis <= distance)
            {
                Action();
            }
        }
        else
        {
            m_NavMeshAgent.SetDestination(target.transform.position);
        }
    }
    private void Action()
    {
        m_NavMeshAgent.enabled = true;
    }
}
