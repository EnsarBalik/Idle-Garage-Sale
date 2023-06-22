using System;
using System.Collections;
using System.Collections.Generic;
using Game.User;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class BuySalesArea : MonoBehaviour
{
    public SalesAreaController saleArea;
    public TextMeshPro SellAreaText;
    public SpriteRenderer SellAreaImage;
    public bool isSold;
    public int cost;
    public string id;

    private void Start()
    {
        if (id == "SellArea1")
        {
            if (PlayerPrefs.GetFloat(id) == 0)
            {
                PlayerPrefs.SetFloat(id, 1f);
            }
        }
    }

    private void LateUpdate()
    {
        if (PlayerPrefs.GetFloat(id) == 1f)
            isSold = true;
        else
            isSold = false;

        if (isSold)
        {
            SellAreaImage.color = Color.white;
            SellAreaText.color = Color.white;
        }
    }

    private void Sale(int Cost)
    {
        if (isSold) return;
        Cost = cost;
        if (PlayerPrefs.GetInt("myCoin") >= Cost)
        {
            SellAreaImage.color = Color.white;
            SellAreaText.color = Color.white;
            GameManager.instance.SpendMoney(cost);
            isSold = true;
            PlayerPrefs.SetFloat(id, 1f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (isSold) return;
            Sale(cost);
        }
    }
}