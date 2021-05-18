using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FluxText : MonoBehaviour
{
    TextMeshProUGUI scoreText;
    LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        scoreText= GetComponent<TextMeshProUGUI>();  
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = levelController.GetFlux().ToString();
       
    }
}
