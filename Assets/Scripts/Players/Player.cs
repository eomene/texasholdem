using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System;

public interface IPlayer
{
    UnityAction action { get; set; }
    bool dontFlip { get; set; }
    bool dontSwap { get; set; }
    bool fillUp { get; set; }
    GameObject GetPokerObject { get; }
    Transform PokerObject { get; }
    float speed { get; }

    void AddToPlayers();
    void AllIn();
    void Bet(int amount);
    void Call();
    void Fold();
    void MoveToPlace();
    void Raise(int amount);
    void RealPlayerHasPlayed();
    void ShouldPlay();
    void UpdatePlayerData(string name, Sprite sprite, List<IPokerObject> cards);
}

public class Player : MonoBehaviour, IPokerObject, IPokerOwner, IPlayer
{
    public IntReference lastBet;
    public IntReference currentTurn;
    public IntReference gameRound;
    public IntReference totalBet;
    public MoverParent chipparent;
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
   // public bool isRealPlayer;
    public string playerName;
    public int playerID;
    MoverAbility moverAbility;
    bool hasMoverAbility;
    //bool fillup;
    //bool dontflip;
    //bool dontswap;
    public PlayerRuntimeSet players;
    public GameObject control;
    public GameEvent hasPlayed;
    public IntList activePlayers;
    [HideInInspector]
    public GameObject controller;
    public IntVariable playerIncrease;

    public float movespeed = 1;

    public GameObject GetPokerObject { get { return gameObject; } }

    public bool fillUp { get; set; }
    public bool dontFlip { get; set; }
    public bool dontSwap { get; set; }
    public bool isRealPlayer { get ; set; }
    public Transform PokerObject { get { return transform; } }
    public UnityAction action { get; set; }
    public float speed { get { return movespeed; } set { movespeed = value; } }

    void OnEnable()
    {
        cash = startCash.Value;
        moverAbility = GetComponent<MoverAbility>();
        if (moverAbility != null)
            hasMoverAbility = true;

        // actionReal += finishedMovement;
    }
    void OnDisable()
    {
        players.Remove(this);
        if (activePlayers.Value.Contains(playerID))
            activePlayers.Value.Remove(playerID);
    }
    IEnumerator moveCardsToHand(int numberOfCards)
    {
        //if (hasMoverAbility && cards.Count >= numberOfCards)
        //{
        //    for (int i = 0; i < 1; i++)
        //    {
        //        IPokerObject ob = cards[i];
        //        ob.GetPokerObject().transform.SetParent(handparent.parentOfPositions);
        //        handparent.dontflip = false;
        //        handparent.isForRealPlayer = true;
        //        handparent.fillup = true;
        //        moverAbility.Move(new List<IPokerObject>() { ob }, new List<Locations>() { handparent.startLocation }, new List<Locations>() { handparent.endLocationsList[i] }, handparent);
        yield return new WaitForSeconds(1);
        //    }
        //}
    }
    void UpdateTextDisplay()
    {
        cashDisplay.text = cash.ToString();
        currentBetTotalDisplay.text = currentBetTotal.ToString();
    }

    public void UpdatePlayerData(string name, Sprite sprite, List<IPokerObject> cards)
    {
        this.playerName = name;
        playerNameDisplay.text = name;
        gameObject.name = name;
        this.playerIcon.sprite = sprite;
        this.cards = cards;
        foreach (IPokerObject crd in cards)
        {
            Transform tr = (crd as Card).transform;
            tr.SetParent(transform);
            tr.localScale = Vector3.one;
        }
        if (isRealPlayer)
        {
            GameObject obj = Instantiate(control);
            Controls contrl = obj.GetComponent<Controls>();
            contrl.SetControls(this);
            controller = contrl.controller;
            //  contrl.ShowCards(true);
        }
        UpdateTextDisplay();
    }
    public void MoveToPlace()
    {
        // StartCoroutine(moveCardsToHand(2));
        if (hasMoverAbility && cards.Count > 0)
        {
            fillUp = false;
            dontFlip = false;
            dontSwap = false;
            movespeed = 1f;
            for (int i = 0; i < playerHandLocations.Count; i++)
            {
                moverAbility.Move(new List<IPokerObject>() { cards[i] }, new List<Locations>() { dealerPosition }, new List<Locations>() { playerHandLocations[i] }, this);
            }
        }
    }
    public void AddToPlayers()
    {
        players.Add(this);
        activePlayers.Value.Add(playerID);

        if (activePlayers.Value.Count >= 6)
        {
            currentTurn.Variable.SetValue(-1);
            playerIncrease.Value = -1;
            //  Debug.Log("Hasraised played from player controller after adding all players");
            hasPlayed.Raise();
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

        // playerIncrease.Value += 1;
        //create chip that would be displayed
        GameObject go = Instantiate(chipObject.Value, transform.position, Quaternion.identity, chipparent.transform);

        Chip chip = go.GetComponent<Chip>();

        chip.parent = chipparent;

        go.transform.SetParent(chip.parent.PokerObject);

        //set the amount of the ship

        chip.SetAmount(amount);

        IPokerObject po = chip as IPokerObject;
        //move chip to the place set in the center
        if (hasMoverAbility)
        {
            moverAbility.Move(new List<IPokerObject>() { po }, new List<Locations>() { chipparent.startLocation }, new List<Locations>() { chipparent.endLocationsList[playerID + 1] }, chip.parent);
        }

        UpdateTextDisplay();

    }
    public void Call()
    {
        Bet(lastBet.Value);
    }
    public void Raise(int amount)
    {
        Bet(lastBet.Value + amount);
    }
    public void Fold()
    {
        if (activePlayers.Value.Contains(playerID))
            activePlayers.Value.Remove(playerID);
        playerIncrease.Value -= 1;
    }
    public void AllIn()
    {
        Bet(cash);
    }

    public void ShouldPlay()
    {
        if (currentTurn == playerID)
        {
            if (!isRealPlayer)
                StartCoroutine(delayBet());
            else
                controller.SetActive(true);
        }
    }
    void showControl()
    {
        Controls contrl = control.GetComponent<Controls>();
        contrl.ShowCards(true);
    }
    public void RealPlayerHasPlayed()
    {
        hasPlayed.Raise();
    }

    IEnumerator delayBet()
    {
        Bet(20);
        yield return new WaitForSeconds(1f);
        hasPlayed.Raise();
    }

}
