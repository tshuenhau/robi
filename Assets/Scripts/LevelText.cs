using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelText : MonoBehaviour
{
    LevelController levelController;
    TextMeshProUGUI levelText;

    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        GetComponent<TextMeshProUGUI>().text = "Level " + levelController.GetCurrentLevel().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
