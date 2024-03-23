using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public float health = 100f;
    public bool destroyed = false;
    private void Update()
    {
        if (health <= 0f)
        {
            destroyed = true;
            Destroy(gameObject);
            Debug.Log("Egg has died!");
        }
        Debug.Log(health);
    }
}
