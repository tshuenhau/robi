using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItemDescription : MonoBehaviour
{
    TextMeshProUGUI descriptionText;

    // Start is called before the first frame update    TextMeshProUGUI itemNameText;
    [SerializeField] SwipeMenu swipeMenu;

    [SerializeField] string[] itemDescriptions;


    // Start is called before the first frame update    TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        descriptionText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        descriptionText.text = itemDescriptions[swipeMenu.GetCurrIndex()].ToString();

    }
}
