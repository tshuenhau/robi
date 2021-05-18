using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShopEquipped : MonoBehaviour
{

    SwipeMenu swipeMenu;
    TabGroup tabGroup;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        swipeMenu = FindObjectOfType<SwipeMenu>();
        tabGroup = FindObjectOfType<TabGroup>();
        image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (tabGroup.selectedTab.getTabName())
        {
            case "Skins":
                //Debug.Log(gameObject.transform.parent.transform.parent.name);
                if (Save.current.currentSkin == gameObject.transform.parent.transform.GetSiblingIndex())
                {
                    image.enabled = true;
                }
                else
                {
                    image.enabled = false;
                }
                break;

            case "Utility":
                if (Save.current.itemsEquipped[gameObject.transform.parent.transform.GetSiblingIndex()] == 1)
                {
                    image.enabled = true;

                }
                else
                {
                    image.enabled = false;

                }
                break;

        }
    }
}
