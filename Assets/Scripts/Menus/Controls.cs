using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class Controls : MonoBehaviour
{
    public IntReference lastBet;
    public PlayerRuntimeSet player;
    public TMP_InputField raiseAmount;
    public List<Card> cards = new List<Card>();
    public Transform cardsHolder;
    List<GameObject> cardVisual = new List<GameObject>();
    public RaiseUIScript raiseUI;
    public Transform final;
    Vector3 prevLocation;
    public GameObject clickBlocker;
    bool isActive;
    public bool allowClick;
    public GameObject dealerPosition;
    Player playerData;
    public GameObject controller;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Transform tr in cardsHolder)
            cardVisual.Add(tr.gameObject);
        prevLocation = cardsHolder.transform.position;


    }
    private void OnEnable()
    {
        //  cardsHolder.DOMoveY(final.transform.position.y, 1f);
       // ShowCards(true);
    }

    public void ShowCards(bool allowClick)
    {
        this.allowClick = allowClick;
       // Debug.Log("Is real player, waiting fr input");
        cardsHolder.DOMoveY(final.transform.position.y, 1f).OnComplete(() => 
        {
          //  Debug.Log("Is real player, finished moving up");
            clickBlocker.SetActive(!allowClick);
        });
        
    }
    public void HideCards()
    {
        clickBlocker.SetActive(true);
        cardsHolder.DOMoveY(prevLocation.y, 1).OnComplete(()=> 
        {
          
            playerData.RealPlayerHasPlayed();
            controller.SetActive(false);
        });
    }
    public void ToggleCardHolder()
    {
        if (allowClick) return;
        isActive = !isActive;
        if (isActive)
            ShowCards(false);
        else
            HideCards();

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void ShowText(string text)
    {
        raiseUI.gameObject.SetActive(true);
        raiseUI.UpdateText(text);

    }

    public void SetControls(Player playerData)
    {
        this.playerData = playerData;
        if (cardVisual.Count >= playerData.cards.Count)
        {
            for (int i = 0; i < playerData.cards.Count; i++)
            {
                cardVisual[i].GetComponent<Image>().sprite = (playerData.cards[i] as Card).front;
                cardVisual[i].SetActive(true);
            }
            //gameObject.SetActive(true);
            allowClick = true;
        }
        else
        {
            Debug.Log("cardVisual.Count: " + cardVisual.Count + "playerData.cards.Count: " + playerData.cards.Count);
        }
        //ShowCards();
    }
    public void Call()
    {
        playerData.Call();
        HideCards();
        allowClick = false;
    }
    public void Raise()
    {
        if (!string.IsNullOrEmpty(raiseAmount.text) && int.Parse(raiseAmount.text) >= (lastBet.Value * 2))
        {
            int val = 0;
            int.TryParse(raiseAmount.text, out val);
            playerData.Raise(val);
            // Destroy(gameObject);

            HideCards();
            allowClick = false;
        }
        else if (string.IsNullOrEmpty(raiseAmount.text))
        {
            ShowText("Enter amount to raise, It should be at least double current bet of " + lastBet.Value);
        }
        else if (!string.IsNullOrEmpty(raiseAmount.text) && int.Parse(raiseAmount.text) < (lastBet.Value * 2))
        {
            ShowText("Please enter an amount that is at least double current bet of " + lastBet.Value);
        }
    }
    public void Fold()
    {
        playerData.Fold();
        HideCards();
        allowClick = false;
        //Destroy(gameObject);
    }
    public void AllIn()
    {
        playerData.AllIn();
        HideCards();
        allowClick = false;
        //Destroy(gameObject);
    }
}
