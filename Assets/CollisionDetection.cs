using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private WeaponController wc;
    // [SerializeField] GameObject HitParticle;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy" && wc.isAttacking) {
            Debug.Log(other.name);
            other.GetComponent<Animator>().SetTrigger("Hit"); 
            // Instantiate(HitParticle, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }
}
