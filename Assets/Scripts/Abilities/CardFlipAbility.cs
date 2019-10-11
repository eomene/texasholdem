using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardFlipAbility : MonoBehaviour
{
    public FloatReference moveSpeed;
    SpriteSwaperAbility swapAbility;
    bool hasSwapAbility;
    private void Start()
    {
        swapAbility = GetComponent<SpriteSwaperAbility>();
        if (swapAbility != null)
            hasSwapAbility = true;
    }
    public void FlipCards(GameObject real)
    {
        real.transform.DOScaleX(0, moveSpeed.Value).OnComplete(() =>
        {
            if(hasSwapAbility)
            swapAbility.SwapSprites(real, true);

            real.transform.DOScaleX(1, moveSpeed.Value).OnComplete(() =>
            {

            });
        });
    }

}
