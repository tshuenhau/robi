using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeMenu : MonoBehaviour
{
    public GameObject scrollbar;
    private float scroll_pos = 0;
    float[] pos;
    int currIndex = 0;
    ShopPrices shopPrices;

    // Start is called before the first frame update
    void Start()
    {
        shopPrices = FindObjectOfType<ShopPrices>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("total livews: " + Save.current.items[0]);
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }


        for (int i = 0; i < pos.Length; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                //Debug.Log( "i is" + i);
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1.2f, 1.2f), 0.1f);
                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                    }
                }
                currIndex = i;


            }
        }

        //Debug.Log(currIndex);
        //Debug.Log("Current Index: " + currIndex);

    }
    public int GetCurrIndex()
    {
        return currIndex;
    }
    public void SetSkin()
    {
        Save.current.currentSkin = currIndex;
        SaveLoad.SaveGame();
        Debug.Log(Save.current.currentSkin);
        Debug.Log("Current Index " + currIndex);

    }

    public void BuySkin()
    {
        if (shopPrices.GetPrices()[currIndex] <= Save.current.flux)
        {
            Save.current.unlockedSkins.Add(currIndex);
            Save.current.flux -= shopPrices.GetPrices()[currIndex];
        }
        SaveLoad.SaveGame();
    }

    public void buyUtility()
    {
        if (shopPrices.GetPrices()[currIndex] <= Save.current.flux)
        {
            Save.current.flux -= shopPrices.GetPrices()[currIndex];
            Save.current.items[currIndex] += 1;
            SaveLoad.SaveGame();

            // switch(currIndex) {
            //     case 0:
            //         addLives();
            //         break;
            // }

        }
    }

    public void addLives()
    {
        Save.current.items[0] += 1;
        SaveLoad.SaveGame();

    }

    public void equipLives()
    {
        Save.current.itemsEquipped[0] *= -1;
        SaveLoad.SaveGame();
        //Debug.Log(Save.current.livesEquipped);

    }

    public void equipItem()
    {
        Save.current.itemsEquipped[currIndex] *= -1;
        if (Save.current.itemsEquipped[currIndex] == 0)
        {
            Save.current.itemsEquipped[currIndex] = -1;
        }
        SaveLoad.SaveGame();
        //Debug.Log(Save.current.livesEquipped);

    }

    public void addFlux()
    {
        Save.current.flux += 10000;
        SaveLoad.SaveGame();

    }

}

