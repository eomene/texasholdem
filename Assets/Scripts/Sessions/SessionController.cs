using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using UnityEngine.Events;

public class SessionController : MonoBehaviour
{
    public int numberOfPlayers;
    public IntReference lastBet;
    public IntReference currentTurn;
    public IntReference totalBet;
    public IntReference gameRound;
    public IntList activePlayers;
    public GameEvent shouldPlay;
    MoverAbility moverAbility;
    bool hasMoverAbility;
    public Deck deck;
    IPokerOwner parent;
    public MoverParent uicards;
    List<IPokerObject> dealercards = new List<IPokerObject>();
    public IntVariable playerIncrease;
    public FloatReference delayeBetweenMiddleCard;
    public float defaultV;
    private void Awake()
    {
        moverAbility = GetComponent<MoverAbility>();
        if (moverAbility != null)
            hasMoverAbility = true;

        parent = uicards.GetComponent<IPokerOwner>();
        defaultV = delayeBetweenMiddleCard.Value;
        //delayeBetweenMiddleCard.Variable.SetValue(1);
    }
    private void OnDisable()
    {
        delayeBetweenMiddleCard.Variable.SetValue(defaultV);
    }
    void Start()
    {
        currentTurn.Variable.SetValue(0);
        totalBet.Variable.SetValue(0);
        gameRound.Variable.SetValue(0);
        lastBet.Variable.SetValue(0);
    }
    IEnumerator getCards(int numberOfCards)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            IPokerObject ob = deck.GetLast();
            dealercards.Add(ob);
            deck.RemoveLast();
            ob.GetPokerObject().transform.SetParent(uicards.parentOfPositions);
        }

        for (int i = 0; i < dealercards.Count; i++)
        {
            if (hasMoverAbility)
            {
                (parent as MoverParent).dontflip = false;
                (parent as MoverParent).isForRealPlayer = true;
                (parent as MoverParent).fillup = true;
                (parent as MoverParent).movespeed = delayeBetweenMiddleCard.Value;
                moverAbility.Move(new List<IPokerObject>() { dealercards[i] }, new List<Locations>() { uicards.startLocation }, new List<Locations>() { uicards.endLocationsList[i + 1] }, parent);
            }
            if (numberOfCards < 3)
                delayeBetweenMiddleCard.Variable.SetValue(0.1f);
            else
                delayeBetweenMiddleCard.Variable.SetValue(defaultV);
            yield return new WaitForSeconds(delayeBetweenMiddleCard.Value);
        }
        float t = delayeBetweenMiddleCard * dealercards.Count;
        yield return new WaitForSeconds(t);

        currentTurn.Variable.SetValue(activePlayers.Value[playerIncrease.Value]);
        shouldPlay.Raise();
    }

    public void HasPlayed()
    {
        playerIncrease.Value = playerIncrease.Value + 1;
        if (playerIncrease.Value < activePlayers.Value.Count)
        {
            currentTurn.Variable.SetValue(activePlayers.Value[playerIncrease.Value]);
            shouldPlay.Raise();
        }
        else
        {
            playerIncrease.Value = 0;
            gameRound.Variable.ApplyChange(1);
            if (gameRound.Value == 1)
                StartCoroutine(getCards(3));
            else if (gameRound.Value == 2)
                StartCoroutine(getCards(1));
            else if (gameRound.Value == 3)
                StartCoroutine(getCards(1));
            else if (gameRound.Value == 4)
                GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("Game Ended");

        //equality is based on rank, not cards/suits/etc... so, for example, two Jack high straights
        //would be equal even though the cards have different suits.
    }


}
