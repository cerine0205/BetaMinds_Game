using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator anim;
    public Transform player;

    public Transform pointA;
    public Transform pointB;
    private Transform targetPoint;

    bool isStop = false;
    float timer = 7f;

    bool isChasing = false;
    float forgetDistance = 13f;

    float patrolStop = 0.3f;

    float shootCooldown = 2f;
    float shootTimer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").transform;

        targetPoint = pointA;
        agent.SetDestination(targetPoint.position);
    }

    void Update()
    {
        float distToPlayer = Vector3.Distance(transform.position, player.position);

        // detect player
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, 20f) &&
            hitInfo.collider.CompareTag("Player"))
        {
            isChasing = true;
        }

        if (isChasing)
        {
            // forget player if too far
            if (distToPlayer > forgetDistance)
            {
                isChasing = false;
                anim.SetBool("run", false);
                anim.SetBool("aim", false);
                anim.ResetTrigger("shoot");
                return;
            }

            agent.stoppingDistance = 3.4f;
            anim.SetBool("walk", false);
            anim.SetBool("stop", false);

            // === Shooting range ===
            if (distToPlayer <= agent.stoppingDistance)
            {
                agent.ResetPath();
                anim.SetBool("run", false);
                anim.SetBool("aim", true);

                // Rotate smoothly toward player while shooting
                RotateTowards(player.position);

                // Timed shooting
                shootTimer -= Time.deltaTime;
                if (shootTimer <= 0f)
                {
                    anim.SetTrigger("shoot");
                    shootTimer = shootCooldown;
                }
            }
            else
            {
                // === Player far away (chase again) ===
                agent.isStopped = false;
                agent.updateRotation = true;
                anim.SetBool("run", true);
                anim.SetBool("aim", false);
                anim.ResetTrigger("shoot");

                agent.SetDestination(player.position);
            }

            return;
        }

        // === Patrol logic ===
        anim.ResetTrigger("shoot");
        anim.SetBool("aim", false);

        if (!isStop)
        {
            agent.stoppingDistance = patrolStop;
            anim.SetBool("walk", true);
            agent.SetDestination(targetPoint.position);

            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                isStop = true;
                anim.SetBool("walk", false);
                anim.SetBool("stop", true);
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                timer = 7f;
                isStop = false;
                anim.SetBool("stop", false);
                targetPoint = (targetPoint == pointA) ? pointB : pointA;
            }
        }
    }

    // Smooth rotation toward a target position
    void RotateTowards(Vector3 targetPos)
    {
        Vector3 direction = (targetPos - transform.position).normalized;
        direction.y = 0f; // ignore vertical difference
        if (direction.sqrMagnitude < 0.001f) return;

        Quaternion lookRot = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRot, Time.deltaTime * 5f);
    }
}
