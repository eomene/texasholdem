using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Linq;
using UnityEngine.Events;
using RoboRyanTron.Unite2017.Variables;

public class SessionController : MonoBehaviour
{
    public IntReference lastBet ;
    public IntReference currentTurn ;
    public IntReference totalBet ;
    public IntReference gameRound ;

    public static UnityEvent onPlayerTurnUpdated = new UnityEvent();
    public static UnityEvent onRoundUpdated = new UnityEvent();
    public static UnityEvent onTotalBetUpdated = new UnityEvent();
    public static UnityEvent onLastBetUpdated = new UnityEvent();


    void Init()
    {

        //DataHolders.gameController = this;
       // DataHolders.flyingCard = Resources.Load<GameObject>("FlyingCard");
        //DataHolders.chip = Resources.Load<GameObject>("Chip");

        //DataHolders.controls = Instantiate(Resources.Load<GameObject>("Controls"));
        //GameObject UIObject = Resources.Load<GameObject>("UIDisplay");
        //GameObject ui = Instantiate(UIObject, Canvas);
        //DataHolders.uIDisplay = ui.GetComponent<UIDisplay>();

        currentTurn.Variable.SetValue(0);
        totalBet.Variable.SetValue(0);
        gameRound.Variable.SetValue(0);
        lastBet.Variable.SetValue(0);

        
    }

 

   
    // Update is called once per frame
    void Update()
    {
        
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
