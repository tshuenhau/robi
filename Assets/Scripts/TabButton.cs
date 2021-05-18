using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour,  IPointerClickHandler, IPointerExitHandler //IPointerEnterHandler,
{
    public TabGroup tabGroup;
    public Image background;

    [SerializeField] string tabName;
    //[SerializeField] bool initialTab;


    public void OnPointerClick(PointerEventData eventData){
        Debug.Log("Clicked");
        tabGroup.OnTabSelected(this);
    }
    // public void OnPointerEnter(PointerEventData eventData){
    //     Debug.Log("Entered");
    //     Debug.Log(this.name);
    //     tabGroup.OnTabEnter(this);
    // }
    public void OnPointerExit(PointerEventData eventData){
        tabGroup.OnTabExit(this);
    }

    public string getTabName(){
        return tabName;
    }


    // Start is called before the first frame update
    void Awake()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
        // if(initialTab) {
        //     tabGroup.OnTabEnter(this);
        // }
    }
}
