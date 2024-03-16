using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggEnemyAI : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    public Transform eggTransform;
    internal Rigidbody rb;
    float attackDist = 1.5f;
    bool playerInRange = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector3 enemyToEgg = eggTransform.position - this.transform.position;
        Quaternion rot = Quaternion.LookRotation(enemyToEgg, Vector3.up);
        if (enemyToEgg.magnitude > attackDist)
        {
            transform.rotation = rot;
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }
    }
    private void FixedUpdate()
    {
        if (playerInRange)
        {
            rb.velocity = transform.forward * speed;
        }
    }
}
