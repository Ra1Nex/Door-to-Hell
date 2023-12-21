// i made this scripts
// my blog https://t.me/+mswwKHfyTKM0MDky

using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform[] waypoints;
    public Transform targetToFollow;
    public float followRadius = 15f;
    public Animator animator;
    public GameObject player;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        SetRandomDestination();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void SetRandomDestination()
    {
        if (targetToFollow != null && Vector3.Distance(transform.position, targetToFollow.position) <= followRadius)
        {
            agent.SetDestination(targetToFollow.position);
        }
        else if (waypoints.Length > 0)
        {
            int randomIndex = Random.Range(0, waypoints.Length);
            agent.SetDestination(waypoints[randomIndex].position);
        }
    }


    void StartAttackAnimation()
    {
        animator.SetTrigger("Atack");

        if (player != null)
        {
            float attackAnimationLength = 2.0f; 
            Invoke("DestroyPlayer", attackAnimationLength);
        }
    }

    void DestroyPlayer()
    {
        if (player != null)
        {
            Destroy(player);
        }
    }
    void Update()
    {
        if (targetToFollow != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, targetToFollow.position);
            if (distanceToPlayer <= followRadius)
            {
                agent.SetDestination(targetToFollow.position);
                animator.SetBool("Walk", true);
                if (distanceToPlayer <= 2.0f)
                {
                    StartAttackAnimation();
                }
            }
        }

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetRandomDestination();
        }

        if (agent.remainingDistance > 0.5f)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }
}
