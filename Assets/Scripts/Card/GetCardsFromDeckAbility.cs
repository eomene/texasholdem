using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCardsFromDeckAbility : MonoBehaviour
{
    public Deck deck;
    public FloatReference delaySpeed;

    public List<IPokerObject> GetCardsFromDeck()
    {
        //create a new list of player cards
        List<IPokerObject> playerCards = new List<IPokerObject>();
        //add two of the last cards to the stack of card decks
        Card crd = deck.GetLast();
        crd.alreadyPoped = true;
        playerCards.Add(crd);
        deck.RemoveLast();
        //next
        crd = deck.GetLast();
        crd.alreadyPoped = true;
        playerCards.Add(crd);
        deck.RemoveLast();
        //Debug.Log(crd.suitEnum.ToString() + "/" + crd.cardEnum.ToString()+" //" + deck.Count().ToString());
        deck.Count();
        return playerCards;
    }
}
