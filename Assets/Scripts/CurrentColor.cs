using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CurrentColor : MonoBehaviour
{
    ColorController colorController;
    Image image;
    SpriteRenderer sprite;

    bool isImage;

    // Start is called before the first frame update
    void Start()
    {
        colorController = FindObjectOfType<ColorController>();
        image = GetComponent<Image>();
        sprite = GetComponent<SpriteRenderer>();
        if(image == null){isImage = false;}
        else{isImage = true;}
    }

    // Update is called once per frame
    void Update()
    {
        if(isImage){
            image.color = colorController.getCurrentColor();
        }
        else{
            sprite.color = colorController.getCurrentColor();
        }
    }

    public void ChangeColor(Color color, float tick){
        image.color = Color.Lerp(image.color, color, tick);
    }
}
