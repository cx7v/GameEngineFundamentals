using UnityEngine;
using UnityEngine.AI;

public class NavmeshAgentScript : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Automatically search the scene for the player if target is missing
        if (target == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                target = player.transform;
            }
            else
            {
                Debug.LogError("Zombie cannot find an object tagged 'Player'! Make sure your player object has the Player tag.");
            }
        }
    }

    void Update()
    {
        // FIX: The error on line 20 happens because it lacks this null check
        if (target != null && agent != null)
        {
            agent.SetDestination(target.position);
        }
    }
}
