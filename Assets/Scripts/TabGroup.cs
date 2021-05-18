using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;
    [SerializeField] public TabButton initialTab;

    [SerializeField] public Sprite tabIdle;
    [SerializeField] public Sprite tabHover;
    [SerializeField] public Sprite tabActive;
    public TabButton selectedTab;
    [SerializeField] public List<GameObject> objectsToSwap;

    void Start()
    {
        // ResetTabs();
        OnTabEnter(initialTab);

        //objectsToSwap[0].SetActive(true);
        //Debug.Log(selectedTab.gameObject.name);
    }
    public void Subscribe(TabButton button)
    {
        if (tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabEnter(TabButton button)
    {
        ResetTabs();
        if (selectedTab != null || button != selectedTab)
        {
            button.background.sprite = tabHover;

        }
    }

    public void OnTabExit(TabButton button)
    {
        ResetTabs();

    }
    public void OnTabSelected(TabButton button)
    {
        selectedTab = button;
        ResetTabs();
        button.background.sprite = tabActive;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++)
        {
            if (i == index)
            {
                objectsToSwap[i].SetActive(true);
            }
            else
            {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void ResetTabs()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab) { continue; }
            button.background.sprite = tabIdle;
        }
    }

}
