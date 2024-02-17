using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private Vector3 direction;

    void Start()
    {
        // Initialize state to Idle
        currentState = State.Idle;
    }

    void Update()
    {
        // Update based on current state
        switch (currentState)
        {
            case State.Idle:
                // Perform actions for Idle state
                

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

    // Example methods to simulate conditions for state transitions
    private bool PlayerSpotted()
    {
        // Simulated condition: Player is always spotted in this example
        return Vector3.Distance(transform.position, target.position) <= 50f;
    }

    private bool CloseEnoughToAttack()
    {
        return Vector3.Distance(transform.position, target.position) <= 2f;
    }
    /*
    private bool PlayerVisible()
    {
        // Simulated condition: Player is not always visible in this example
        return false;
    }
    */

} 
