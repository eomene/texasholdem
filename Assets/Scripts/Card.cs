using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardObject;
    public SpriteRenderer frontCard;
    public SpriteRenderer backCard;


    public void UpdateCardObject(CardData cardObject)
    {
        //set the look of the card and data for card
        this.frontCard.sprite = cardObject.front;
        this.backCard.sprite = cardObject.back;
        this.cardObject = cardObject;
        name = cardObject.cardType.ToString() + " " + cardObject.realValue;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
