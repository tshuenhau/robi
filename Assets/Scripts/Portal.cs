using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Portal : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject tryAgainButton;
    [SerializeField] GameObject nextLevelButton;
    [SerializeField] GameObject happyPlayer;
    [SerializeField] GameObject deadPlayer;
    [SerializeField] GameObject unlockNewColorPlayer;
    [SerializeField] Animator levelIndicatorAnimator;

    [SerializeField] Animator menuAnimator;


    LevelController levelController;
    // Start is called before the first frame update
    void Start()
    {
        levelController = FindObjectOfType<LevelController>();
        GetComponent<SpriteRenderer>().color = levelController.GetLevelColor();
        //Debug.Log(PlayerPrefsController.GetLevel());
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        FindObjectOfType<Player>().Win();
        tryAgainButton.SetActive(false);
        nextLevelButton.SetActive(true);
        unlockNewColorPlayer.SetActive(false);
        deadPlayer.SetActive(false);
        happyPlayer.SetActive(true);
        menu.SetActive(true);
        menuAnimator.SetTrigger("FadeTransition");
        levelIndicatorAnimator.SetTrigger("ActivateMenu");
    }
    // Update is called once per frame
}
