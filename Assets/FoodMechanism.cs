using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodMechanism : MonoBehaviour
{

    void OnCollisionEnter(Collision coll) {
        if (coll.gameObject.tag == "Food") {
            HUDManagement.instance.Eat(10);
            Destroy(coll.gameObject);
        }
    }
}
