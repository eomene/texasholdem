using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public interface IMoverAbility
{
    void Move(List<IPokerObject> objectsToMove, List<Locations> startLocations, List<Locations> endLocations, IPokerOwner parent);
}

public class MoverAbility : MonoBehaviour, IMoverAbility
{
    MoverAbilityInternal moverAbilityInternal;
    //public FloatReference moveSpeed;
    ISpriteSwaperAbility swapAbility;
    ICardFlipAbility cardFlipAbility;
    bool hasCardFlipAbility;
    bool hasSwapAbility;
    private void Awake()
    {
        moverAbilityInternal = new MoverAbilityInternal();
    }
    public void OnEnable()
    {
        swapAbility = GetComponent<ISpriteSwaperAbility>();
        if (swapAbility != null)
            hasSwapAbility = true;
        cardFlipAbility = GetComponent<ICardFlipAbility>();
        if (cardFlipAbility != null)
            hasCardFlipAbility = true;
    }
    public void Move(List<IPokerObject> objectsToMove, List<Locations> startLocations, List<Locations> endLocations, IPokerOwner parent)
    {
        moverAbilityInternal.Move(objectsToMove, startLocations, endLocations, parent, hasSwapAbility, hasCardFlipAbility, swapAbility, cardFlipAbility);
    }

}

public class MoverAbilityInternal
{
    public void Move(List<IPokerObject> objectsToMove, List<Locations> startLocations, List<Locations> endLocations, IPokerOwner parent,bool hasSwapAbility,bool hasCardFlipAbility,ISpriteSwaperAbility swapAbility,ICardFlipAbility cardFlipAbility)
    {
        if (objectsToMove.Count <= endLocations.Count && objectsToMove.Count <= startLocations.Count)
        {

            for (int i = 0; i < objectsToMove.Count; i++)
            {
                if (!endLocations[i].isFilled)
                {
                    var endObject = endLocations[i];
                    var ObjectToMove = objectsToMove[i].GetPokerObject;
                    ObjectToMove.transform.localPosition = new Vector2(startLocations[i].location.x, startLocations[i].location.y);
                    ObjectToMove.transform.DOLocalMove(endLocations[i].location, parent.speed).OnComplete(() =>
                    {
                        endObject.isFilled = parent.fillUp;
                        if (hasSwapAbility && !parent.dontSwap && parent.dontFlip)
                            swapAbility.SwapSprites(ObjectToMove, parent.isRealPlayer);
                        if (hasCardFlipAbility && parent.isRealPlayer && !parent.dontFlip)
                        {
                            cardFlipAbility.FlipCards(ObjectToMove);
                        }
                        //parent.action();

                    }).SetEase(Ease.Linear);//set ease type for movement
                }
            }
        }
    }
}
