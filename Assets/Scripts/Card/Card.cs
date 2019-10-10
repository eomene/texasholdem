using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPokerObject,IPokerSpriteBack,IPokerSpriteFront,IPokerOwner
{
   // public CardData cardObject;
    public Image View;
    public Sprite back;
    public Sprite front;
    public GameEnums.CardEnum cardEnum;
    public GameEnums.SuitEnum suitEnum;
    public Deck RuntimeDeck;
    [HideInInspector]
    public bool alreadyPoped;
    public GameObject dummy;
    public bool isRealPlayerCard;

    private void OnEnable()
    {
        RuntimeDeck.Add(this);
       // Debug.Log("Deck Count: "+ RuntimeDeck.Count());
    }

    public void OnDisable()
    {
        RuntimeDeck.Remove(this);
       // Debug.Log("Deck Count: " + RuntimeDeck.Count());
    }
    public void SetUpCard(Sprite back, Sprite front, GameEnums.SuitEnum suitEnum, int value)
    {
  
        //Debug.Log("Deck Count: " + RuntimeDeck.Count());
        this.back = back;
        this.front = front;
        View.sprite = back;

        this.suitEnum = suitEnum;
       // this.card = card;
        if (value == 1)
            cardEnum = GameEnums.CardEnum.Ace;
        if (value == 2)
            cardEnum = GameEnums.CardEnum.Two;
        if (value == 3)
            cardEnum = GameEnums.CardEnum.Three;
        if (value == 4)
            cardEnum = GameEnums.CardEnum.Four;
        if (value == 5)
            cardEnum = GameEnums.CardEnum.Five;
        if (value == 6)
            cardEnum = GameEnums.CardEnum.Six;
        if (value == 7)
            cardEnum = GameEnums.CardEnum.Seven;
        if (value == 8)
            cardEnum = GameEnums.CardEnum.Eight;
        if (value == 9)
            cardEnum = GameEnums.CardEnum.Nine;
        if (value == 10)
            cardEnum = GameEnums.CardEnum.Ten;
        if (value == 11)
            cardEnum = GameEnums.CardEnum.Jack;
        if (value == 12)
            cardEnum = GameEnums.CardEnum.Queen;
        if (value == 13)
            cardEnum = GameEnums.CardEnum.King;


        gameObject.name = suitEnum.ToString() + cardEnum.ToString();
    }

    public GameObject GetPokerObject()
    {
        return gameObject;
    }
    public GameObject GetPokerDummy()
    {
        return dummy;
    }
    public Sprite GetFront()
    {
        return front;
    }
    public Sprite GetBack()
    {
        return back;
    }

    public bool isRealPlayer()
    {
        return isRealPlayerCard;
    }
}
