using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    public TextMeshProUGUI playerTurn;
    public TextMeshProUGUI round;
    public TextMeshProUGUI totalBetOfRound;
    public TextMeshProUGUI lastBet;
    public Transform centerCardsHolder;
    public List<CenterCard> centerCards = new List<CenterCard>();


    private void Start()
    {
        foreach (Transform tr in centerCardsHolder)
            centerCards.Add(new CenterCard(tr.gameObject, tr.GetComponent<Image>(), false));
    }
    // Start is called before the first frame update
    void OnEnable()
    {
        DataHolders.onPlayerTurnUpdated.AddListener(UpdatePlayerTurn);
        DataHolders.onRoundUpdated.AddListener(UpdateRound);
        DataHolders.onTotalBetUpdated.AddListener(UpdateTotalBet);
        DataHolders.onLastBetUpdated.AddListener(UpdateLastBet);
    }
    void OnDisable()
    {
        DataHolders.onPlayerTurnUpdated.RemoveListener(UpdatePlayerTurn);
        DataHolders.onRoundUpdated.RemoveListener(UpdateRound);
        DataHolders.onTotalBetUpdated.RemoveListener(UpdateTotalBet);
        DataHolders.onLastBetUpdated.RemoveListener(UpdateLastBet);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    public void UpdatePlayerTurn()
    {
        playerTurn.text = "Current Turn: "+DataHolders.currentTurnStr;
    }
    public void UpdateRound()
    {
        round.text = "Current Round: "+DataHolders.gameRoundStr;
    }
    public void UpdateTotalBet()
    {
        totalBetOfRound.text = "Total Bet: " + DataHolders.totalBetOfRoundStr;
    }
    public void UpdateLastBet()
    {
        lastBet.text = "Last Bet: " + DataHolders.lastBet;
    }
}
