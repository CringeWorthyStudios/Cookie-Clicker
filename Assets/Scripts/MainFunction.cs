using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainFunction : MonoBehaviour
{
    public Text instruction;
    public int money = 0;
    public int moneyPerClick = 1;
    public int moneyPerSecond = 0;

    public int baseCost = 100;

    private int amountOfMice = 0;
    private int amountOfGamer = 0;
    private int amountOfServer = 0;
    private int amountOfStreamer = 0;
    private int amountOfBethesda = 0;
    private int amountOfToddHoward = 0;

    private int moneyPerSecondOfMice = 1;
    private int moneyPerSecondOfGamer = 1;
    private int moneyPerSecondOfServer = 3;
    private int moneyPerSecondOfStreamer = 2;
    private int moneyPerSecondOfBethesda = 5;
    private int moneyPerSecondOfToddHoward = 7;

    public void OnClickCookie()
    {
        money += moneyPerClick;
    }
    IEnumerator MoneyPerSecondTimer()
    {
        while (true)
        {
            money += moneyPerSecond;
            yield return new WaitForSeconds(1f);
        }
    }

    private void SetMoneyPerClick()
    {
        moneyPerClick = 1 + amountOfMice * moneyPerSecondOfMice;
    }

    private void SetMoneyPerSecond()
    {
        moneyPerSecond = (moneyPerSecondOfBethesda * amountOfBethesda + moneyPerSecondOfToddHoward * amountOfToddHoward + moneyPerSecondOfServer * amountOfServer
            + moneyPerSecondOfStreamer * amountOfStreamer + moneyPerSecondOfGamer * amountOfGamer);
    }

    public void BuyMice()
    {
        int cost = (int)(baseCost * ((amountOfMice + 1) / 5f) * 1.25);
        if(cost <= 0)
        {
            cost = 1;
        }
        if (money >= cost)
        {
            amountOfMice += 1;
            Debug.Log(cost);
            money -= cost;
        }
        SetMoneyPerClick();
    }

    public void BuyGamer()
    {
        int cost = (int)(baseCost * ((amountOfGamer + 1) / 2f) * 1.5);
        if (cost <= 0)
        {
            cost = 1;
        }
        if (money >= cost)
        {
            amountOfGamer += 1;
            Debug.Log(cost);
            money -= cost;
        }
        SetMoneyPerSecond();
    }
    public void BuyStreamer()
    {
        int cost = (int)(baseCost * ((amountOfStreamer + 1) / 2f) * 2);
        if (cost <= 0)
        {
            cost = 1;
        }
        if (money >= cost)
        {
            amountOfStreamer += 1;
            Debug.Log(cost);
            money -= cost;
        }
        SetMoneyPerSecond();
    }
    public void BuyServer()
    {
        int cost = (int)(baseCost * ((amountOfServer + 1) / 2f) * 2.75);
        if (cost <= 0)
        {
            cost = 1;
        }
        if (money >= cost)
        {
            amountOfServer += 1;
            Debug.Log(cost);
            money -= cost;
        }
        SetMoneyPerSecond();
    }
    public void BuyBethesda()
    {
        int cost = (int)(baseCost * ((amountOfBethesda + 1) / 2f) * 4);
        if (cost <= 0)
        {
            cost = 1;
        }
        if (money >= cost)
        {
            amountOfBethesda += 1;
            Debug.Log(cost);
            money -= cost;
        }
        SetMoneyPerSecond();
    }
    public void BuyToddHoward()
    {
        int cost = (int)(baseCost * ((amountOfToddHoward + 1) / 2f) * 10);
        if (cost <= 0)
        {
            cost = 1;
        }
        if (money >= cost)
        {
            amountOfToddHoward += 1;
            Debug.Log(cost);
            money -= cost;
        }
        SetMoneyPerSecond();
    }

    private void Start()
    {
        StartCoroutine(MoneyPerSecondTimer());
        instruction = instruction.GetComponent<Text>();
    }

    string moneyStr = "";
    private void Update()
    {
        moneyStr = money.ToString();
        instruction.text = moneyStr;
    }

}
