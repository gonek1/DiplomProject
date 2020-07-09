using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    public Button[] buy_buttons;
    [SerializeField] GameObject warningPanel;
    [SerializeField] int current_money;
    [SerializeField] int max_money;
    [SerializeField] int current_energy;
    [SerializeField] int max_energy;
    [SerializeField] Text currentMoneyText;
    [SerializeField] Text currentEnergyText;
    public event EventHandler BuyingEnergy;
    public void ShowPanel()
    {
        warningPanel.SetActive(true);
    }
    public void MinusEnergy()
    {
        if (current_energy-1<0)
        {
            ShowPanel();
            return;
        }
        current_energy--;
        BuyingEnergy?.Invoke(this,EventArgs.Empty);
    }
    public bool CanPlayGame()
    {
        bool canPlay = current_energy > 0;
        if (!canPlay)
        {
            warningPanel.SetActive(true);
        }
        return canPlay;
    }
    public void MinusMoney(int count,int energyCount)
    {
        if (current_money - count < 0)
        {
            ShowPanel();
            return;
        }
        current_money -= count;
        GetEnegry(energyCount);
        BuyingEnergy?.Invoke(this, EventArgs.Empty);
    }
    public void GetEnegry(int count)
    {
        current_energy += count;
        BuyingEnergy?.Invoke(this, EventArgs.Empty);
    }
    private void Start()
    {
        buy_buttons[0].onClick.AddListener(() => MinusMoney(50, 1));
        buy_buttons[1].onClick.AddListener(() => MinusMoney(100, 2));
        buy_buttons[2].onClick.AddListener(() => MinusMoney(200, 4));
        buy_buttons[3].onClick.AddListener(() => MinusMoney(300, 6));
        buy_buttons[4].onClick.AddListener(() => MinusMoney(400, 8));
        buy_buttons[5].onClick.AddListener(() => MinusMoney(500, 10));
        BuyingEnergy += UpdateUI;
        SetValue();
    }
    
    private void SetValue()
    {
        current_money = PlayerPrefs.GetInt("money1",500);
        current_energy = PlayerPrefs.GetInt("energy1",20);
        currentMoneyText.text = current_money.ToString();
        currentEnergyText.text = current_energy.ToString();
    }

    void UpdateUI(object @object, EventArgs args)
    {
        currentMoneyText.text = current_money.ToString();
        currentEnergyText.text = current_energy.ToString();
        PlayerPrefs.SetInt("money1",current_money);
        PlayerPrefs.SetInt("energy1",current_energy);
    }
}
