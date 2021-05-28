using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItemName : MonoBehaviour
{

    TextMeshProUGUI itemNameText;
    [SerializeField] SwipeMenu swipeMenu;

    [SerializeField] string[] itemNames;


    // Start is called before the first frame update    TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        itemNameText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        itemNameText.text = itemNames[swipeMenu.GetCurrIndex()].ToString();

    }
}
