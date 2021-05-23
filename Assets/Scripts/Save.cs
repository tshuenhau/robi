using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
[System.Serializable]
public class Save
{
    public static Save current;
    public List<int> unlockedSkins;
    public int[] items; // <item id, number posessed>
    public int[] itemsEquipped; // <item id, equipped status>

    public int currentSkin;
    public int level;
    public int flux;
    //public int lives;
    //public int livesEquipped;

    //public Dictionary<string, bool> utilityEquip;
    public Save()
    {
        unlockedSkins = new List<int> { 0 };
        level = 16;
        flux = new int();
        // lives = 0;
        currentSkin = new int();
        //livesEquipped = -1;
        //utilityEquip = new Dictionary<string, bool>();
        items = new int[2] { 0, 0 };
        itemsEquipped = new int[2] { -1, -1 };
    }
}
