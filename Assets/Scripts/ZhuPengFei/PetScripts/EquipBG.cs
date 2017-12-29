using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EquipBG : MonoBehaviour {

    private PetEquipShow petEquip;
    private PetEquipShow petWeapon;

    void Awake()
    {
        petEquip = transform.Find("Cloth").GetComponent<PetEquipShow>();
        petWeapon = transform.Find("Weapon").GetComponent<PetEquipShow>();

        //注册事件
        PetInfo._petInstance.OnPetInfoChanged += this.OnPetInfoChanged;
    }

    //注销事件，避免游戏物体销毁，仍有空方法在运行
    void OnDestroy()
    {
        PetInfo._petInstance.OnPetInfoChanged -= this.OnPetInfoChanged;
    }
    
    void OnPetInfoChanged(PetInfoType type)
    {
        if (type==PetInfoType.PetEquip)
        {
        UpdateEquipShow();
        } 
    }
    //装备更换更新方法
    void UpdateEquipShow()
    {
        PetInfo info = PetInfo._petInstance;

        petWeapon.SetInventoryItem(info.petWeaponID);
        petEquip.SetInventoryItem(info.petEquipID);
    }
   
   
}
