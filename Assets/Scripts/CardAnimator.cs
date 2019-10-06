using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAnimator : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //public void PlayAnimation(string animation, GameObject dummyCard, GameObject mainCard)
    //{
    //    //anim.SetTrigger(animation);
    //    //if(dummyCard!=null && mainCard!=null)
    //    //UnflipNow(dummyCard, mainCard);
    //}

    //void UnflipNow(GameObject dummyCard, GameObject mainCard)
    //{
    //    Debug.Log("unfliping");
    //    StartCoroutine(Unflip(dummyCard, mainCard));
    //}
    //IEnumerator Unflip(GameObject dummyCard, GameObject mainCard)
    //{
    //    yield return new WaitForSeconds(0.35f);
    //    mainCard.SetActive(true);
    //    dummyCard.SetActive(false);
    //    mainCard.GetComponent<CardAnimator>().PlayAnimation("unflip",null,null);
    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
