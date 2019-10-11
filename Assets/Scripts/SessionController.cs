using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using UnityEngine.Events;

public class IntEvent : UnityEvent<int>
{

}


public class SessionController : MonoBehaviour
{
    public int numberOfPlayers;
    public IntReference lastBet ;
    public IntReference currentTurn ;
    public IntReference totalBet ;
    public IntReference gameRound ;
    public IntList activePlayers;
    public GameEvent shouldPlay;
    void Start()
    {
        currentTurn.Variable.SetValue(0);
        totalBet.Variable.SetValue(0);
        gameRound.Variable.SetValue(0);
        lastBet.Variable.SetValue(0);
    }

    private void Update()
    {
        //if(players.Count() == numberOfPlayers)
        //{
        //    Debug.Log("all players avaialble");
        //    numberOfPlayers = 0;
        //    currentTurn.Variable.SetValue(1);
        //}
        //if (currentTurn.Value >= 7)
        //{
        //    currentTurn.Variable.SetValue(1);
        //}
    }

    public void NextPlayer()
    {

    }

    public void HasPlayed()
    {
        //Debug.Log("Hasraised subscribed event played from session controller");
        int nextPlayer = currentTurn.Value + 1;
        while (!activePlayers.Value.Contains(nextPlayer))
        {
            nextPlayer++;
            if (nextPlayer >= 5)
                nextPlayer = 0;
        }
        currentTurn.Variable.SetValue(nextPlayer);
       // Debug.Log("Raised has Shouldplay from session controller");
        shouldPlay.Raise();
    }
    public IEnumerator FirstPlay()
    {
       // MoveCardsToTable(Players[0].cards);
        yield return new WaitForSeconds(1);
        //bet 20 for first player
       // DataHolders.players[currentTurn.Value].Bet(20);
    }
    public IEnumerator Next(int current)
    {
        yield return new WaitForSeconds(1);
        //if ((current) < DataHolders.players.Count )
        //{
        //    currentTurn.Variable.SetValue(current);
        //    DataHolders.players[currentTurn].setToCurrent();
        //}
        //else
        //{
        //    gameRound.Variable.Value++;
        //    if (gameRound.Value == 1)
        //    {
        //        //List<CardData> dealercards = new List<CardData>();
        //        //add three of the last cards to the stack of card decks
        //        //DataHolders.dealerCards.Add(deck.Pop());
        //        //DataHolders.dealerCards.Add(deck.Pop());
        //        //DataHolders.dealerCards.Add(deck.Pop());
        //        //MoveCardsToTable(DataHolders.dealerCards);
        //    }
        //    else if (gameRound.Value == 2)
        //    {
        //        //List<CardData> dealercards = new List<CardData>();
        //        //add one of the last cards to the stack of card decks
        //        //DataHolders.dealerCards.Add(deck.Pop());
        //        //MoveCardsToTable(DataHolders.dealerCards);
        //    }
        //    else if (gameRound.Value == 3)
        //    {
        //        // List<CardData> dealercards = new List<CardData>();
        //        //add one of the last cards to the stack of card decks
        //        //DataHolders.dealerCards.Add(deck.Pop());
        //        //MoveCardsToTable(DataHolders.dealerCards);
        //    }
        //    else if (gameRound.Value == 4)
        //    {
        //        GameOver();
        //        //end game logic
        //        yield break;
        //    }
        //    yield return new WaitForSeconds(DataHolders.delaySpeed);
        //    currentTurn.Variable.SetValue(0);

        //    //DataHolders.players[DataHolders.currentTurn].setToCurrent();
        //}

    }




    public void GameOver()
    {
        Debug.Log("Game Ended");
        
        //equality is based on rank, not cards/suits/etc... so, for example, two Jack high straights
        //would be equal even though the cards have different suits.
    }

    public void ScaleDownMenu()
    {

    }

}
