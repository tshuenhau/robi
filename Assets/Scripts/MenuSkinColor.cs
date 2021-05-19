using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MenuSkinColor : MonoBehaviour
{
    int currentLevel;
    List<Color> colorList = new List<Color>();
    [SerializeField] float timerCount = 3f;
    [SerializeField] GameObject eyes;
    int colorListIndex = 0;
    Color currentColor;
    Color nextColor;
    Image image;

    float colorChangeTimer;

    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {
        currentLevel = Save.current.level;
        SetColor();
        image = GetComponent<Image>();
        colorChangeTimer = timerCount;
        image.color = colorList[colorListIndex];
        if (colorListIndex + 1 < colorList.Count - 1)
        {
            colorListIndex++;
        }
        else
        {
            colorListIndex = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        colorChangeTimer -= Time.deltaTime;
        if (colorChangeTimer <= 0)
        {
            if (colorListIndex < colorList.Count)
            {
                image.color = nextColor;
                nextColor = colorList[colorListIndex];
                if (colorListIndex == colorList.Count - 1)
                {
                    colorListIndex = 0;
                }
                else
                {
                    colorListIndex++;
                }
            }
            colorChangeTimer = timerCount;
        }

        foreach (Transform eye in eyes.transform)
        {
            eye.GetComponent<Image>().color = image.color;
        }
    }
    //TODO colorIndex might need to be adjusted like in ColorController
    public void SetColor()
    {
        colorList.Clear();
        if (currentLevel >= 0)
        { // level 0
            colorList.Add(new Color(0.6078432f, 0.9647059f, 1f)); //Blue
            currentColor = colorList[colorListIndex];
            nextColor = colorList[colorListIndex];
            if (currentLevel >= 4)
            { // level 3
                colorList.Add(new Color(0.7921569f, 1, 0.7490196f)); //Green
                if (currentLevel >= 15)
                { // level 12
                    colorList.Add(new Color(1, 0.6784314f, 0.6784314f));//Red
                    if (currentLevel >= 24)
                    { // level 24
                        colorList.Add(new Color(0.9921569f, 1, 0.7137255f)); //yellow
                        if (currentLevel >= 36)
                        { // level 36
                            colorList.Add(new Color(1, 0.7764706f, 1));
                        }
                    }
                }
                currentColor = colorList[colorListIndex];
                nextColor = colorList[colorListIndex + 1];
            }
        }
    }
}
