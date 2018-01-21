using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class EquipPopup : MonoBehaviour, IDragHandler{

    //-----------------------------------
    public static EquipPopup _equipPopUp;


    InventoryItem it;
    InventoryItemUI itUI;
    KnapsackRoleEquip roleEquip;
    Image equipimg;
    Text equipText, qualityText, damageText, hpText, desText, powerText, levelText;
    [HideInInspector]
    public Text psText;
    Button closebtn;  //关闭
    Button equipbtn;   //装备
    Button upgradebtn;  //升级
    Text btntxt;
    bool isleft = true;
    public PowerShow powershow;

    //-----------------------------------------------
    public bool isUILion;
    public bool isUIFairy;
    public bool isUIElf;

    Button existBtn;

    private void Awake()
    {
        _equipPopUp = this;

        equipimg = transform.Find("EquiptInf/EquipBg").GetComponent<Image>();
        equipText = transform.Find("EquiptInf/Introduction/EquipText").GetComponent<Text>();
        qualityText = transform.Find("EquiptInf/Introduction/QualityText/Text").GetComponent<Text>();
        damageText = transform.Find("EquiptInf/Introduction/DamageText/Text").GetComponent<Text>();
        hpText = transform.Find("EquiptInf/Introduction/HpText/Text").GetComponent<Text>();
        desText = transform.Find("EquiptInf/Introduction/DesText").GetComponent<Text>();
        powerText = transform.Find("EquiptInf/Introduction/PowerText/Text").GetComponent<Text>();
        levelText = transform.Find("EquiptInf/Introduction/LevelText/Text").GetComponent<Text>();
        psText = transform.root.Find("Knapsack/Equipt/Property/ATTACK/PSText").GetComponent<Text>();
        btntxt = transform.Find("EquiptInf/equipbtn/Text").GetComponent<Text>();
        closebtn = transform.Find("EquiptInf/Close").GetComponent<Button>();
        closebtn.onClick.AddListener(close);
        upgradebtn = transform.Find("EquiptInf/upgradebtn").GetComponent<Button>();
        upgradebtn.onClick.AddListener(Upgrade);

        existBtn = transform.Find("EquiptInf/Exist/ExistBtn").GetComponent<Button>();
        existBtn.onClick.AddListener(ExistUI);
    }
    private void Start()
    {
        equipbtn = transform.Find("EquiptInf/equipbtn").GetComponent<Button>();
        equipbtn.onClick.AddListener(onequip);

    }
    private void Update()
    {
        psText.text = PlayInfo._instance.GetOverallPower().ToString();
    }
    public void Show(InventoryItem it,InventoryItemUI itUI,KnapsackRoleEquip roleEquip,bool isleft=true)     //物品的显示
    {
        gameObject.SetActive(true);
        this.it = it;
        this.itUI = itUI;
        this.roleEquip = roleEquip;
        this.isleft = isleft;
        Vector3 pos = transform.localPosition;
        if (isleft)
        {
            transform.localPosition = new Vector3(-370, 9, pos.z);
            btntxt.text = "装备";
        }
        else
        {
            transform.localPosition = new Vector3(380, 9, pos.z);
            btntxt.text = "卸下";
        }
        
        equipimg.sprite = it.Inventory.Icon;
        equipText.text = it.Inventory.Name;
        qualityText.text = it.Inventory.Quality.ToString();
        damageText.text = it.Inventory.Damage.ToString();
        hpText.text = it.Inventory.Hp.ToString();
        powerText.text = it.Inventory.Power.ToString();
        desText.text = it.Inventory.Des;
        levelText.text = it.Level.ToString();
        
       
    }
    public   void close()
    {
        closeon();
        transform.parent.parent.SendMessage("DisableButton");
    }
   public  void closeon()
    {
        ClearObject();
        gameObject.SetActive(false);
    }
  
     void onequip()
    {
        int startvalue = PlayInfo._instance.GetOverallPower();
        if (isleft)
        {

           
           
            if (it.Isdressed == true) { close(); return; }
            if (it.Inventory.InventoryType == InventoryType.Equip)

            {
                itUI.Clear();//清空装备身上的各种
                PlayInfo._instance.DressOn(it);
              
            }
            if (it.Inventory .InventoryType== InventoryType.PetEquip)
            {
                //------------------------------宠物------------------ -
                itUI.Clear();//清空装备身上的各种
                PetInfo._petInstance.PetDressOn(it);
            }
            //-------------------------通知UIPetManager激活宠物模型UI----------------------------
            if (it.Inventory.InventoryType == InventoryType.Pet)                                    //如果点击背包里面的东西类型是宠物
            {
                if (it.Inventory.Name=="烈焰狂狮"&&UIPetManager._uiPetManager.isHaveLion==false)    //当狮子宠物不存在的时候
                {
                    itUI.Clear();                                                                   //清除背包宠物UI
                    isUILion = true;                                                                //如果点击的是狮子
                    UIPetManager._uiPetManager.CreatPet();                                          //调用宠物UI模型的激活
                }
                if (it.Inventory.Name == "小精灵"&&UIPetManager._uiPetManager.isHaveElf == false)
                {
                    itUI.Clear();
                    isUIElf = true;
                    UIPetManager._uiPetManager.CreatPet();                              
                }
                if (it.Inventory.Name == "小仙女"&&UIPetManager._uiPetManager.isHaveFairy == false)
                { 
                    itUI.Clear();
                    isUIFairy = true;
                    UIPetManager._uiPetManager.CreatPet();
                }
            }
        }
        else
        {
            if (it.Isdressed == false) { close(); return; }

            roleEquip.Clear();
            if (it.Inventory.InventoryType == InventoryType.Equip)

            {
                PlayInfo._instance.DressOff(it);
            }
            //-------------------------------
            if (it.Inventory.InventoryType == InventoryType.PetEquip)

            {
                PetInfo._petInstance.PetDressOff(it);
            }     

        }
        int endvalue = PlayInfo._instance.GetOverallPower();
        powershow.ShowPowerChange(startvalue, endvalue);
        InventoryUI._instance.SendMessage("UpdateCount");
        close();
    }
    //右击穿装备
    public void Onequip(InventoryItem it)
    {
        this.it = it;
        PlayInfo._instance.DressOn(it);       
    }
    //右击卸装备
    public void Offequip(InventoryItem it)
    {
        this.it = it;
        PlayInfo._instance.DressOff(it);      
    }
    void ClearObject()
    {
        it = null;
        itUI = null;
    }

   


    void Upgrade()
    {
        int CoinNeed = (it.Level+1)*it.Inventory.Price;
        bool isSuccess = PlayInfo._instance.GetCoin(CoinNeed);
        if (isSuccess)
        {
            it.Level += 1;
            levelText.text = it.Level + "";
        }
        else {
            MessageManager._instance.ShowMessage("升级所需金币不足");
        }
    } //点击升级按钮
    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.SetSiblingIndex(40);
        gameObject.transform.position = eventData.position;
    }

    void ExistUI()
    {
        transform.Find("EquiptInf/Exist").gameObject.SetActive(false);
    }
}
