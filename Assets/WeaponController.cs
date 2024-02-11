using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject sword; 
    [SerializeField] private float attackCooldown = 1.0f;

    private bool canAttack = true;

    void Update() {
        if(Input.GetMouseButtonDown(0)) { // left click
            if (canAttack) {
                SwordAttack()
            }
        }
    }

    public void SwordAttack() {
        canAttack = false;
        Animator anim = Sword.GetComponent<Animator>(); 
        anim.SetTrigger("Attack");
    }

    IEnumerator ResetAttackCooldown() {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
