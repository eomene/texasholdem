
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

                    //Transform parentTransform = parent as Transform;
                   // Debug.Log(parentTransform.name);
                    GameObject dummyObject = Instantiate(objectsToMove[i].GetPokerObject(), parent.PokerObject());
                    var endObject = endLocations[i];

                    dummyObject.transform.localPosition = new Vector2(startLocations[i].location.x, startLocations[i].location.y);

                    CardFlipAbility cfa = GetComponent<CardFlipAbility>();

                    if (cfa != null)
                        endLocations[i].locationHolder.localScale = new Vector3(0, endLocations[i].locationHolder.localScale.y, endLocations[i].locationHolder.localScale.z);

                    dummyObject.transform.DOLocalMove(endLocations[i].location, moveSpeed.Value).OnComplete(() =>
                    {

                        if (parent.isRealPlayer())
                            endObject.locationHolder.GetComponent<Image>().sprite = sprf;
                        else
                            endObject.locationHolder.GetComponent<Image>().sprite = sprb;

                        endObject.locationHolder.gameObject.SetActive(true);
                        endObject.isFilled = true;
                        if (cfa != null && parent.isRealPlayer())
                            cfa.FlipCards(dummyObject, endObject.locationHolder.gameObject, parent);
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
}
