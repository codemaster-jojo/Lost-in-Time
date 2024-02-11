using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private GameObject sword; 
    [SerializeField] private float attackCooldown = 1.0f;
    [SerializeField] private bool canAttack = true;
    [SerializeField] private AudioClip swordAttackSound;

    void Update() {
        if(Input.GetMouseButtonDown(0)) { // left click
            if (canAttack) {
                SwordAttack();
            }
        }
    }

    public void SwordAttack() {
        canAttack = false;
        Animator anim = sword.GetComponent<Animator>(); 
        anim.SetTrigger("Attack");

        // audio
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(swordAttackSound);

        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown() {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
