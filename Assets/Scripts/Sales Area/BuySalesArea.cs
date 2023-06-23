using System;
using System.Collections;
using System.Collections.Generic;
using Game.User;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuySalesArea : MonoBehaviour
{
    public TextMeshPro SellAreaText;
    public SpriteRenderer SellAreaImage;
    public int cost;

    private void Start()
    {
        PlayerPrefs.SetFloat(UserData.instance.id, 1f);
        
        if (UserData.instance.isSold)
        {
            SellAreaImage.color = Color.white;
            SellAreaText.color = Color.white;
        }
    }

    private void LateUpdate()
    {
        
    }

    private void Sale(int Cost)
    {
        if (UserData.instance.isSold) return;
        Cost = cost;
        if (PlayerPrefs.GetInt("myCoin") >= Cost)
        {
            SellAreaImage.color = Color.white;
            SellAreaText.color = Color.white;
            GameManager.instance.SpendMoney(cost);
            UserData.instance.isSold = true;
            PlayerPrefs.SetFloat(UserData.instance.id, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (UserData.instance.isSold) return;
            Sale(cost);
        }
    }
}