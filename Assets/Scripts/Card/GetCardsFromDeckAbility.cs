using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCardsFromDeckAbility : MonoBehaviour
{
    public Deck deck;
    public IDeck realDeck;
    public FloatReference delaySpeed;

    public List<IPokerObject> GetCardsFromDeck()
    {
        realDeck = deck;
        //create a new list of player cards
        List<IPokerObject> playerCards = new List<IPokerObject>();
        //add two of the last cards to the stack of card decks
        Card crd = realDeck.GetLast();
        crd.alreadyPoped = true;
        playerCards.Add(crd);
        realDeck.RemoveLast();
        //next
        crd = realDeck.GetLast();
        crd.alreadyPoped = true;
        playerCards.Add(crd);
        realDeck.RemoveLast();
        //Debug.Log(crd.suitEnum.ToString() + "/" + crd.cardEnum.ToString()+" //" + deck.Count().ToString());
        //realDeck.Count();
        return playerCards;
    }
}
