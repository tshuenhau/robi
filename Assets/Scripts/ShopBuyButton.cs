using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyButton : MonoBehaviour
{
    Button button;
    SwipeMenu swipeMenu;
    TabGroup tabGroup;

    // Start is called before the first frame update
    void Start()
    {
        swipeMenu = FindObjectOfType<SwipeMenu>();
        button = GetComponent<Button>();
        tabGroup = FindObjectOfType<TabGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (tabGroup.selectedTab.getTabName())
        {
            case "Skins":
                if (Save.current.unlockedSkins.Contains(swipeMenu.GetCurrIndex()) != false)
                {
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                }
                break;
                
            case "Utility":
            break;

        }

        // if (tabGroup.selectedTab.getTabName() == "Skins")
        // {
        //     if (Save.current.unlockedSkins.Contains(swipeMenu.GetCurrIndex()) != false)
        //     {
        //         button.interactable = false;
        //     }
        //     else
        //     {
        //         button.interactable = true;
        //     }
        // }



    }
}