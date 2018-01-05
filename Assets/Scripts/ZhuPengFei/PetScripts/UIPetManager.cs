using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPetManager : MonoBehaviour {

    public static UIPetManager _uiPetManager;
    public bool isHaveLion;     //是否已经存在狮子UI模型
    public bool isHaveFairy;    //是否已经存在仙女UI模型
    public bool isHaveElf;      //是否已经存在精灵UI模型
    private void Awake()
    {
        _uiPetManager = this;
    }
    
    private void FixUpdate ()
    {

        if (EquipPopup._equipPopUp.isUILion)
        {
            transform.Find("UILion").gameObject.SetActive(true);
            isHaveLion = true;         
        }
        if (EquipPopup._equipPopUp.isUIElf)
        {          
            transform.Find("UIElf").gameObject.SetActive(true);
            isHaveElf = true;
        }
        if (EquipPopup._equipPopUp.isUIFairy)
        {
            transform.Find("UIFairy").gameObject.SetActive(true);
            isHaveFairy = true;
        }
    }
    
}
