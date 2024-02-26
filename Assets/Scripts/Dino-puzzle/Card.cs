using UnityEngine;

public class Card : MonoBehaviour
{
    public DinoGameManager DinoGameManager; 
    private int cardIndex; 

    public void OnCardClick()
    {

       DinoGameManager.CheckMatch(cardIndex);
    }
}
