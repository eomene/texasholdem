using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCreator : MonoBehaviour
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

    private void Start()
    {
        StartCoroutine( CreatePlayers());
    }

    void GivePlayersCards()
    {




    }
    public void Update()
    {
    }
    public IEnumerator CreatePlayers()
    {
        for (int i = 0; i < playerPositions.Items.Count; i++)
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

            if (ca != null)
                cards = ca.GetCardsFromDeck();

            newPlayer.UpdatePlayerData(randomNames[i], playerIcons[UnityEngine.Random.Range(0, playerIcons.Length)], cards);
            newPlayer.playerID = i;

            players.Add(newPlayer.gameObject);

   

        }
        for (int i = 0; i < players.Count; i++)
        {
            players[i].GetComponent<Player>().MoveToPlace();
            yield return new WaitForSeconds(delaySpeed.Value);
        }
    }


}
