using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipPopup : MonoBehaviour {

    InventoryItem it;
    InventoryItemUI itUI;
    KnapsackRoleEquip roleEquip;
    Image equipimg;
    Text equipText, qualityText, damageText, hpText, desText, powerText,levelText;
    Button closebtn;
    Button equipbtn;
    Text btntxt;
    bool isleft = true;
    public PowerShow powershow;
    private void Awake()
    {
        equipimg = transform.Find("EquiptInf/EquipBg").GetComponent<Image>();
        equipText = transform.Find("EquiptInf/Introduction/EquipText").GetComponent<Text>();
        qualityText = transform.Find("EquiptInf/Introduction/QualityText/Text").GetComponent<Text>();
        damageText = transform.Find("EquiptInf/Introduction/DamageText/Text").GetComponent<Text>();
        hpText = transform.Find("EquiptInf/Introduction/HpText/Text").GetComponent<Text>();
        desText = transform.Find("EquiptInf/Introduction/DesText").GetComponent<Text>();
        powerText = transform.Find("EquiptInf/Introduction/PowerText/Text").GetComponent<Text>();
        levelText = transform.Find("EquiptInf/Introduction/LevelText/Text").GetComponent<Text>();
        btntxt = transform.Find("EquiptInf/equipbtn/Text").GetComponent<Text>();
        closebtn = transform.Find("EquiptInf/Close").GetComponent<Button>();
        closebtn.onClick.AddListener(close);
       
    }
    private void Start()
    {
        equipbtn = transform.Find("EquiptInf/equipbtn").GetComponent<Button>();
        equipbtn.onClick.AddListener(onequip);

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
            transform.localPosition = new Vector3(-Mathf.Abs(pos.x), pos.y, pos.z);
            btntxt.text = "装备";
        }
        else
        {
            transform.localPosition = new Vector3(Mathf.Abs(pos.x), pos.y, pos.z);
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
    void close()
    {
        ClearObject();
        gameObject.SetActive(false);
        transform.parent.parent.SendMessage("DisableButton");
    }
  
     void onequip()
    {
        int startvalue = PlayInfo._instance.GetOverallPower();
        if (isleft)
        {
           
            if (it.Inventory.InventoryType == InventoryType.Equip)
            {
                itUI.Clear();//清空装备身上的各种
                PlayInfo._instance.DressOn(it);
            }
        }
        else
        {
            roleEquip.Clear();
            PlayInfo._instance.DressOff(it);
        }
        int endvalue = PlayInfo._instance.GetOverallPower();
        powershow.ShowPowerChange(startvalue, endvalue);
        InventoryUI._instance.SendMessage("UpdateCount");
        close();
    }
    public void Onequip(InventoryItem it)
    {
        this.it = it;
        PlayInfo._instance.DressOn(it);
    }
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
}
