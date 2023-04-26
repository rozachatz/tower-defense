using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myhealthUI : MonoBehaviour
{
    public Text livesText;
    public Text moneyText;
    
    int health; int money;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        
        livesText.text = Health.lives.ToString();
        moneyText.text= Health.money.ToString();
    }
}
