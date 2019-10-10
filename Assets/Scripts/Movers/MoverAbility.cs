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
                    var ObjectToMove = objectsToMove[i].GetPokerObject();
                    ObjectToMove.transform.localPosition = new Vector2(startLocations[i].location.x, startLocations[i].location.y);
                    ObjectToMove.transform.DOLocalMove(endLocations[i].location, moveSpeed.Value).OnComplete(() =>
                    {
                        endObject.isFilled = parent.fillUp();
                        if (hasSwapAbility && !parent.dontSwap() && parent.dontFlip())
                            swapAbility.SwapSprites(ObjectToMove, parent.isRealPlayer());
                        if (hasCardFlipAbility && parent.isRealPlayer() && !parent.dontFlip())
                            cardFlipAbility.FlipCards(ObjectToMove);
                        parent.action();

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
