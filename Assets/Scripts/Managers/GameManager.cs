using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int coin;
    [SerializeField] private TextMeshProUGUI coinText;
    
    private void LateUpdate()
    {
        coin = PlayerPrefs.GetInt("myCoin", coin);
        coinText.text = "" + coin;
    }
    
    public void CollectCoin(int coinCollect)
    {
        coin += coinCollect;
        StartCoroutine(_coinText());
        PlayerPrefs.SetInt("myCoin", coin);
    }
    
    private IEnumerator _coinText()
    {
        float totalTime = 2f;
        float elapsedTime = 0;
        int coinAmount = PlayerPrefs.GetInt("myCoin");
        float step = (coin - coinAmount) / totalTime;
        
        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            int amount = Mathf.Clamp(coinAmount + Mathf.RoundToInt(step * elapsedTime), 0, coin);
            coinText.text = amount.ToString();
            yield return null;
        }
    }
}
