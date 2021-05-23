using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string LEVEL_KEY = "level key";
    const string SKIN_KEY = "skin key";

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt(LEVEL_KEY, PlayerPrefs.GetInt(LEVEL_KEY, 1));

    }

    // Update is called once per frame

}
