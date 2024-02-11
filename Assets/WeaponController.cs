using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject sword; 
    [SerializeField] private float attackCooldown = 1.0f;
    [SerializeField] private bool canAttack = true;
    [SerializeField] private AudioClip swordAttackSound;

    public bool isAttacking = false;

    void Update() {
        if(Input.GetMouseButtonDown(0)) { // left click
            if (canAttack) {
                SwordAttack();
            }
        }
    }

    public void SwordAttack() {
        canAttack = false;
        isAttacking = true;
        Animator anim = sword.GetComponent<Animator>(); 
        anim.SetTrigger("Attack");

        // audio
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(swordAttackSound);

        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown() {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator ResetAttackBool() {
        yield return new WaitForSeconds(1.0f);
        isAttacking = false;
    }
}
