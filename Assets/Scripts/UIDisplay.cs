using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RoboRyanTron.Unite2017.Variables;

public class UIDisplay : MonoBehaviour
{
    public IntReference lastBet;
    public IntReference currentTurn;
    public IntReference totalBet;
    public IntReference gameRound;

    public TextMeshProUGUI playerTurnDisplay;
    public TextMeshProUGUI roundDisplay;
    public TextMeshProUGUI totalBetOfRoundDisplay;
    public TextMeshProUGUI lastBetDisplay;



    private void Start()
    {
        //foreach (Transform tr in centerCardsHolder)
        //    centerCards.Add(new CenterCard(tr.gameObject, tr.GetComponent<Image>(), false));
    }

    // Update is called once per frame
    void Update()
    {
        playerTurnDisplay.text = currentTurn.Value.ToString();
        roundDisplay.text = gameRound.Value.ToString();
        totalBetOfRoundDisplay.text = totalBet.Value.ToString();
        lastBetDisplay.text = lastBet.Value.ToString();
    }

}
