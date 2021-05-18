using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnlockPlayer : MonoBehaviour
{
    ColorController colorController;
    Image mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        mySpriteRenderer = GetComponent<Image>();
        colorController = FindObjectOfType<ColorController>();
    }

    // Update is called once per frame
    void Update()
    {
        mySpriteRenderer.color = colorController.getCurrentColor();

    }
}
