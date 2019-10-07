using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public PlayerData playerData;
    public Image playerIcon;
    public GameObject[] playerCards;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI cash;
    public TextMeshProUGUI currentBetTotal;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UpdatePlayerData(PlayerData playerData,Transform startFlyPsition)
    {
        DataHolders.tempCounter++;
        //update data for the player script using the player data 
        this.playerData = playerData;
        this.cash.text = playerData.cash.ToString();
        this.playerName.text = playerData.playerName.ToString();
        this.currentBetTotal.text = playerData.currentBet.ToString();
        this.cash.text = playerData.cash.ToString();
        this.playerIcon.sprite = playerData.playerIcon;
        StartCoroutine(delayCardDraw(startFlyPsition));
 

    }

    IEnumerator delayCardDraw(Transform startFlyPsition)
    {
        //loop through all the cards the player has, so we can display it
        for (int i = 0; i < playerCards.Length; i++)
        {
            //set the sprite 
            playerCards[i].GetComponent<Image>().sprite = playerData.cards[i].front;
            //create a dummy card to fly into the screen
            GameObject dummyCard = Instantiate(DataHolders.flyingCard, startFlyPsition.position, Quaternion.identity, playerData.playerGameObject.transform);
            //assign the real card
            GameObject playercard = playerCards[i];


            //move dummy card to the real card location
            dummyCard.transform.DOMove(playercard.transform.position, DataHolders.delaySpeed).OnComplete(() =>
            {
                //if real player flip card

                if (playerData.isRealPlayer)
                {
                    //when dummy card is at the real card location scale the x to zero, to give the illusion of flipping
                    dummyCard.transform.DOScaleX(0, DataHolders.cardFlipSpeed).OnComplete(() =>
                    {
                        //scale the real card to 1, card scale was previous 0. This completes the fliping illusion
                        playercard.transform.DOScaleX(1, DataHolders.cardFlipSpeed).OnComplete(() =>
                        {

                        });
                    });
                }
            }).SetEase(Ease.Linear);//set ease type for movement
            yield return new WaitForSeconds(4);
            //bet for the first two players just like in the real game
            if (DataHolders.tempCounter == DataHolders.players.Count && i == playerCards.Length - 1)
            {
                DataHolders.tempCounter = 0;
                DataHolders.gameController.StartCoroutine(DataHolders.gameController.FirstPlay());
            }
        }
    }
    //bet amount
    public void Bet(int amount)
    {
        //remove amount from cash and add it to total bet
        playerData.cash -= amount;
        //add it to the current bet
        playerData.currentBet += amount;

        DataHolders.lastBet = amount;

        DataHolders.totalBetOfRound += amount;

        //create chip that would be displayed
        GameObject go = Instantiate(DataHolders.chip,transform.position,Quaternion.identity,DataHolders.mainCanvas);
        //set the amount of the ship
        go.GetComponent<Chip>().SetAmount(amount);
        //move chip to the place set in the center
        go.transform.DOMove(DataHolders.chipPositionOnBoard.position, DataHolders.delaySpeed).OnComplete(()=>
        {
            //update the ui text when the chip has arriced
            UpdatePlayerUI();
            //either stack chips or delete
            if (DataHolders.chipPositionOnBoard.childCount < 4)
                go.transform.SetParent(DataHolders.chipPositionOnBoard);
            else
                Destroy(go);
            //to go to the next player
            Next(DataHolders.currentTurn + 1);
        });
       
    }
    public void Call()
    {
        Bet(DataHolders.lastBet);
    }
    public void Raise(int amount)
    {
        Bet(DataHolders.lastBet + amount);
    }
    public void Fold()
    {
        //remove player
       // DataHolders.currentPlayers.Remove(playerData.playerID);
        DataHolders.players.Remove(playerData);
        DataHolders.foldedPlayers.Add(playerData);
        //pass same id, since player has been removed from the list, to prevent skippig previous next player
        Next(DataHolders.currentTurn);
    }
    public void AllIn()
    {
        Bet(playerData.cash);
    }
    public void UpdatePlayerUI()
    {
        currentBetTotal.text = playerData.currentBet.ToString();
        cash.text = playerData.cash.ToString();
    }
    public void setToCurrent()
    {
       if(playerData.isRealPlayer)
        {
            Controls control = Instantiate(DataHolders.controls).GetComponent<Controls>();
            control.SetControls(playerData);
        }
       else
        {
            StartCoroutine(delayAIPlay());
        }
    }
    public void Next(int current)
    {
        DataHolders.gameController.StartCoroutine(DataHolders.gameController.Next(current));
    }
    IEnumerator delayAIPlay()
    {
        yield return new WaitForSeconds(1f);
        Call();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
