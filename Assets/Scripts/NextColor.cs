using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NextColor : MonoBehaviour
{
    ColorController colorController;
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        colorController = FindObjectOfType<ColorController>();
        image = GetComponent<Image>();    
        }

    // Update is called once per frame
    void Update()
    {
        image.color = colorController.getNextColor();
    }
    public void ChangeColor(Color color, float tick){
        image.color = Color.Lerp(image.color, color, tick);
    }
}
