﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // REMOVE THIS WHEN DONE 
public class Obstacle : MonoBehaviour
{
    BoxCollider2D myBoxCollider2D;
    Player player;
    ColorController colorController;
    SpriteRenderer mySpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        colorController = FindObjectOfType<ColorController>();
        myBoxCollider2D = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        //ToggleActivation();
        //Debug.Log(player.getLives());
    }
    void OnTriggerEnter2D(Collider2D collider){
        //Destroy(collider.gameObject);
        ////SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        if(!player.isDead()){
            if(player.getLives() > 0){player.decreaseLives();}
            
            else{
                player.Die();
            }
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    // Update is called once per frame
    void Update()
    {
        ToggleActivation();
    }
    public void ToggleActivation(){
        if(colorController.getCurrentColor() == mySpriteRenderer.color){
            myBoxCollider2D.enabled = false;
        }
        else{
            myBoxCollider2D.enabled = true;
        }
    }
}
