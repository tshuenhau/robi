using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    SpriteRenderer indicatorSpriteRenderer;
    SpriteRenderer[] mySpriteRenderers;
    ColorController colorController;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        //indicatorSpriteRenderer = GameObject.Find("Skin").GetComponent<SpriteRenderer>();
        colorController = FindObjectOfType<ColorController>();
        mySpriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        player = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.isDead()){
            foreach(SpriteRenderer mySpriteRenderer in mySpriteRenderers){
                mySpriteRenderer.color = colorController.getCurrentColor();
            }
        }
        
    }
}
