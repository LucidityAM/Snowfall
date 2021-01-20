using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditPlayer : MonoBehaviour
{
    public Sprite[] creditSprites;

    private int currentPage;

    public GameObject rightButton;
    public GameObject leftButton;

    // Start is called before the first frame update
    void Start()
    {
        currentPage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().sprite = creditSprites[currentPage];

        if(currentPage == 0)
        {
            leftButton.SetActive(false);
        }
        else
        {
            leftButton.SetActive(true);
        }

        if(currentPage == creditSprites.Length -1)
        {
            rightButton.SetActive(false);
        }
        else
        {
            rightButton.SetActive(true);
        }

    }

    public void NextCredits()
    {
        if(currentPage < creditSprites.Length - 1)
        {
            currentPage++;
        }
    }

    public void LastCredits()
    {
        if (currentPage > 0)
        {
            currentPage--; 
        }
    }
}
 