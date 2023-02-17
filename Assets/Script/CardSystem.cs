using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardSystem : MonoBehaviour
{
    public int CardNumHand;
    public List<Card> currentCardHand = new List<Card>();
    public int CardNumDeck;
    public List<Card> currentCardDeck = new List<Card>();
    public List<Card> currentCardDump = new List<Card>();
    private int maxCardHand;
    public static CardSystem instance = null;
    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //populate the hand with 4 cards
        for (int i = 0; i < 4; i++) {
            drawCard(i);
        }
    }

    Card drawCard() {
        int length = currentCardDeck.Count;
        Card thisCard = currentCardDeck[0];
        currentCardDeck.RemoveAt(0);
        return thisCard;
    }

    Card drawRandomCard() {
        int length = currentCardDeck.Count;
        int randomNum = Random.Range(0, length);
        Card thisCard = currentCardDeck[randomNum];
        currentCardDeck.RemoveAt(randomNum);
        return thisCard;
    }

    public void AddCardtoDeck(Card card) {
        int length = currentCardDeck.Count;
        int randomNum = Random.Range(0, length);
        currentCardDeck.Insert(randomNum, card);
    }

    public Card drawCard(int keyInput) {
        Card thisCard = drawCard();
        currentCardHand.Insert(keyInput, thisCard);
        return thisCard;
    }

    public void dropCard(int keyInput) {
        Card removedCard = currentCardHand[keyInput];
        currentCardHand.RemoveAt(keyInput);
        currentCardDump.Add(removedCard);
    }

    public void dropAndDraw(int keyInput) {
        dropCard(keyInput);
        drawCard(keyInput);
    }

    
}
