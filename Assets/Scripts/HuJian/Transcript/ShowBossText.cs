using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
public class ShowBossText:MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{   
    Text showTxt;  
    private void Awake()
    {     
        showTxt = GameObject.Find("ShowTxt").GetComponent<Text>();       
        showTxt.gameObject.SetActive(false);       
    }
    public void OnPointerEnter(PointerEventData eventData)
    {       
        showTxt.gameObject.SetActive(true);        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        showTxt.gameObject.SetActive(false);      
    }

}
