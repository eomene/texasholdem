using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideUp : MonoBehaviour
{
    Controls control;
    // Start is called before the first frame update
    void Awake()
    {
        control = GetComponentInParent<Controls>();
    }

    // Update is called once per frame
    void OnEnable()
    {
        control.ShowCards(true);
    }
    void OnDisable()
    {
        //control.HideCards();
    }
}
