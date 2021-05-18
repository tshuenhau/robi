using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColorController : MonoBehaviour
{
    ColorController colorController;
    // Start is called before the first frame update
    void Start()
    {
        colorController = FindObjectOfType<ColorController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Slider>().value = colorController.GetComponent<Slider>().value;
    }
}
