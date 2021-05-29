using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuantityLeft : MonoBehaviour
{
    TextMeshProUGUI quantityLeftText;
    SwipeMenu swipeMenu;
    TabGroup tabGroup;

    // Start is called before the first frame update
    void Start()
    {
        swipeMenu = FindObjectOfType<SwipeMenu>();
        tabGroup = FindObjectOfType<TabGroup>();
        quantityLeftText = GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Save.current.itemsEquipped[1]);
        switch (tabGroup.selectedTab.getTabName())
        {
            case "Skins":
                quantityLeftText.text = null;
                break;

            case "Utility":
                quantityLeftText.text = Save.current.items[swipeMenu.GetCurrIndex()] + " left";

                break;

        }
    }
}
