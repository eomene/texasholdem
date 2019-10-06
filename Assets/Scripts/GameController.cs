using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public Stack<Card> Decks = new Stack<Card>();
    [HideInInspector]
    public List<CardData> deck = new List<CardData>();
    public List<PlayerData> players = new List<PlayerData>();
    Sprite[] playerIcons;
    GameObject card;
   


    void Awake()
    {
        CreateDeck();
        Shuffle();
    }
    public void CreatePlayers()
    {

    }
    private void Shuffle()
    {
        deck.Shuffle();
    }

    void CreateDeck()
    {
        //Create card deck
        Sprite[] diamonds = Resources.LoadAll<Sprite>("Cards/diamonds");
        Sprite[] clubs = Resources.LoadAll<Sprite>("Cards/clubs");
        Sprite[] hearts = Resources.LoadAll<Sprite>("Cards/hearts");
        Sprite[] spades = Resources.LoadAll<Sprite>("Cards/spades");
        playerIcons = Resources.LoadAll<Sprite>("PlayerIcons/icons");
        Sprite back = Resources.Load<Sprite>("Cards/back");
        card = Resources.Load<GameObject>("Card");
        CardData cardObject = null;
        GameEnums.CardType cardtype = GameEnums.CardType.clubs;
        GameObject newCard = null;
        GameObject parent = new GameObject("Card Deck");

        for (int i = 0; i < diamonds.Length; i++)
        {
            cardtype = GameEnums.CardType.diamonds;
            newCard = Instantiate(card, parent.transform);
            cardObject = new CardData(back, diamonds[i], cardtype, i + 1, newCard);
            deck.Add(cardObject);
        }
        for (int i = 0; i < clubs.Length; i++)
        {
            cardtype = GameEnums.CardType.clubs;
            newCard = Instantiate(card, parent.transform);
            cardObject = new CardData(back, clubs[i], cardtype, i + 1, newCard);
            deck.Add(cardObject);
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            cardtype = GameEnums.CardType.hearts;
            newCard = Instantiate(card,parent.transform);
            cardObject = new CardData(back, hearts[i], cardtype, i + 1, newCard);
            deck.Add(cardObject);
        }

        for (int i = 0; i < spades.Length; i++)
        {
            cardtype = GameEnums.CardType.spades;
            newCard = Instantiate(card, parent.transform);
            cardObject = new CardData(back, spades[i], cardtype, i + 1, newCard);
            deck.Add(cardObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
