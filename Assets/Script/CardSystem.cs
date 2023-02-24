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
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //populate the hand with 4 cards
        for (int i = 0; i < 4; i++)
        {
            drawCard(i);
        }
    }

    Card drawCard()
    {
        int length = currentCardDeck.Count;
        Card thisCard = currentCardDeck[0];
        currentCardDeck.RemoveAt(0);
        CardNumDeck--;
        return thisCard;
    }

    Card drawRandomCard()
    {
        int length = currentCardDeck.Count;
        int randomNum = Random.Range(0, length);
        Card thisCard = currentCardDeck[randomNum];
        currentCardDeck.RemoveAt(randomNum);
        CardNumDeck--;
        return thisCard;
    }

    public void AddCardtoDeck(Card card)
    {
        int length = currentCardDeck.Count;
        int randomNum = Random.Range(0, length);
        currentCardDeck.Insert(randomNum, card);
        CardNumDeck++;
    }

    public Card drawCard(int keyInput)
    {
        if (CardNumDeck > 0)
        {
            Card thisCard = drawCard();
            currentCardHand.Insert(keyInput, thisCard);
            CardNumHand++;
            return thisCard;
        }
        else return null;
    }

    public void dropCard(int keyInput)
    {
        if (CardNumHand > 0)
        {
            Card removedCard = currentCardHand[keyInput];
            currentCardHand.RemoveAt(keyInput);
            CardNumHand--;
            currentCardDump.Add(removedCard);
        }
        else return;
    }

    public void dropAndDraw(int keyInput)
    {
        dropCard(keyInput);
        drawCard(keyInput);
    }
}
