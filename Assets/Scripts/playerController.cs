using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerController : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    public Animator anim;

    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();
        agent.stoppingDistance = 1f;
    }

    void Update()
    {
        checkChar();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                
            }
        }
        if(agent.remainingDistance > agent.stoppingDistance)
        {
            anim.SetBool("Moving", true);
        }
        else
        {
            anim.SetBool("Moving", false);

        }
    }

    void checkChar()
    {
        
        //if(Vector3.Distance(this.transform.position, dest) < 1)
        //{
            //anim.SetBool("Moving", false);

       // }
    }
}