using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomTrigger : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] Animator levelIndicatorAnimator;

    Player player;
    void Start()
    {
        //menu = GameObject.Find("Menu");
        player = FindObjectOfType<Player>();
        if (!player.isDead())
        {
            menu.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        //TriggerLoss
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // placeholder until lose screen fin
        menu.SetActive(true);
        levelIndicatorAnimator.SetTrigger("ActivateMenu");
        if (player != null)
        {
            Destroy(player.gameObject);

        }
    }

}
