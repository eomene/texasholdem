using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MenuController : MonoBehaviour
{
    public GameObject MenuFader;
    public GameObject GameFader;
    // Start is called before the first frame update
    void Awake()
    {

        MenuFader.SetActive(true);
        MenuFader.transform.parent.gameObject.SetActive(true);
        MenuFader.GetComponent<Image>().DOFade(0, 1.5f).OnComplete(() =>
        {
            MenuFader.SetActive(false);
        });
    }
    public void Play()
    {
        GameFader.SetActive(true);
        MenuFader.SetActive(true);
        MenuFader.GetComponent<Image>().DOFade(1, DataHolders.delaySpeed).OnComplete(() =>
        {
            MenuFader.SetActive(false);
            MenuFader.transform.parent.gameObject.SetActive(false);
            GameFader.GetComponent<Image>().DOFade(0, DataHolders.delaySpeed).OnComplete(() =>
            {
                GameFader.SetActive(false);
                // StartCoroutine(CreatePlayers());
            });
        });

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
