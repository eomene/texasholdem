﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardData 
{
    public Sprite back;
    public Sprite front;
    public GameEnums.CardType cardType;
    public int realValue;
    public string visual;

    public CardData(Sprite back, Sprite front, GameEnums.CardType cardType, int realValue, GameObject card)
    {
        this.back = back;
        this.front = front;
        this.cardType = cardType;
        this.realValue = realValue;
        Card newCard = card.GetComponent<Card>();
        newCard.frontCard.sprite = front;
        newCard.backCard.sprite = back;
        newCard.cardObject = this;
    }

}
[System.Serializable]
public class Player
{
    public List<Card> cards = new List<Card>();
    public int cash;
    public int currentBet;
    public bool isTurn;
    public Sprite playerIcon;
    public string playerName;
}

[System.Serializable]
public class GameEnums
{
    public enum CardType { diamonds,hearts,spades,clubs};

}
