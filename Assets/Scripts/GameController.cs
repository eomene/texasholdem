using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    //public Stack<Card> Decks = new Stack<Card>();
    public List<CardData> deck = new List<CardData>();
  //  public List<GameObject> visualDeck = new List<GameObject>();
    public GameObject card;
    public Sprite[] cardsprites;
    Sprite front;
    // Start is called before the first frame update
    void Awake()
    {
        //Create card deck
        cardsprites = Resources.LoadAll<Sprite>("carddeck");
        Sprite back = Resources.Load<Sprite>("back");
        CardData cardObject = null;
        GameEnums.CardType cardtype = GameEnums.CardType.clubs;
        GameObject newCard = null;
        int cardCount = 0;
        int realValue = 0;
        for (int i = 0; i < cardsprites.Length; i++)
        {
            if (cardCount <= 13)
            {
                cardCount++;
                realValue++;
                cardtype = GameEnums.CardType.diamonds;
            }
            else if (cardCount <= 26 ) 
            {
                cardCount++;
                realValue++;
                cardtype = GameEnums.CardType.clubs;
            }
            else if (cardCount <= 39 )
            {
                cardCount++;
                realValue++;
                cardtype = GameEnums.CardType.hearts;
            }
            else if (cardCount <= 52 )
            {
                cardCount++;
                realValue++;
                cardtype = GameEnums.CardType.spades;
            }
            newCard = Instantiate(card);
            newCard.name = cardtype.ToString() + " " + realValue + " "+cardCount;
            cardObject = new CardData(back, cardsprites[i], cardtype, realValue, newCard);
            deck.Add(cardObject);
            if (cardCount == 13){
                realValue = 0;
                Debug.Log("Reseted it1");
            }
            if (cardCount == 26)
            {
                realValue = 0;
                Debug.Log("Reseted it2");
            }
            if (cardCount == 39)
            {
                realValue = 0;
                Debug.Log("Reseted it3");
            }
            if (cardCount == 52)
            {
                realValue = 0;
                Debug.Log("Reseted it4");
            }
        }
       // Sprite front = new Sprite;// = Resources.Load<Sprite>("front");

      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
