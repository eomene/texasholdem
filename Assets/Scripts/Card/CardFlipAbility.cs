using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardFlipAbility : MonoBehaviour
{
    public FloatReference moveSpeed;
    public void FlipCards(GameObject dummyObject, GameObject real,IPokerOwner owner)
    {
        dummyObject.transform.DOScaleX(0, moveSpeed.Value).OnComplete(() =>
        {
            real.transform.DOScaleX(1, moveSpeed.Value).OnComplete(() =>
            {

            });
        });
    }

}
