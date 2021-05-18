using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    SpriteRenderer indicatorSpriteRenderer;
    SpriteRenderer mySpriteRenderer;
    ColorController colorController;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        //indicatorSpriteRenderer = GameObject.Find("Skin").GetComponent<SpriteRenderer>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        colorController = FindObjectOfType<ColorController>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!player.isDead()){
            mySpriteRenderer.color = colorController.getCurrentColor();
            
        }
        else{
            Destroy(gameObject);
        }
        
    }
}
