using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ICard
{
    Sprite GetBack { get; }
    Sprite GetFront { get; }
    GameObject GetPokerObject { get; }
    void OnDisable();
    void SetUpCard(Sprite back, Sprite front, GameEnums.SuitEnum suitEnum, int value);
}

public class Card : MonoBehaviour, IPokerObject, IPokerSpriteBack, IPokerSpriteFront, ICard
{
    CardInternal cardInternal;
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

    public GameObject GetPokerObject { get { return gameObject; } }

    public Sprite GetBack { get { return back; }}
    public Sprite GetFront { get { return front; } }

    private void Awake()
    {
        cardInternal = new CardInternal();
    }
    private void OnEnable()
    {
        if (RuntimeDeck != null) 
        RuntimeDeck.Add(this);
        // Debug.Log("Deck Count: "+ RuntimeDeck.Count());
    }

    public void OnDisable()
    {
        if (RuntimeDeck != null)
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

        cardInternal.SetUpCard(back, front, suitEnum, value, View);
        gameObject.name = suitEnum.ToString() + cardEnum.ToString();
    }


}
public class CardInternal
{
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
    public void SetUpCard(Sprite back, Sprite front, GameEnums.SuitEnum suitEnum, int value, Image View)
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
    }
}
