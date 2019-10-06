using System.Collections;
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
    public GameObject card;

    public CardData(Sprite back, Sprite front, GameEnums.CardType cardType, int realValue, GameObject card)
    {
        this.back = back;
        this.front = front;
        this.cardType = cardType;
        this.realValue = realValue;
        this.card = card;
        //if (realValue >= 11)
        //this.realValue = 10;
        //if(realValue==10)
 
    }

}
[System.Serializable]
public class PlayerData
{
    public List<CardData> cards = new List<CardData>();
    public int cash;  
    public int currentBet;
    public int currentBetToTal;
    public bool isTurn;
    public bool isRealPlayer;
    public Sprite playerIcon;
    public string playerName;
    public GameObject playerGameObject;
    public Player player;
    public int playerID;

    public PlayerData(List<CardData> cards, int cash, int currentBet, Sprite playerIcon, string playerName, GameObject playerGameObject)
    {
        this.cards = cards;
        this.cash = cash;
        this.currentBet = currentBet;
        this.playerIcon = playerIcon;
        this.playerName = playerName;
        this.playerGameObject = playerGameObject;
        player = playerGameObject.GetComponent<Player>();
    }

    public void Bet(int amount){player.Bet(amount);}
    public void Call(){player.Call();}
    public void Raise(int amount){player.Raise(amount);}
    public void Fold(){player.Fold();}
    public void AllIn() {player.AllIn();}
    public void setToCurrent()
    {
        player.setToCurrent();
    }
}

[System.Serializable]
public class GameEnums
{
    public enum CardType { diamonds,hearts,spades,clubs};

}
