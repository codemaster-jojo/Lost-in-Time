using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManagement : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(20);
        }
    }
    private void TakeDamage(int dmg) {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
    }
}
