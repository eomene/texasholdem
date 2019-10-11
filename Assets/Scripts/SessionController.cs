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
    public IntReference lastBet ;
    public IntReference currentTurn ;
    public IntReference totalBet ;
    public IntReference gameRound ;
    public IntList activePlayers;
    public GameEvent shouldPlay;
    MoverAbility moverAbility;
    bool hasMoverAbility;
    public Deck deck;
    IPokerOwner parent;
    public Chipsparent uicards;
   // int nextPlayer = -1;
    List<IPokerObject> dealercards = new List<IPokerObject>();
    public IntVariable playerIncrease;
    bool moveForward = true;
    private void Awake()
    {
        moverAbility = GetComponent<MoverAbility>();
        if (moverAbility != null)
            hasMoverAbility = true;

        parent = uicards.GetComponent<IPokerOwner>();
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
                (parent as Chipsparent).dontflip = false;
                (parent as Chipsparent).isForRealPlayer = true;
                (parent as Chipsparent).fillup = true;
                moverAbility.Move(new List<IPokerObject>() { dealercards[i] }, new List<Locations>() { uicards.startLocation }, new List<Locations>() { uicards.endLocationsList[i + 1] }, parent);
            }
            yield return new WaitForSeconds(0.5f);
        }
        float t = 0.5f * dealercards.Count;
        yield return new WaitForSeconds(t);
        moveForward = true;
        currentTurn.Variable.SetValue(activePlayers.Value[playerIncrease.Value]);
        shouldPlay.Raise();
    }

    public void HasPlayed()
    {
        Debug.Log("has played");
        playerIncrease.Value = playerIncrease.Value + 1;
        if (playerIncrease.Value < activePlayers.Value.Count)
        {
            //if (moveForward)
            //{
             //   Debug.Log("Next Index: " + playerIncrease.Value + "next id" + activePlayers.Value[playerIncrease.Value]);
                currentTurn.Variable.SetValue(activePlayers.Value[playerIncrease.Value]);
                shouldPlay.Raise();
           // }
        }
        else
        {
          // moveForward = false;
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





        //while (!activePlayers.Value.Contains(nextPlayer) && gameRound.Variable.Value < 4) 
        //{
        //    nextPlayer++;
        //    if (nextPlayer >= activePlayers.Value.Count - 1) 
        //    {
        //        moveForward = false;
        //        nextPlayer = 0;
        //        gameRound.Variable.ApplyChange(1);
        //        if (gameRound.Value == 1)
        //            StartCoroutine(getCards(3));
        //        else if (gameRound.Value == 2)
        //            StartCoroutine(getCards(1));
        //        else if (gameRound.Value == 3)
        //            StartCoroutine(getCards(1));
        //        else if (gameRound.Value == 4)
        //            GameOver();
        //    }
        //}
        //if (moveForward)
        //{
        //    Debug.Log("Next Index: " + nextPlayer + "next id" + activePlayers.Value[nextPlayer]);
        //    currentTurn.Variable.SetValue(activePlayers.Value[nextPlayer]);
        //    shouldPlay.Raise();
        //}
    }

    public void GameOver()
    {
        Debug.Log("Game Ended");
        
        //equality is based on rank, not cards/suits/etc... so, for example, two Jack high straights
        //would be equal even though the cards have different suits.
    }


}
