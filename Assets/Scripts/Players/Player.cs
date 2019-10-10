using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class Player : MonoBehaviour, IPokerObject,IPokerOwner
{
    public Image playerIcon;
    public Locations dealerPosition;
    public List<Locations> playerHandLocations = new List<Locations>();
    public TextMeshProUGUI playerNameDisplay;
    public TextMeshProUGUI cashDisplay;
    public TextMeshProUGUI currentBetTotalDisplay;
    public IntReference startCash;
    List<IPokerObject> cards = new List<IPokerObject>();
    public int cash;
    public int currentBetTotal;
    public bool isTurn;
    public bool isRealPlayer;
    public string playerName;
    public int playerID;
    //public GameEvent Event;
    public GameObject dummy;

    void Start()
    {
        cash = startCash.Value;
        GetCardsFromDeckAbility ca = GetComponent<GetCardsFromDeckAbility>();
    }

    void UpdateTextDisplay()
    {
        cashDisplay.text = cash.ToString();
        currentBetTotalDisplay.text = currentBetTotal.ToString();
    }

    public void UpdatePlayerData(string name,Sprite sprite, List<IPokerObject> cards)
    {
        this.playerName = name;
        playerNameDisplay.text= name;
        gameObject.name = name;
        this.playerIcon.sprite = sprite;
        this.cards = cards;
        UpdateTextDisplay();
    }
    public void MoveToPlace()
    {
        MoverAbility ma = GetComponent<MoverAbility>();
        if (ma != null && cards.Count > 0)
            ma.Move(cards, new List<Locations>() { dealerPosition, dealerPosition }, playerHandLocations, this);
    }
    //bet amount
    public void Bet(int amount)
    {
        ////remove amount from cash and add it to total bet
        //playerData.cash -= amount;
        ////add it to the current bet
        //playerData.currentBet += amount;

        //DataHolders.lastBet = amount;

        //DataHolders.totalBetOfRound += amount;

        ////create chip that would be displayed
        //GameObject go = Instantiate(DataHolders.chip,transform.position,Quaternion.identity,DataHolders.mainCanvas);
        ////set the amount of the ship
        //go.GetComponent<Chip>().SetAmount(amount);
        ////move chip to the place set in the center
        //go.transform.DOMove(DataHolders.chipPositionOnBoard.position, DataHolders.delaySpeed).OnComplete(()=>
        //{
        //    //update the ui text when the chip has arriced
        //    UpdatePlayerUI();
        //    //either stack chips or delete
        //    if (DataHolders.chipPositionOnBoard.childCount < 4)
        //        go.transform.SetParent(DataHolders.chipPositionOnBoard);
        //    else
        //        Destroy(go);
        //    //to go to the next player
        //    Next(DataHolders.currentTurn + 1);
        //});
       
    }
    public void Call()
    {
      //  Bet(DataHolders.lastBet);
    }
    public void Raise(int amount)
    {
      //  Bet(DataHolders.lastBet + amount);
    }
    public void Fold()
    {
        //remove player
       // DataHolders.currentPlayers.Remove(playerData.playerID);
        //DataHolders.players.Remove(playerData);
        //DataHolders.foldedPlayers.Add(playerData);
        ////pass same id, since player has been removed from the list, to prevent skippig previous next player
        //Next(DataHolders.currentTurn);
    }
    public void AllIn()
    {
        //Bet(playerData.cash);
    }
    public void UpdatePlayerUI()
    {
        //currentBetTotal.text = playerData.currentBet.ToString();
        //cash.text = playerData.cash.ToString();
    }
    public void setToCurrent()
    {
       //if(playerData.isRealPlayer)
       // {
       //     Controls control = DataHolders.controls.GetComponent<Controls>();
       //     control.SetControls(playerData);
       // }
       //else
       // {
       //     StartCoroutine(delayAIPlay());
       // }
    }
    public void Next(int current)
    {
      //  DataHolders.gameController.StartCoroutine(DataHolders.gameController.Next(current));
    }
    IEnumerator delayAIPlay()
    {
        yield return new WaitForSeconds(1f);
        Call();
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
        return playerIcon.sprite; ;
    }
    public Sprite GetBack()
    {
        return playerIcon.sprite; ;
    }

    bool IPokerOwner.isRealPlayer()
    {
        return isRealPlayer;
    }
}
