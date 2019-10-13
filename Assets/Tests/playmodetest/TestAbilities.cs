using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

namespace Tests
{
    public class TestAbilities
    {

        [UnityTest]
        public IEnumerator Test_MoveAbility()
        {
            MoverAbilityInternal moverAbility = new MoverAbilityInternal();

            GameObject startLocationObject = new GameObject();
            startLocationObject.transform.position = new Vector2(0, 0);
            Locations startLocations = new Locations(startLocationObject.transform, startLocationObject.transform.position, false);

            GameObject endLocationObject = new GameObject();
            endLocationObject.transform.position = new Vector2(0, 20);
            Locations endLocations = new Locations(endLocationObject.transform, endLocationObject.transform.position, false);

            IPokerOwner parent = Substitute.For<IPokerOwner>();
            parent.speed = 2f;
            GameObject card = new GameObject("card");
            Card po = card.AddComponent<Card>();
            ISpriteSwaperAbility swaperAbility = Substitute.For<ISpriteSwaperAbility>();
            ICardFlipAbility cardFlipAbility = Substitute.For<ICardFlipAbility>();
            moverAbility.Move(new List<IPokerObject>() { po as IPokerObject }, new List<Locations>() { startLocations }, new List<Locations>() { endLocations }, parent,true,true, swaperAbility,cardFlipAbility);
            yield return new WaitForSeconds(parent.speed + 0.5f);
            Assert.AreEqual(endLocationObject.transform.position,po.transform.position);

        }
        [UnityTest]
        public IEnumerator Test_SpriteSwapAbility()
        {
            SpriteSwaperAbilityInternal swapAbility = new SpriteSwaperAbilityInternal();
            GameObject card = new GameObject("card");
            Card po = card.AddComponent<Card>();
            Image img = card.AddComponent<Image>();
            Texture2D tex = new Texture2D(10,10);
            Sprite sprf = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            sprf.name = "front Sprite";
            Sprite sprb = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            sprb.name = "back Sprite";

            po.front = sprf;
            po.back = sprb;
            po.View = img;

            Sprite sprDefault = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            sprDefault.name = "default Sprite";
            img.sprite = sprDefault;

            swapAbility.SwapSprites(card, true);
            yield return new WaitForSeconds(0.5f);
            Assert.AreEqual(img.sprite.name, po.front.name);

        }

        [UnityTest]
        public IEnumerator Test_SpriteFlipAbility()
        {
            CardFlipAbilityInternal cardFlipAbility = new CardFlipAbilityInternal();
            ISpriteSwaperAbility spriteSwaperAbility = Substitute.For<ISpriteSwaperAbility>();
            GameObject card = new GameObject("card");
            Card po = card.AddComponent<Card>();
            Image img = card.AddComponent<Image>();
            Texture2D tex = new Texture2D(10, 10);
            Sprite sprf = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            sprf.name = "front Sprite";
            Sprite sprb = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            sprb.name = "back Sprite";

            po.front = sprf;
            po.back = sprb;
            po.View = img;

            Sprite sprDefault = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
            sprDefault.name = "default Sprite";
            img.sprite = sprDefault;
            float speed = 1f;
            cardFlipAbility.FlipCards(card, false, spriteSwaperAbility, speed);
            yield return new WaitForSeconds(speed);
            Assert.AreEqual(card.transform.localScale.x, 0);
            yield return new WaitForSeconds(speed);
            Assert.AreEqual(card.transform.localScale.x, 1);

        }
    }
}
