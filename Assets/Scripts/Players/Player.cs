using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System;

public class Player : MonoBehaviour, IPokerObject,IPokerOwner
{
    public IntReference lastBet;
    public IntReference currentTurn;
    public IntReference gameRound;
    public IntReference totalBet;
    public Chipsparent chipparent;
    public ObjectVariable chipObject;
    public Image playerIcon;
    public Locations dealerPosition;
    public List<Locations> playerHandLocations = new List<Locations>();
    public TextMeshProUGUI playerNameDisplay;
    public TextMeshProUGUI cashDisplay;
    public TextMeshProUGUI currentBetTotalDisplay;
    public IntReference startCash;
    public List<IPokerObject> cards = new List<IPokerObject>();
    public int cash;
    public int currentBetTotal;
    public bool isTurn;
    public bool isRealPlayer;
    public string playerName;
    public int playerID;
    //public GameEvent Event;
    public GameObject dummy;
    MoverAbility moverAbility;
    bool hasMoverAbility;
    bool fillup;
    bool dontflip;
    bool dontswap;
    public PlayerRuntimeSet players;
    public Controls control;

    void OnEnable()
    {
        cash = startCash.Value;
        moverAbility = GetComponent<MoverAbility>();
        if (moverAbility != null)
            hasMoverAbility = true;

        players.Add(this);
    }
    void OnDisable()
    {
        players.Remove(this);
    }

    void UpdateTextDisplay()
    {
        cashDisplay.text = cash.ToString();
        currentBetTotalDisplay.text = currentBetTotal.ToString();
    }

    public void UpdatePlayerData(string name,Sprite sprite, List<IPokerObject> cards)
    {
        this.playerName = name;
        playerNameDisplay.text = name;
        gameObject.name = name;
        this.playerIcon.sprite = sprite;
        this.cards = cards;
        foreach(IPokerObject crd in cards)
        {
            Transform tr = (crd as Card).transform;
            tr.SetParent(transform);
            tr.localScale = Vector3.one;
        }
        if (isRealPlayer)
        {
            Controls contrl = Instantiate(control).GetComponent<Controls>();
            contrl.SetControls(this);
        }
        UpdateTextDisplay();
    }
    public void MoveToPlace()
    {
        if (hasMoverAbility && cards.Count > 0)
        {
            fillup = true;
            dontflip = false;
            dontswap = false;
            moverAbility.Move(cards, new List<Locations>() { dealerPosition, dealerPosition }, playerHandLocations, this);
        }
    }
    //bet amount
    public void Bet(int amount)
    {
        //Debug.Log("Betting");
        //remove amount from cash and add it to total bet
        cash -= amount;
        //add it to the current bet
        currentBetTotal += amount;

        lastBet.Variable.SetValue(amount);

        totalBet.Variable.ApplyChange(amount);

        //create chip that would be displayed
        GameObject go = Instantiate(chipObject.Value, transform.position, Quaternion.identity, chipparent.transform);

        Chip chip = go.GetComponent<Chip>();

        chip.parent = chipparent;

        go.transform.SetParent(chip.parent.PokerObject());

        //set the amount of the ship

        chip.SetAmount(amount);

        IPokerObject po = chip as IPokerObject;
        //move chip to the place set in the center
        if (hasMoverAbility)
        {
            moverAbility.Move(new List<IPokerObject>() { po }, new List<Locations>() { chipparent.startLocation }, new List<Locations>() { chipparent.endLocation(playerID + 1) }, chip.parent);
        }


        //go.transform.DOMove(DataHolders.chipPositionOnBoard.position, DataHolders.delaySpeed).OnComplete(() =>
        //{
        //    //update the ui text when the chip has arriced
        //    //UpdatePlayerUI();
        //    ////either stack chips or delete
        //    //if (DataHolders.chipPositionOnBoard.childCount < 4)
        //    //    go.transform.SetParent(DataHolders.chipPositionOnBoard);
        //    //else
        //    //    Destroy(go);
        //    ////to go to the next player
        //    //Next(DataHolders.currentTurn + 1);
        //});

    }
    public void Call()
    {
       // Bet(lastBet.Value);
        Bet(10);
    }
    public void Raise(int amount)
    {
        Bet(lastBet.Value + amount);
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
       Bet(cash);
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

    public Transform PokerObject()
    {
        return transform;
    }

    public bool fillUp()
    {
        return fillup;
    }

    public bool dontFlip()
    {
        return dontflip;

    }

    public bool dontSwap()
    {
        return dontswap; 
    }
    public Action action = new Action(finishedMovement);

    public static void finishedMovement()
    {
        Debug.Log("finished moving on player");
    }

    Action IPokerOwner.action()
    {
       // Debug.Log("finished moving on player 1" );
        return action;
    }
}
