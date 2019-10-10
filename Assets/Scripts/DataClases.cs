using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[System.Serializable]
public class RepeatOccurance
{
    public bool card;
    public Image img;
    public bool isFilled;

    //public CenterCard(GameObject card, Image img, bool isFilled)
    //{
    //    this.card = card;
    //    this.img = img;
    //    this.isFilled = isFilled;
    //}

}
[System.Serializable]
public class CenterCard
{
    public GameObject card;
    public Image img;
    public bool isFilled;

    public CenterCard(GameObject card, Image img,bool isFilled)
    {
        this.card = card;
        this.img = img;
        this.isFilled = isFilled;
    }

}

[System.Serializable]
public class Locations
{
    public Transform locationHolder;
    public Vector2 location
    {
        get
        {
            return locationHolder.localPosition;
        }
    }
    public bool isFilled;

    public Locations(Transform locationHolder, Vector2 location, bool isFilled)
    {
        this.locationHolder = locationHolder;
        this.isFilled = isFilled;
    }
    public Locations()
    {

    }
}
[System.Serializable]
public class GameEnums
{
    //public enum CardType { diamonds,hearts,spades,clubs};
    //public enum TypeOfRepeat { diamonds, hearts, spades, clubs };
    public enum CardEnum : int
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }
    public enum SuitEnum : int
    {
        Spades,
        Hearts,
        Clubs,
        Diamonds
    }
}
