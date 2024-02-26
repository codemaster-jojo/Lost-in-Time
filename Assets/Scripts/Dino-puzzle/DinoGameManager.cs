using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoGameManager : MonoBehaviour
{
    public List<Material> footprintMaterials; 
    public GameObject cardPrefab;
    public GameObject cardGrid;

    private List<GameObject> cards = new List<GameObject>();
    private int firstRevealedCardIndex = -1; 
    private int matchesFound = 0; 
    private List<Material> doubleFootprints;

    void Start()
    {
        GenerateCards();
    }

    void GenerateCards()
    {
        doubleFootprints = new List<Material>(footprintMaterials);
        doubleFootprints.AddRange(footprintMaterials);  

        for (int i = doubleFootprints.Count - 1; i > 0; i--)
        {
            int swapIndex = Random.Range(0, i + 1); 
            Material temp = doubleFootprints[i];
            doubleFootprints[i] = doubleFootprints[swapIndex];
            doubleFootprints[swapIndex] = temp;
        }

        int materialIndex = 0; 
        for (int i = 0; i < cardGrid.transform.childCount; i++)
        {
            GameObject card = Instantiate(cardPrefab, cardGrid.transform);
            cards.Add(card);
            card.transform.GetChild(1).GetComponent<Image>().material = doubleFootprints[materialIndex];
            materialIndex++;
        }
    }

    public void CheckMatch(int cardIndex)
    {
        // ... (your existing match checking logic)

        // If it's a match:
        matchesFound++;

        if (matchesFound >= footprintMaterials.Count)
        {
            // Placeholder: Replace with your win effects
            Debug.Log("You Win!"); 
        }
    }

    public void ResetGame()
    {
        matchesFound = 0;

        // Placeholder: Add your card reset logic here 
        // ... Call GenerateCards() to reshuffle
    }
}
