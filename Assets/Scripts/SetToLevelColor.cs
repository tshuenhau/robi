using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SetToLevelColor : MonoBehaviour
{
    LevelController levelController;
    [SerializeField] float alphaValue = 1;
    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        if(GetComponent<Image>() != null){
             GetComponent<Image>().color = levelController.GetLevelColor(alphaValue);
        }
        else if(GetComponent<SpriteRenderer>() != null){
         GetComponent<SpriteRenderer>().color = levelController.GetLevelColor(alphaValue);

        }
    }
}
