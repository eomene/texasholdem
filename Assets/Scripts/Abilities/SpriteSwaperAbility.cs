using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwaperAbility : MonoBehaviour
{
    public void SwapSprites(GameObject obj, bool ToFront)
    {
       // Debug.Log("swapiin");
        Image imageToSwap = obj.GetComponent<Image>();
        Sprite sprf = obj.GetComponent<IPokerSpriteFront>().GetFront();
        Sprite sprb = obj.GetComponent<IPokerSpriteBack>().GetBack();

        if (ToFront)
            imageToSwap.sprite = sprf;
        else
            imageToSwap.sprite = sprb;
    }

}
