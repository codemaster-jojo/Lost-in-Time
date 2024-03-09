using UnityEngine;

public class GameManager : MonoBehaviour
{
    public OnPiecesScript[] allPieces; // Array to store references
    public GameObject winEffect;        // A celebratory effect

    void Update()
    {
        if (CheckAllPiecesCorrect())
        {
            // All pieces are in place - Win!
            if (winEffect) Instantiate(winEffect, transform.position, Quaternion.identity); 

            Debug.Log("You Win!"); 
            // Add more win actions here (disable input, play sounds, etc.)
        }
    }

    private bool CheckAllPiecesCorrect()
    {
        foreach (var piece in allPieces)
        {
            if (!piece.isCorrect)
                return false;
        }
        return true;
    }
}
