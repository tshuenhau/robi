using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopPrices : MonoBehaviour
{
    TextMeshProUGUI priceText;
    [SerializeField] SwipeMenu swipeMenu;
    [SerializeField] int[] prices;
    // Start is called before the first frame update
    void Start()
    {
        //swipeMenu = FindObjectOfType<SwipeMenu>();
        priceText= GetComponent<TextMeshProUGUI>();  
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(swipeMenu.GetCurrIndex());
        priceText.text ="<sprite=0>" + prices[swipeMenu.GetCurrIndex()].ToString() ;
       
    }

    public int[] GetPrices(){
        return prices;
    }
}
