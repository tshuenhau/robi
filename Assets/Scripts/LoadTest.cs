using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //Save.current = new Save();
        // if(Save.current == null) {
        //     SaveLoad.Reset();
        // }
        //SaveLoad.Reset();
        SaveLoad.Load();
        //Save.current.level = 1;
        // Save.current.unlockedSkins = new List<int>();
        // Save.current.unlockedSkins.Add(0);
        // Save.current.unlockedSkins.Add(1);
        //Save.current.unlockedSkins.Add(1);
        //Save.current.flux += 10;
        
    }
    void Start(){
        SaveLoad.SaveGame();
    }
    void Update(){
        //Debug.Log(Save.current.flux);
        //Debug.Log("Current Level is " + Save.current.level);
        // for(int i = 0; i < Save.current.unlockedSkins.Count; i++){
        //     Debug.Log(Save.current.unlockedSkins[i]);
        // }

    }

}
