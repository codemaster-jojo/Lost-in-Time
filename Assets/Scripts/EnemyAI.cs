using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
public class EnemyAI : MonoBehaviour
{
    // Define possible states
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    // Current state
    private State currentState;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    [SerializeField] private float spotDistance;
    [SerializeField] private float atkRange;

    private Vector3 direction;
    private Vector3 roamPosition;

    void Start()
    {
        // Initialize state to Idle
        currentState = State.Idle;
        roamPosition = transform.position + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized * Random.Range(5f, 10f); // set roaming position

    }

    void Update()
    {
        // Update based on current state
        switch (currentState)
        {
            case State.Idle:
                // Perform actions for Idle state
                // !!! HOW TO DO PATHFINDING, EVERYTHING I FOUND ONLINE USES NAVMESH AGENT !!!
                direction = (roamPosition - transform.position);
                transform.position += direction.normalized * speed * Time.deltaTime;

                float reachedPositionDistance = 0.5f;
                    if (Vector3.Distance(transform.position, roamPosition) < reachedPositionDistance) { // reached roam position
                        StartCoroutine(ResetRoam()); 
                        // !!! WHICH IDLE ROAM BETTER: ALWAYS MOVING IN RANDOM DIRECTION OR MOVE IN ONE DIRECTION + WAIT !!!
                    }

                // Transition to Chase state based on some condition (e.g., player spotted)
                if (PlayerSpotted())
                {
                    currentState = State.Chase;
                }
                break;

            case State.Chase:
                // Perform actions for Chase state
                direction = (target.position - transform.position);
                transform.position += direction.normalized * speed * Time.deltaTime;

                // Transition back to Idle state when player is no longer visible
                if (!PlayerSpotted())
                {
                    currentState = State.Idle;
                }

                // Attack the player when the player is close enough
                if (CloseEnoughToAttack())
                {
                    currentState = State.Attack;
                }
                break;
            
            case State.Attack:
                // Perform actions for Attack state
                Debug.Log("ATTACK!!!");

                if (!CloseEnoughToAttack())
                {
                    currentState = State.Chase;
                }
                break;
        }
    }

    IEnumerator ResetRoam() {
        yield return new WaitForSeconds(1f);
        roamPosition = transform.position + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized * Random.Range(5f, 10f); // set new roaming position
    }


    // Example methods to simulate conditions for state transitions
    private bool PlayerSpotted()
    {
        // Simulated condition: Player is always spotted in this example
        return Vector3.Distance(transform.position, target.position) <= spotDistance;
    }

    private bool CloseEnoughToAttack()
    {
        return Vector3.Distance(transform.position, target.position) <= atkRange;
    }
} 
*/


public class EnemyAI : MonoBehaviour
{
    // Define possible states
    public enum State
    {
        Idle,
        Chase,
        Attack
    }

    // Current state
    private State currentState;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;

    [SerializeField] private float spotDistance;
    [SerializeField] private float atkRange;


    [SerializeField] private NavMeshAgent navMeshAgent;

    private Vector3 direction;
    [SerializeField] private Transform[] waypoints;
    private int waypointIndex;

    void Start()
    {
        // Initialize state to Idle
        currentState = State.Idle;
        navMeshAgent = GetComponent<NavMeshAgent>();

        waypointIndex = 0;

    }

    void Update()
    {
        // Update based on current state
        switch (currentState)
        {
            case State.Idle:
                Debug.Log(waypointIndex);
                Debug.Log(Vector3.Distance(transform.position, waypoints[waypointIndex].position));
                navMeshAgent.destination = waypoints[waypointIndex].position;                

                float reachedPositionDistance = 1f;
                if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < reachedPositionDistance) { // reached roam position
                    Debug.Log("hi");
                    waypointIndex++;
                    waypointIndex %= waypoints.Length;
                }

                // Transition to Chase state based on some condition (e.g., player spotted)
                if (PlayerSpotted())
                {
                    currentState = State.Chase;
                }
                break;

            case State.Chase:
                // Perform actions for Chase state
                //direction = (target.position - transform.position);
                //transform.position += direction.normalized * speed * Time.deltaTime;

                navMeshAgent.destination = target.position;

                // Transition back to Idle state when player is no longer visible
                if (!PlayerSpotted())
                {
                    currentState = State.Idle;
                }

                // Attack the player when the player is close enough
                if (CloseEnoughToAttack())
                {
                    currentState = State.Attack;
                }
                break;
            
            case State.Attack:
                // Perform actions for Attack state
                Debug.Log("ATTACK!!!");

                if (!CloseEnoughToAttack())
                {
                    currentState = State.Chase;
                }
                break;
        }
    }


    // Example methods to simulate conditions for state transitions
    private bool PlayerSpotted()
    {
        // Simulated condition: Player is always spotted in this example
        return Vector3.Distance(transform.position, target.position) <= spotDistance;
    }

    private bool CloseEnoughToAttack()
    {
        return Vector3.Distance(transform.position, target.position) <= atkRange;
    }
} 
