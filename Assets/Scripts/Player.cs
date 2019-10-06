using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public PlayerData playerData;
    public Transform location;
    public Image playerIcon;
    public GameObject[] playerCards;
    public TextMeshProUGUI playerName;
    public TextMeshProUGUI cash;
    public TextMeshProUGUI currentBet;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void UpdatePlayerData(PlayerData playerData,Transform startFlyPsition)
    {
        this.playerData = playerData;
        this.cash.text = playerData.cash.ToString();
        this.playerName.text = playerData.playerName.ToString();
        this.currentBet.text = playerData.currentBet.ToString();
        this.cash.text = playerData.cash.ToString();
        this.playerIcon.sprite = playerData.playerIcon;
        for(int i =0;i<playerCards.Length;i++)
        {
            playerCards[i].GetComponent<Image>().sprite = playerData.cards[i].front;
            GameObject dummyCard = Instantiate(DataHolders.flyingCard, startFlyPsition.position,Quaternion.identity,playerData.playerGameObject.transform);
            GameObject playercard = playerCards[i];
             dummyCard.transform.DOMove(playercard.transform.position, DataHolders.cardFlySpeed).OnComplete(() =>
            {
                dummyCard.transform.DOScaleX(0, DataHolders.cardFlipSpeed).OnComplete(() =>
                {
                    playercard.transform.DOScaleX(1, DataHolders.cardFlipSpeed).OnComplete(() =>
                    {

                    });
                });
             }).SetEase(Ease.Linear);
        }

    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
}
