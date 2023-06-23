using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyNewIsland : MonoBehaviour
{
    public Image fillImage;
    public GameObject island;
    public GameObject triggers;
    public int cost;

    private bool isCoolDown = true;
    private float coolDownSec = 1f;
    private void Start()
    {
        fillImage.fillAmount = 0;
        if (UserData.instance.isSold)
        {
            island.SetActive(true);
            triggers.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void Sale(int Cost)
    {
        if (UserData.instance.isSold) return;
        if (PlayerPrefs.GetInt("myCoin") >= Cost)
        {
            GameManager.instance.SpendMoney(Cost);
            UserData.instance.isSold = true;
            PlayerPrefs.SetFloat(UserData.instance.id, 1f);
            fillImage.gameObject.SetActive(false);
            island.SetActive(true);
            triggers.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag($"Player"))
        {
            fillImage.gameObject.SetActive(true);
            if (!isCoolDown)
            {
                Sale(cost);
                isCoolDown = true;
            }

            if (isCoolDown)
            {
                fillImage.fillAmount += 1 / coolDownSec * Time.deltaTime;
                if (fillImage.fillAmount >= 1)
                {
                    fillImage.fillAmount = 0;
                    isCoolDown = false;
                }
            }
        }
    }
}