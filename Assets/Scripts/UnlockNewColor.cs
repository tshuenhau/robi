using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockNewColor : MonoBehaviour
{
    [SerializeField] GameObject tryAgainButton;
    [SerializeField] GameObject nextLevelButton;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject happyPlayer;
    [SerializeField] GameObject deadPlayer;
    [SerializeField] GameObject unlockNewColorPlayer;

    [SerializeField] Animator levelIndicatorAnimator;
    [SerializeField] Animator menuAnimator;

    LevelController levelController;
    ColorController colorController;

    void OnTriggerEnter2D(Collider2D collider)
    {
        FindObjectOfType<Player>().Win();
        levelController.UpdateCurrentLevel(1);
        colorController = FindObjectOfType<ColorController>();
        deadPlayer.SetActive(false);
        happyPlayer.SetActive(false);
        unlockNewColorPlayer.SetActive(true);
        tryAgainButton.SetActive(false);
        nextLevelButton.SetActive(true);
        //levelController.UpdateCurrentLevel(1);
        colorController.SetColor();
        menu.SetActive(true);
        menuAnimator.SetTrigger("FadeTransition");

        levelIndicatorAnimator.SetTrigger("ActivateMenu");


    }
    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
    }

    // Update is called once per frame

}
