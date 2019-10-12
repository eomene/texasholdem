using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface ISpriteSwaperAbility
{
    void SwapSprites(GameObject obj, bool ToFront);
}

public class SpriteSwaperAbility : MonoBehaviour, ISpriteSwaperAbility
{
    SpriteSwaperAbilityInternal spriteSwaperAbilityInternal;
    void Awake()
    {
        spriteSwaperAbilityInternal = new SpriteSwaperAbilityInternal();
    }
    public void SwapSprites(GameObject obj, bool ToFront)
    {
        spriteSwaperAbilityInternal.SwapSprites(obj, ToFront);
    }

}
public class SpriteSwaperAbilityInternal
{
    public void SwapSprites(GameObject obj, bool ToFront)
    {
        Image imageToSwap = obj.GetComponent<Image>();
        Sprite sprf = obj.GetComponent<IPokerSpriteFront>().GetFront;
        Sprite sprb = obj.GetComponent<IPokerSpriteBack>().GetBack;

        if (ToFront)
            imageToSwap.sprite = sprf;
        else
            imageToSwap.sprite = sprb;
    }
}
