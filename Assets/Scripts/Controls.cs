using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Controls : MonoBehaviour
{
    public PlayerData playerData;
    public TMP_InputField raiseAmount;
    public List<CardData> cards = new List<CardData>();
    public Transform cardsHolder;
    List<GameObject> cardVisual = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Transform tr in cardsHolder)
            cardVisual.Add(tr.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetControls(PlayerData playerData)
    {
        this.playerData = playerData;
        for (int i = 0; i < playerData.cards.Count; i++) 
        {
            cardVisual[i].GetComponent<Image>().sprite = playerData.cards[i].front;
            cardVisual[i].SetActive(true);
        }
        gameObject.SetActive(true);
    }
    public void Call()
    {
        playerData.Call();
        Destroy(gameObject);
    }
    public void Raise()
    {
        if (!string.IsNullOrEmpty(raiseAmount.text))
        {
            int val = 0;
            int.TryParse(raiseAmount.text, out val);
            playerData.Raise(val);
            Destroy(gameObject);
        }
    }
    public void Fold()
    {
        playerData.Fold();
        Destroy(gameObject);
    }
    public void AllIn()
    {
        playerData.AllIn();
        Destroy(gameObject);
    }
}
