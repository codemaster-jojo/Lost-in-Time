using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManagement : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [SerializeField] private int maxHunger = 100;
    [SerializeField] private int currentHunger;


    public HealthBar healthBar;
    public HealthBar hungerBar; // I know its a hunger bar but the name thing is healthbar so...


    float elapsed = 0f;

    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        hungerBar.SetMaxHealth(maxHunger);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(20);
        }

        elapsed += Time.deltaTime;
        if (elapsed >= 1f) {
            elapsed = elapsed % 1f;
            GetHungry();
        }
    }
    private void GetHungry() {
        currentHunger -= 1;
        hungerBar.SetHealth(currentHunger);
    }

    private void TakeDamage(int dmg) {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);
    }
}
