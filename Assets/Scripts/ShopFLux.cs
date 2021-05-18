using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopFLux : MonoBehaviour
{
    TextMeshProUGUI fluxText;
    // Start is called before the first frame update
    void Start()
    {
        fluxText= GetComponent<TextMeshProUGUI>();  
    }

    // Update is called once per frame
    void Update()
    {
        fluxText.text = "<sprite=0>" + Save.current.flux.ToString();
       
    }
}
