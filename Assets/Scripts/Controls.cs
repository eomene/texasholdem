using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class Controls : MonoBehaviour
{
    public PlayerData playerData;
    public TMP_InputField raiseAmount;
    public List<CardData> cards = new List<CardData>();
    public Transform cardsHolder;
    List<GameObject> cardVisual = new List<GameObject>();
    public RaiseUIScript raiseUI;
    public Transform final;
    Vector3 prevLocation;
    public GameObject clickBlocker;
    bool isActive;
    public bool allowClick;
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
    }

    public void ShowCards()
    {
        cardsHolder.DOMoveY(final.transform.position.y, 1f).OnComplete(() => 
        {
            if(allowClick)
            clickBlocker.SetActive(false);
        });
        
    }
    public void HideCards()
    {
        cardsHolder.DOMoveY(prevLocation.y, DataHolders.delaySpeed).OnComplete(()=> { clickBlocker.SetActive(true); });
    }
    public void ToggleCardHolder()
    {
        if (allowClick) return;
        isActive = !isActive;
        if (isActive)
            ShowCards();
        else
            HideCards();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowText(string text)
    {
        raiseUI.UpdateText(text);
        raiseUI.gameObject.SetActive(true);
    }

    public void SetControls(PlayerData playerData)
    {
        this.playerData = playerData;
        if (cardVisual.Count >= playerData.cards.Count)
        {
            for (int i = 0; i < playerData.cards.Count; i++)
            {
                cardVisual[i].GetComponent<Image>().sprite = playerData.cards[i].front;
                cardVisual[i].SetActive(true);
            }
            //gameObject.SetActive(true);
            allowClick = true;
        }
        else
        {
            Debug.Log("cardVisual.Count: " + cardVisual.Count + "playerData.cards.Count: " + playerData.cards.Count);
        }
        ShowCards();
    }
    public void Call()
    {
        playerData.Call();
        HideCards();
        allowClick = false;
        // Destroy(gameObject);
    }
    public void Raise()
    {
        if (!string.IsNullOrEmpty(raiseAmount.text) && int.Parse(raiseAmount.text) >= (DataHolders.lastBet * 2))
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
            ShowText("Enter amount to raise, It should be at least double current bet of " + DataHolders.lastBet);
        }
        else if (!string.IsNullOrEmpty(raiseAmount.text) && int.Parse(raiseAmount.text)<(DataHolders.lastBet * 2))
        {
            ShowText("Please enter an amount that is at least double current bet of " + DataHolders.lastBet);
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
