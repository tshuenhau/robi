using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColorController : MonoBehaviour
{

    [SerializeField] float timerCount = 5f;

    float colorChangeTimer;
    //Color[] colorList = {new Color(0.6078432f,0.9647059f,1f), new Color(1,0.6784314f,0.6784314f) , new Color(0.9921569f, 1, 0.7137255f), new Color(0.7921569f,1,0.7490196f), new Color(1,0.7764706f,1)};
    List<Color> colorList = new List<Color>();

    bool dead = false;
    int colorListIndex;
    Color currentColor;
    Color nextColor;
    Color deathCurrentColor;
    Color deathNextColor;
    LevelController levelController;
    float deathDuration = 1f;
    float deathTimer = 0;
    Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        colorListIndex = 0;

        SetColor();
        slider = GetComponent<Slider>();
        if (colorList.Count < 2)
        {
            transform.parent.gameObject.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            transform.parent.gameObject.GetComponent<Canvas>().enabled = true;

        }

        colorChangeTimer = timerCount;


        //Debug.Log(colorList.Count);
    }

    // Update is called once per frame
    void Update()
    {

        colorChangeTimer -= Time.deltaTime;
        if (!dead)
        {
            slider.value = 1 - colorChangeTimer / timerCount;

            if (colorChangeTimer <= 0)
            {
                colorListIndex = (colorListIndex + 1) % colorList.Count;
                currentColor = nextColor; // 1
                //Debug.Log("curr " + colorListIndex);
                nextColor = colorList[(colorListIndex + 1) % colorList.Count]; // 2
                //Debug.Log("next " + colorListIndex);
                colorChangeTimer = timerCount;

            }
        }

        else
        {
            if (deathTimer == 0)
            {
                deathCurrentColor = currentColor;
                deathNextColor = nextColor;
            }
            if (deathTimer < 1)
            {
                deathTimer += Time.deltaTime / deathDuration;
            }
            currentColor = Color.Lerp(deathCurrentColor, new Color(0, 0, 0), deathTimer);
            nextColor = Color.Lerp(deathNextColor, new Color(0, 0, 0), deathTimer);

        }
    }

    IEnumerator deathColor()
    {
        float t = 0;
        while (t < 1)
        {
            currentColor = Color.Lerp(currentColor, new Color(0, 0, 0), t);
            nextColor = Color.Lerp(currentColor, new Color(0, 0, 0), t);
            yield return new WaitForEndOfFrame();
        }
    }

    public Color getCurrentColor()
    {
        return currentColor;
    }
    public Color getNextColor()
    {
        return nextColor;
    }
    public void setDead(bool val)
    {
        dead = val;
    }
    public void SetColor()
    {
        colorList.Clear();
        if (levelController.GetCurrentLevel() >= 0)
        { // level 0
            colorList.Add(new Color(0.6078432f, 0.9647059f, 1f)); //Blue
            // currentColor = colorList[colorListIndex];
            // nextColor = colorList[(colorListIndex + 1) % colorList.Count];
            if (levelController.GetCurrentLevel() >= 4)
            { // level 3
                colorList.Add(new Color(0.7921569f, 1, 0.7490196f)); //Green
                if (levelController.GetCurrentLevel() >= 16)
                { // level 16
                    colorList.Add(new Color(1, 0.6784314f, 0.6784314f));//Red
                    if (levelController.GetCurrentLevel() >= 24)
                    { // level 24
                        colorList.Add(new Color(0.7411765f, 0.6980392f, 1)); //Purple

                        if (levelController.GetCurrentLevel() >= 36)
                        { // level 36
                            colorList.Add(new Color(0.9921569f, 1, 0.7137255f)); //purple
                        }
                    }
                }

            }
            currentColor = colorList[colorListIndex]; // 0
            nextColor = colorList[(colorListIndex + 1) % colorList.Count]; // 1
                                                                           //Debug.Log((colorListIndex));
        }
    }
}