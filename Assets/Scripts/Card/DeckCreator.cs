using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DeckCreator : CardAbility
{
    public Deck deck;
    public StringVariable DiamondsLocation;
    public StringVariable ClubsLocation;
    public StringVariable HeartsLocation;
    public StringVariable SpadesLocation;
    public StringVariable CardsBackLocation;
    public ObjectVariable Card;
   // Stack<Card> deck = new Stack<Card>();
    GameObject card;

    // Start is called before the first frame update
    void Awake ()
    {
        CreateDeck();
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CreateDeck()
    {
        deck.Clear();
        //Create card deck
        //get the individual sprites, not sure how i will get the art yet(temp)
        //loaded fro resources, but asset bundles can also be used
        Sprite[] diamonds = Resources.LoadAll<Sprite>(DiamondsLocation.Value);
        Sprite[] clubs = Resources.LoadAll<Sprite>(ClubsLocation.Value);
        Sprite[] hearts = Resources.LoadAll<Sprite>(HeartsLocation.Value);
        Sprite[] spades = Resources.LoadAll<Sprite>(SpadesLocation.Value);
        Sprite back = Resources.Load<Sprite>(CardsBackLocation.Value);

        card = Card.Value;

       // CardData cardObject = null;
        //create a temp enum for the type of card
        GameEnums.SuitEnum cardtype = GameEnums.SuitEnum.Clubs;

        GameObject newCardGameObject = null;
        //create a parent for all the cards
        GameObject parent = gameObject;

        //create for each type of card(this can be simplified based on how assets are given
        for (int i = 0; i < diamonds.Length; i++)
        {
            cardtype = GameEnums.SuitEnum.Diamonds;
            newCardGameObject = Instantiate(card, parent.transform);
            Card newCard = newCardGameObject.GetComponent<Card>();
            newCard.SetUpCard(back, diamonds[i], cardtype, i + 1);
        }
        for (int i = 0; i < clubs.Length; i++)
        {
            cardtype = GameEnums.SuitEnum.Clubs;
            newCardGameObject = Instantiate(card, parent.transform);
            Card newCard = newCardGameObject.GetComponent<Card>();
            newCard.SetUpCard(back, clubs[i], cardtype, i + 1);
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            cardtype = GameEnums.SuitEnum.Hearts;
            newCardGameObject = Instantiate(card, parent.transform);
            Card newCard = newCardGameObject.GetComponent<Card>();
            newCard.SetUpCard(back, hearts[i], cardtype, i + 1);
        }

        for (int i = 0; i < spades.Length; i++)
        {
            cardtype = GameEnums.SuitEnum.Spades;
            newCardGameObject = Instantiate(card, parent.transform);
            Card newCard = newCardGameObject.GetComponent<Card>();
            newCard.SetUpCard(back, spades[i], cardtype, i + 1);
        }
    }
    private void Shuffle()
    {
        //shuffle deck of cards
        deck.Shuffle();
    }
}
