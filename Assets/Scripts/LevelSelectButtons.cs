using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelSelectButtons : MonoBehaviour
{
    Button button;
    int level;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        level = int.Parse(GetComponentInChildren<TextMeshProUGUI>().text);
        if(level > Save.current.level){
            button.interactable = false;
        }
        else{
            button.interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // if(){
        //     button.interactable = false;
        // }
        // else{
        //     button.interactable = true;
        // }

        
    }
}