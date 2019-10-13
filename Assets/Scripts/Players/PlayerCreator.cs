using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerCreator
{
    IEnumerator CreatePlayers();
}

public class PlayerCreator : MonoBehaviour, IPlayerCreator
{
    public IntReference maxNumberOfPlayers;
    int numberOfPlayers;
    public ObjectVariable player;
    public ObjectVariable dealerLocation;
    public ThingRuntimeSet playerPositions;
    public FloatReference delaySpeed;
    public StringVariable playerIconsLocation;
    List<GameObject> players = new List<GameObject>();
    List<Locations> dealerPosition = new List<Locations>();
    Sprite[] playerIcons;
    string[] randomNames = new string[] { "Jude", "Fred", "Emma", "Joe", "Chris", "Jerry" };
    bool hasAllPlayers;
    List<IPokerObject> cards = new List<IPokerObject>();
    public Deck deck;
    IDeck realDeck;
    int maxPlayerCards = 2;
    private void Awake()
    {
        realDeck = deck;
    }
    private void Start()
    {
        StartCoroutine(CreatePlayers());
    }

    public IEnumerator CreatePlayers()
    {
        if (maxNumberOfPlayers > playerPositions.Items.Count)
        {
            Debug.Log("Table can handle only " + playerPositions.Items.Count + "Players");
            yield break;
        }
        for (int i = 0; i < maxNumberOfPlayers.Value; i++)
        {
            //create a new player gameobject in one of the positions already set in the scene
            GameObject newPlayerGameObject = Instantiate(player.Value, playerPositions.Items[i]);
            //make sure its in the centre
            newPlayerGameObject.transform.localPosition = Vector3.zero;
            //get the player script attached to it
            Player newPlayer = newPlayerGameObject.GetComponent<Player>();

            dealerPosition.Add(newPlayer.dealerPosition);

            playerIcons = Resources.LoadAll<Sprite>(playerIconsLocation.Value);

            GetCardsFromDeckAbility ca = GetComponent<GetCardsFromDeckAbility>();

            if (i == 2)
                newPlayer.isRealPlayer = true;

            if (ca != null && realDeck.Count() > 0)
                cards = ca.GetCardsFromDeck(maxPlayerCards);
            else
            {
                Debug.Log("there might be no deck in scene");
            }

            newPlayer.UpdatePlayerData(randomNames[i], playerIcons[UnityEngine.Random.Range(0, playerIcons.Length)], cards);
            newPlayer.playerID = i;

            players.Add(newPlayer.gameObject);



        }
        // yield return new WaitForSeconds(2);

        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<Player>().MoveToPlace();
            yield return new WaitForSeconds(delaySpeed.Value);
            players[i].GetComponent<Player>().AddToPlayers();
        }
    }


}
