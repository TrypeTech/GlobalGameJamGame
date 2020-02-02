using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControler : MonoBehaviour
{
    // Start is called before the first frame updates
    public float lookRadius = 10f;
    NavMeshAgent agent;
    public Transform target;
    Animator anim;
    public Transform home;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetFloat("speedPercent", 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        

        if(distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            //anim.SetFloat("speedPercent", 1);
            
            if (distance <= agent.stoppingDistance){
                // Attack the target
                // Face the target
                //anim.SetFloat("speedPercent", 0);
                FaceTarget(target);
            }
        }
        else{
            float distanceFromHome = Vector3.Distance(home.position, transform.position);
            if(distance >= lookRadius)
            {
                agent.SetDestination(home.position);
                //anim.SetFloat("speedPercent", 1);
            
                if (distanceFromHome <= agent.stoppingDistance){
                // Attack the target
                // Face the target
                //anim.SetFloat("speedPercent", 0);
                FaceTarget(home);
                }
            }

        }
        anim.SetFloat("speedPercent", agent.velocity.normalized.magnitude);
        
    }

    void FaceTarget(Transform target){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3 (direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
