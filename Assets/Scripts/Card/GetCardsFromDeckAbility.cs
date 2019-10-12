using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCardsFromDeckAbility : MonoBehaviour
{
    GetCardsFromDeckAbilityInternal getCardsFromDeckAbilityInternal;
    public Deck deck;
    public FloatReference delaySpeed;

    private void Awake()
    {
        getCardsFromDeckAbilityInternal = new GetCardsFromDeckAbilityInternal();
    }
    public List<IPokerObject> GetCardsFromDeck(int cardsNeeded)
    {
        return getCardsFromDeckAbilityInternal.GetCardsFromDeck(deck, cardsNeeded);
    }
}
public class GetCardsFromDeckAbilityInternal
{
    public List<IPokerObject> GetCardsFromDeck(IDeck realDeck, int cardsNeeded)
    {
        //create a new list of player cards
        List<IPokerObject> playerCards = new List<IPokerObject>();

        for (int i = 0; i < cardsNeeded; i++)
        {
            Card crd = realDeck.GetLast();
            crd.alreadyPoped = true;
            playerCards.Add(crd);
            realDeck.RemoveLast();
        }
        return playerCards;
    }
}
