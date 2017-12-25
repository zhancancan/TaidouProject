using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KnapsackRole : MonoBehaviour {
    KnapsackRoleEquip helmet, wing, ring, necklace, shoes, clothes, bracelet, weapon;
    private void Awake()
    {
        helmet = transform.Find("Helmet").GetComponent<KnapsackRoleEquip>();
        clothes = transform.Find("Clothes").GetComponent<KnapsackRoleEquip>();
        shoes = transform.Find("Shoes").GetComponent<KnapsackRoleEquip>();
        wing = transform.Find("Wing").GetComponent<KnapsackRoleEquip>();
        weapon = transform.Find("Weapon").GetComponent<KnapsackRoleEquip>();
        ring = transform.Find("Ring").GetComponent<KnapsackRoleEquip>();
        bracelet = transform.Find("Bracelet").GetComponent<KnapsackRoleEquip>();
        necklace = transform.Find("Necklace").GetComponent<KnapsackRoleEquip>();

        PlayInfo._instance.OnPlayInfoChanged += this.OnPlayInfoChanged;
        

    }
    private void OnDestroy()
    {
        PlayInfo._instance.OnPlayInfoChanged -= this.OnPlayInfoChanged;
    }
    void UpdateShow()
    {
        PlayInfo info = PlayInfo._instance;
        helmet.SetInventoryItem(info.helmet);
        clothes.SetInventoryItem(info.clothes);
        shoes.SetInventoryItem(info.shoes);
        wing.SetInventoryItem(info.wing);
        weapon.SetInventoryItem(info.weapon);
        ring.SetInventoryItem(info.ring);
        bracelet.SetInventoryItem(info.bracelet);
        necklace.SetInventoryItem(info.necklace);

       
    }
    void OnPlayInfoChanged(InfoType type)
    {
        if (type == InfoType.Equip)
        {
            UpdateShow();
        }
    }

}
