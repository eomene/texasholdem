using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public interface ICardFlipAbility
{
    void FlipCards(GameObject real);
}

public class CardFlipAbility : MonoBehaviour, ICardFlipAbility
{
    CardFlipAbilityInternal cardFlipAbilityInternal;
    public FloatReference moveSpeed;
    ISpriteSwaperAbility swapAbility;
    bool hasSwapAbility;
    private void Awake()
    {
        cardFlipAbilityInternal = new CardFlipAbilityInternal();
    }
    private void Start()
    {
        swapAbility = GetComponent<ISpriteSwaperAbility>();
        if (swapAbility != null)
            hasSwapAbility = true;
    }
    public void FlipCards(GameObject real)
    {
        cardFlipAbilityInternal.FlipCards(real,hasSwapAbility,swapAbility,moveSpeed.Value);
    }
}
public class CardFlipAbilityInternal
{
    public void FlipCards(GameObject real, bool hasSwapAbility,ISpriteSwaperAbility swapAbility,float moveSpeed)
    {
        real.transform.DOScaleX(0, moveSpeed).OnComplete(() =>
        {
            if (hasSwapAbility)
                swapAbility.SwapSprites(real, true);

            real.transform.DOScaleX(1, moveSpeed).OnComplete(() =>
            {

            });
        });
    }
}

