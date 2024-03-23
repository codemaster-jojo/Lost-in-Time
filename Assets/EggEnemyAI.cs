using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggEnemyAI : MonoBehaviour
{
    [SerializeField] float speed = 3.0f;
    [SerializeField] float damage = 2.5f;
    [SerializeField] float attackRate = 0.75f;
    internal Rigidbody rb;
    Egg egg;
    float attackDist = 1.5f;
    bool eggInRange = false;
    float attackTimer = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        egg = FindObjectOfType<Egg>();
    }
    private void Update()
    {
        if (egg != null)
        {
            Vector3 enemyToEgg = egg.transform.position - this.transform.position;
            Quaternion rot = Quaternion.LookRotation(enemyToEgg, Vector3.up);
            if (enemyToEgg.magnitude > attackDist)
            {
                transform.rotation = rot;
                eggInRange = true;
            }
            else
            {
                attackTimer += Time.deltaTime;
                eggInRange = false;
            }
            if (attackTimer >= attackRate)
            {
                egg.health -= damage;
                attackTimer = 0f;
            }
        }
    }
    private void FixedUpdate()
    {
        if (eggInRange)
        {
            rb.velocity = transform.forward * speed;
        }
    }
}
