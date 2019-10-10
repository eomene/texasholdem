using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwaperAbility : MonoBehaviour
{
    public void SwapSprites(IPokerSpriteFront spf, IPokerSpriteBack spb, Image imageToSwap,bool isRealPlayer)
    {

        Sprite sprf = null;
        Sprite sprb = null;

        if (spf != null)
            sprf = spf.GetFront();
        if (spb != null)
            sprb = spb.GetBack();

        if (isRealPlayer)
            imageToSwap.sprite = sprf;
        else
            imageToSwap.sprite = sprb;

    }

}
