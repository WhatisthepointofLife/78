using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class demoai : MonoBehaviour
{
    //AI
    NavMeshAgent agent = null;
    GameObject TargetPoint = null;

    //Raycast
    public float raycastDist = 10;
    public LayerMask mask = 0;

    GameObject HitTarget = null;

    // Start is called before the first frame update
    void Start()
    { 
        agent = GetComponent<NavMeshAgent>();
        TargetPoint = new GameObject("Targetpoint");
        HitTarget = TargetPoint;
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 direction = new Vector3(Mathf.Sin(Time.time), 0, 1);
        //agent.Move(direction * Time.deltaTime * 5);

        //agent.SetDestination(TargetPoint.transform.position);
        RaycastHit Hit;
        Debug.DrawRay(transform.position, transform.forward * raycastDist, Color.magenta);
        if (Physics.Raycast(transform.position, transform.forward, out Hit, raycastDist, mask))
        {
            HitTarget = Hit.transform.gameObject;
            Debug.Log("works");
        }
        agent.SetDestination(HitTarget.transform.position);
    }
}
