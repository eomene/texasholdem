using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaiseUIScript : MonoBehaviour
{
    public TextMeshProUGUI infoText; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateText(string text)
    {
        if (infoText != null)
            infoText.text = text;
    }
}
