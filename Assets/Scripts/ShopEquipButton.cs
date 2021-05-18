using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopEquipButton : MonoBehaviour
{
    Button button;
    SwipeMenu swipeMenu;
    TabGroup tabGroup;
    TextMeshProUGUI buttonText;


    // Start is called before the first frame update
    void Start()
    {
        swipeMenu = FindObjectOfType<SwipeMenu>();

        button = GetComponent<Button>();
        tabGroup = FindObjectOfType<TabGroup>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (tabGroup.selectedTab.getTabName())
        {
            case "Skins":
                if (Save.current.unlockedSkins.Contains(swipeMenu.GetCurrIndex()) == false || Save.current.currentSkin == swipeMenu.GetCurrIndex())
                {
                    button.interactable = false;
                }
                else
                {
                    button.interactable = true;
                }
                break;

            case "Utility":
                if (Save.current.items[0] < 1) // 1 == true
                {
                    button.interactable = false;

                }
                else if (Save.current.itemsEquipped[swipeMenu.GetCurrIndex()] == 1){
                    button.interactable = true;

                    buttonText.text = "Unequip";
                }
                else //if (Save.current.livesEquipped == -1) //-1 == false
                {                    
                    button.interactable = true;
                    buttonText.text = "Equip";

                }
        
                break;

        }


    }
}
