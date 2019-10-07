using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class CardData 
{
    public Sprite back;
    public Sprite front;
   // public GameEnums.CardType cardType;
    public GameEnums.CardEnum cardEnum;
    public GameEnums.SuitEnum suitEnum;
    public int realValue;
    public string visual;
    public GameObject card;


    public CardData(Sprite back, Sprite front, GameEnums.SuitEnum suitEnum,int value, GameObject card)
    {
        this.back = back;
        this.front = front;
        this.suitEnum = suitEnum;
        this.card = card;
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


    public int RankOfCards
    {
        get
        {
            return 0;
        }
    }

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
   
    //public int CalculateRank(List<CardData> cards)
    //{
    //    bool twoHasSameNumber = false;
    //    bool twoHasSameNumberTwice = false;
    //    bool threeHasSameNumber = false;
    //    bool allIncrementByOne = false;
    //    bool allHasSameSuit = false;


    //    bool allHasSameNumber = false;
       
    //    bool twoHasSameSuit = false;
    
    //    return 0;
    //}
}
[System.Serializable]
public class RepeatOccurance
{
    public bool card;
    public Image img;
    public bool isFilled;

    //public CenterCard(GameObject card, Image img, bool isFilled)
    //{
    //    this.card = card;
    //    this.img = img;
    //    this.isFilled = isFilled;
    //}

}
[System.Serializable]
public class CenterCard
{
    public GameObject card;
    public Image img;
    public bool isFilled;

    public CenterCard(GameObject card, Image img,bool isFilled)
    {
        this.card = card;
        this.img = img;
        this.isFilled = isFilled;
    }

}
[System.Serializable]
public class GameEnums
{
    //public enum CardType { diamonds,hearts,spades,clubs};
    //public enum TypeOfRepeat { diamonds, hearts, spades, clubs };
    public enum CardEnum : int
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
    public enum SuitEnum : int
    {
        Spades,
        Hearts,
        Clubs,
        Diamonds
    }
}
