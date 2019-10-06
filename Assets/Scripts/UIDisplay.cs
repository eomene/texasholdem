using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    public TextMeshProUGUI numberOfPlayers;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberOfPlayers.text = "Player Turn: " + (DataHolders.currentTurn + 1).ToString();
    }
}
