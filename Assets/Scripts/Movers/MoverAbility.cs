using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class MoverAbility : MonoBehaviour
{
    public FloatReference moveSpeed;
    SpriteSwaperAbility swapAbility;
    CardFlipAbility cardFlipAbility;
    bool hasCardFlipAbility;
    bool hasSwapAbility;
    public void OnEnable()
    {
        swapAbility = GetComponent<SpriteSwaperAbility>();
        if (swapAbility != null)
            hasSwapAbility = true;
        cardFlipAbility = GetComponent<CardFlipAbility>();
        if (cardFlipAbility != null)
            hasCardFlipAbility = true;
    }
    public void Move(List<IPokerObject> objectsToMove, List<Locations> startLocations, List<Locations> endLocations,IPokerOwner parent)
    {
        for (int i = 0; i < objectsToMove.Count; i++)
        {
            if (objectsToMove.Count <= endLocations.Count && objectsToMove.Count <= startLocations.Count)
            {
                if (!endLocations[i].isFilled)
                {
                    var endObject = endLocations[i];
                    if (hasSwapAbility && !parent.dontSwap())
                        swapAbility.SwapSprites(objectsToMove[i] as IPokerSpriteFront, objectsToMove[i] as IPokerSpriteBack, endObject.locationHolder.GetComponent<Image>(), parent.isRealPlayer());

                    if (hasCardFlipAbility && !parent.dontFlip())
                        endLocations[i].locationHolder.localScale = new Vector3(0, endLocations[i].locationHolder.localScale.y, endLocations[i].locationHolder.localScale.z);

                    GameObject dummyObject = Instantiate(objectsToMove[i].GetPokerObject(), parent.PokerObject());
                    dummyObject.transform.localPosition = new Vector2(startLocations[i].location.x, startLocations[i].location.y);

                    dummyObject.transform.DOLocalMove(endLocations[i].location, moveSpeed.Value).OnComplete(() =>
                    {
                        finished();
                        endObject.locationHolder.gameObject.SetActive(parent.fillUp());
                        endObject.isFilled = parent.fillUp();
                        if (hasCardFlipAbility && parent.isRealPlayer() && !parent.dontFlip())
                            cardFlipAbility.FlipCards(dummyObject, endObject.locationHolder.gameObject, parent);
                        else
                        {
                            dummyObject.transform.localScale = Vector3.zero;
                            endObject.locationHolder.localScale = Vector3.one;
                            Destroy(dummyObject);
                        }

                    }).SetEase(Ease.Linear);//set ease type for movement
                }
            }
        }
    }

    public void finished()
    {
        Debug.Log("I know you wont call me");
    }
}
