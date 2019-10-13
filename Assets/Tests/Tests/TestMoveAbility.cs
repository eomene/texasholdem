using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using NSubstitute;
namespace Tests
{
    public class TestMoveAbility
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestMoveAbilitySimplePasses()
        {
            DeckCreatorInternal deckCreatorInternal = new DeckCreatorInternal();    
            IDeck deck = Substitute.For<IDeck>();
            GameObject card = new GameObject();
            GameObject owner = new GameObject();
            int count = deckCreatorInternal.CreateDeck(deck, "Cards/diamonds", "Cards/clubs", "Cards/hearts", "Cards/spades", "Cards/back", card, owner, false);
            Assert.AreEqual(6, count);
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestMoveAbilityWithEnumeratorPasses()
        {
           // MoverAbility moverAbility = new MoverAbility();
            //IPokerObject po = Substitute.For<IPokerObject>();

            GameObject startLocationObject = new GameObject();
            startLocationObject.transform.position = new Vector2(0, 0);
            Locations startLocations = new Locations(startLocationObject.transform, startLocationObject.transform.position, false);

            GameObject endLocationObject = new GameObject();
            endLocationObject.transform.position = new Vector2(0, 0);
            Locations endLocations = new Locations(endLocationObject.transform, endLocationObject.transform.position, false);

          //  IPokerOwner parent = Substitute.For<IPokerOwner>();

           // parent.speed = 2f;

           // moverAbility.Move(new List<IPokerObject>() { po }, new List<Locations>() { startLocations }, new List<Locations>() { endLocations }, parent);
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return new WaitForSeconds(0.5f);
            LogAssert.Expect(LogType.Log, "endLocationObject.transform.position" + endLocationObject.transform.position + "po.GetPokerObject.transform.position" + endLocationObject.transform.position);

            Assert.AreEqual(endLocationObject.transform.position,startLocationObject.transform.position);
            
        }
    }
}
