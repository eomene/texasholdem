using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public interface IDeckCreator
{
    void CreateDeck(bool needRealObject);
    void Shuffle();
    Card myInstantiate(GameObject card, Transform parent, bool needRealObject);
}
public class DeckCreator : MonoBehaviour, IDeckCreator
{
    DeckCreatorInternal deckCreatorInternal;
    public Deck deck;
    public IDeck realDeck;
    public StringVariable DiamondsLocation;
    public StringVariable ClubsLocation;
    public StringVariable HeartsLocation;
    public StringVariable SpadesLocation;
    public StringVariable CardsBackLocation;
    public ObjectVariable Card;
   // Stack<Card> deck = new Stack<Card>();
   // GameObject card;

    // Start is called before the first frame update
    void Awake ()
    {
        deckCreatorInternal = new DeckCreatorInternal(this);
        realDeck = deck;
        //bool isEditor = EditorApplication.isPlaying ? false : true;
        CreateDeck(true);
        Shuffle();
    }

    public void CreateDeck(bool needRealObject)
    {
        deckCreatorInternal.CreateDeck(realDeck,DiamondsLocation.Value,ClubsLocation.Value,HeartsLocation.Value,
    SpadesLocation.Value,
    CardsBackLocation.Value,Card.Value, gameObject, needRealObject);
    
    }
    public  void Shuffle()
    {
        deckCreatorInternal.Shuffle(realDeck);
    }

    public Card myInstantiate(GameObject card, Transform parent, bool needRealObject)
    {
        Card myCard = null;
        if (needRealObject)
            myCard = Instantiate(card, parent.transform).GetComponent<Card>();
        else
            myCard = new Card();

       return myCard;
    }
    public Card newInstantiate(GameObject card, Transform parent)
    {
        return Instantiate(card, parent.transform).GetComponent<Card>();
    }
}
public class DeckCreatorInternal
{
    DeckCreator deckCreator;
    public DeckCreatorInternal(DeckCreator deckCreator = null)
    {
        this.deckCreator = deckCreator;
    }
    public void CreateDeck(IDeck deck, string DiamondsLocation,string ClubsLocation,string HeartsLocation,
    string SpadesLocation,
    string CardsBackLocation,GameObject Card, GameObject creatorObject,bool needRealObject)
    {
        deck.Clear();
        //Create card deck
        //get the individual sprites, not sure how i will get the art yet(temp)
        //loaded fro resources, but asset bundles can also be used
        Sprite[] diamonds = Resources.LoadAll<Sprite>(DiamondsLocation);
        Sprite[] clubs = Resources.LoadAll<Sprite>(ClubsLocation);
        Sprite[] hearts = Resources.LoadAll<Sprite>(HeartsLocation);
        Sprite[] spades = Resources.LoadAll<Sprite>(SpadesLocation);
        Sprite back = Resources.Load<Sprite>(CardsBackLocation);

        // CardData cardObject = null;
        //create a temp enum for the type of card
        GameEnums.SuitEnum cardtype = GameEnums.SuitEnum.Clubs;

        //create a parent for all the cards
        GameObject parent = creatorObject;

        for (int i = 0; i < diamonds.Length; i++)
        {
            cardtype = GameEnums.SuitEnum.Diamonds;
            Card newCard = myInstantiate(Card, parent.transform, needRealObject);
            newCard.SetUpCard(back, diamonds[i], cardtype, i + 1);
        }
        for (int i = 0; i < clubs.Length; i++)
        {
            cardtype = GameEnums.SuitEnum.Clubs;
            Card newCard = myInstantiate(Card, parent.transform, needRealObject);
            newCard.SetUpCard(back, clubs[i], cardtype, i + 1);
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            cardtype = GameEnums.SuitEnum.Hearts;
            Card newCard = myInstantiate(Card, parent.transform, needRealObject);
            newCard.SetUpCard(back, hearts[i], cardtype, i + 1);
        }

        for (int i = 0; i < spades.Length; i++)
        {
            cardtype = GameEnums.SuitEnum.Spades;
            Card newCard = myInstantiate(Card, parent.transform, needRealObject);
            newCard.SetUpCard(back, spades[i], cardtype, i + 1);
        }
    }
    public void Shuffle(IDeck deck)
    {
        //shuffle deck of cards
        deck.Shuffle();
    }
    public Card myInstantiate(GameObject card, Transform parent, bool needRealObject)
    {
        Card myCard = null;
        if (needRealObject)
            if(deckCreator!=null)
            myCard = deckCreator.newInstantiate(card, parent.transform);
        else
            myCard = new Card();

        return myCard;
    }
    public GameObject Instantiate(GameObject card,Transform parent)
    {
        GameObject fake = null;

        return fake;
    }
}
