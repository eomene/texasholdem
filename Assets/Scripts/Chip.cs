using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Chip : MonoBehaviour,IPokerObject
{
    public Locations startLocation;
    public Locations endLocation;
    public IPokerOwner parent;
    public ObjectVariable endObject;
    //public ObjectVariable parentObject;
    public int value;
    public Image img;
    public TextMeshProUGUI amount;
    // Start is called before the first frame update
    void Start()
    {
        //incase sprites should be changed with value
        img = GetComponent<Image>();
        startLocation = new Locations(transform, false);
        endLocation = new Locations(endObject.Value.transform, false);
        parent = endObject.Value.GetComponent<IPokerOwner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetAmount(int amount)
    {
        value = amount;
        this.amount.text = amount.ToString();
    }

    public GameObject GetPokerObject()
    {
        return gameObject;
    }
}
