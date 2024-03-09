using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPiecesScript : MonoBehaviour
{
    private Vector3 correctPosition;
    public bool isCorrect = false;
    public bool isSelected = false;

    [SerializeField] float snapTolerance = 6; 
    [SerializeField] GameManager gameManager; 

    // Start is called before the first frame update
    void Start()
    {
        correctPosition = gameObject.transform.position;
        gameObject.transform.position = new Vector3(Random.Range(-5f, 2f), Random.Range(4f, -6f), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(gameObject.transform.position, correctPosition) < snapTolerance)
        {
            transform.position = correctPosition; // Snap into place
            isCorrect = true;
        }
    }
}
