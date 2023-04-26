using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradSell_Script : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public Text upgr_cost;
    public Text sell_cost;
    public Text title;
    public Text description;
    public void SetTarget(Node target_)
    {
        
        this.target = target_;
        transform.position = target.GetBuildPos();
        upgr_cost.text = target.tower1.upgraded_price + "$";
        sell_cost.text = target.sellmoney.ToString()+"$"; //sell price is half the price or if upgraded, half the upgraded price
        ui.SetActive(true);//enable
    }
    public void hide()
    {
        ui.SetActive(false);//disable
    }
    public void Upgrade()
    {
       
        target.UpgradeTower();
        hide();
        BuildManager.instance.Hidemenu();

    }
    public void Sell()
    {

        target.SellTower();
        hide();
        BuildManager.instance.Hidemenu();

    }
}
