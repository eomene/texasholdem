using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Transform table;
    public Transform startFlyPosition;
    public Stack<CardData> deck = new Stack<CardData>();
    List<Transform> playerPositions = new List<Transform>();
    String[] randomNames = new string[] { "Jude", "Fred","Emma","Joe","Chris","Jerry" };
    Sprite[] playerIcons;
    GameObject card;
    GameObject player;




    void Awake()
    {
        Init();
        CreateDeck();
        Shuffle();

       StartCoroutine(CreatePlayers());
    }
    void Init()
    {
        player = Resources.Load<GameObject>("Player");
        playerIcons = Resources.LoadAll<Sprite>("PlayerIcons/icons");
        DataHolders.flyingCard = Resources.Load<GameObject>("FlyingCard");
        foreach (Transform tr in table)
            playerPositions.Add(tr);
    }
    public IEnumerator CreatePlayers()
    {
        for (int i = 0; i < playerPositions.Count; i++)
        {
            GameObject newPlayerGameObject = Instantiate(player, playerPositions[i]);
            newPlayerGameObject.transform.localPosition = Vector3.zero;
            Player newPlayer = newPlayerGameObject.GetComponent<Player>();
            List<CardData> playerCards = new List<CardData>();
            playerCards.Add(deck.Pop());
            playerCards.Add(deck.Pop());
            //Debug.Log("deck count: " + deck.Count);
            PlayerData playerData = new PlayerData(playerCards, DataHolders.startCash, 0, playerIcons[i], randomNames[i], newPlayerGameObject);
            newPlayer.UpdatePlayerData(playerData, startFlyPosition);
            yield return new WaitForSeconds(DataHolders.delayBetweenPlayerCreation);
        }
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
        Sprite back = Resources.Load<Sprite>("Cards/back");
        card = Resources.Load<GameObject>("Card");
        CardData cardObject = null;
        GameEnums.CardType cardtype = GameEnums.CardType.clubs;
        GameObject newCardGameObject = null;
        GameObject parent = new GameObject("Card Deck");

        for (int i = 0; i < diamonds.Length; i++)
        {
            cardtype = GameEnums.CardType.diamonds;
            newCardGameObject = Instantiate(card, parent.transform);
            Card newCard = newCardGameObject.GetComponent<Card>();
            cardObject = new CardData(back, diamonds[i], cardtype, i + 1, newCardGameObject);
            newCard.UpdateCardObject(cardObject);
            deck.Push(cardObject);
        }
        for (int i = 0; i < clubs.Length; i++)
        {
            cardtype = GameEnums.CardType.clubs;
            newCardGameObject = Instantiate(card, parent.transform);
            Card newCard = newCardGameObject.GetComponent<Card>();
            cardObject = new CardData(back, clubs[i], cardtype, i + 1, newCardGameObject);
            newCard.UpdateCardObject(cardObject);
            deck.Push(cardObject);
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            cardtype = GameEnums.CardType.hearts;
            newCardGameObject = Instantiate(card,parent.transform);
            Card newCard = newCardGameObject.GetComponent<Card>();
            cardObject = new CardData(back, hearts[i], cardtype, i + 1, newCardGameObject);
            newCard.UpdateCardObject(cardObject);
            deck.Push(cardObject);
        }

        for (int i = 0; i < spades.Length; i++)
        {
            cardtype = GameEnums.CardType.spades;
            newCardGameObject = Instantiate(card, parent.transform);
            Card newCard = newCardGameObject.GetComponent<Card>();
            cardObject = new CardData(back, spades[i], cardtype, i + 1, newCardGameObject);
            newCard.UpdateCardObject(cardObject);
            deck.Push(cardObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
