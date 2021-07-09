using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComingSoon : MonoBehaviour
{

    // Start is called before the first frame update
    PersistBetweenScenes persistBetweenScenes;
    void Start()
    {
        persistBetweenScenes = FindObjectOfType<PersistBetweenScenes>();
        gameObject.transform.GetChild(0).gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (persistBetweenScenes.GetWin() == true)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
