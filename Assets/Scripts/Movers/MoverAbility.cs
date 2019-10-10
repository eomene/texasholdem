
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class MoverAbility : MonoBehaviour
{
    public FloatReference moveSpeed;
    public void Move(List<IPokerObject> objectsToMove, List<Locations> startLocations, List<Locations> endLocations,IPokerOwner parent)
    {
        for (int i = 0; i < objectsToMove.Count; i++)
        {
            if (objectsToMove.Count <= endLocations.Count && objectsToMove.Count <= startLocations.Count)
            {
                if (!endLocations[i].isFilled)
                {
                    Sprite sprf = null;
                    Sprite sprb = null;

                    IPokerSpriteFront spf = objectsToMove[i] as IPokerSpriteFront;
                    if (spf != null)
                        sprf = spf.GetFront();
                    IPokerSpriteBack spb = objectsToMove[i] as IPokerSpriteBack;
                    if (spb != null)
                        sprb = spb.GetBack();

                    Transform parentTransform = parent as Transform;
                    GameObject dummyObject = Instantiate(objectsToMove[i].GetPokerObject(), parentTransform);
                    var endObject = endLocations[i];

                    dummyObject.transform.localPosition = new Vector2(startLocations[i].location.x, startLocations[i].location.y);
                    dummyObject.transform.DOLocalMove(endLocations[i].location, moveSpeed.Value).OnComplete(() =>
                    {
                        dummyObject.transform.localScale = Vector3.zero;
                        if(parent.isRealPlayer())
                        endObject.locationHolder.GetComponent<Image>().sprite = sprf;
                        else
                            endObject.locationHolder.GetComponent<Image>().sprite = sprb;
                        endObject.locationHolder.gameObject.SetActive(true);
                        endObject.isFilled = true;
                        endObject.locationHolder.localScale = Vector3.one;
                         Destroy(dummyObject);
                    }).SetEase(Ease.Linear);//set ease type for movement
                }
            }
        }
    }
}
