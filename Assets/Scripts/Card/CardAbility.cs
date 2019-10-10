using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAbility : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual List<IPokerObject> GetCardsFromDeck()
    {
        //create a new list of player cards
        List<IPokerObject> playerCards = new List<IPokerObject>();

        return playerCards;
    }
}
