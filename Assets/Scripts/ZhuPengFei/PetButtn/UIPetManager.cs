using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPetManager : MonoBehaviour {

    public static UIPetManager _uiPetManager;
    [HideInInspector]
    public bool isHaveLion;     //是否已经存在狮子UI模型
    [HideInInspector]
    public bool isHaveFairy;    //是否已经存在仙女UI模型
    [HideInInspector]
    public bool isHaveElf;      //是否已经存在精灵UI模型

    GameObject UILionPrefab;          //狮子UI预设体
    GameObject UIElfPrefab;           //小精灵UI预设体
    GameObject UIFairyPrefab;         //小仙女UI预设体
    GameObject UILionText;            //狮子按钮Text
    GameObject UIElfText;             //小精灵按钮Text
    GameObject UIFairyText;           //小仙女按钮Text

    //防止UI中出现多个宠物叠加出现在同一界面
    [HideInInspector]
    public bool lion = false;
    [HideInInspector]
    public bool fairy = false;
    [HideInInspector]
    public bool elf = false;

    //宠物UI面板的三个点击宠物按钮
    Button lionBtn;             
    Button elfBtn;
    Button fairyBtn;
 
    private void Awake()
    {
        _uiPetManager = this;

        lionBtn = transform.Find("LionBtn").GetComponent<Button>();
        fairyBtn = transform.Find("FairyBtn").GetComponent<Button>();
        elfBtn = transform.Find("ElfBtn").GetComponent<Button>();

        UILionPrefab = transform.Find("LionBtn/UILion").gameObject;
        UIFairyPrefab = transform.Find("FairyBtn/UIFairy").gameObject;
        UIElfPrefab = transform.Find("ElfBtn/UIElf").gameObject;

        UILionText = transform.Find("LionBtn/UILionText").gameObject;
        UIElfText = transform.Find("ElfBtn/UIElfText").gameObject;
        UIFairyText = transform.Find("FairyBtn/UIFairyText").gameObject;

        lionBtn.onClick.AddListener(Lion);
        fairyBtn.onClick.AddListener(Fairy);
        elfBtn.onClick.AddListener(Elf);
    }
     
    //-------------------------------------------按钮触发方法--------------------------------------------
    void Lion()
    {
        SoundManager.Instance.PlayAudio(ConstDates.ButtonSound);
        lion = true;                                                                 //
        CreatPet();
        UIFairyPrefab.SetActive(false);
        UIElfPrefab.SetActive(false);
    }
    void Fairy()
    {
        SoundManager.Instance.PlayAudio(ConstDates.ButtonSound);
        fairy = true;
        CreatPet();
        UILionPrefab.SetActive(false);
        UIElfPrefab.SetActive(false);
    }
    void Elf()
    {
        SoundManager.Instance.PlayAudio(ConstDates.ButtonSound);
        elf = true;
        CreatPet();
        UILionPrefab.SetActive(false);
        UIFairyPrefab.SetActive(false);
    }
    //____________________________________________________________________________________________________
    

    //-------------------------------------宠物显示方法-----------------------------------------------------
    public void CreatPet ()
    {
        if (EquipPopup._equipPopUp.isUILion)                                  //点击的是狮子
        {   
            UILionText.SetActive(true);                                      //激活场景中的宠物模型的Text
            if (lion){ UILionPrefab.SetActive(true); }                       //激活场景中的宠物UI模型
            isHaveLion = true;                                               //狮子宠物已存在
        }
        if (EquipPopup._equipPopUp.isUIElf)
        {
            UIElfText.SetActive(true);
            if (elf){  UIElfPrefab.SetActive(true);  }
            isHaveElf = true;
        }
        if (EquipPopup._equipPopUp.isUIFairy)
        {
            UIFairyText.SetActive(true);
            if (fairy) {  UIFairyPrefab.SetActive(true);  }
            isHaveFairy = true;  
        }
    }
    
}
