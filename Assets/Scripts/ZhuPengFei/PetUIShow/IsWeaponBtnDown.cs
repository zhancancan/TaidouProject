using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsWeaponBtnDown : MonoBehaviour {

    public static IsWeaponBtnDown _isWeaponBtnDown;
    Button weaponBtn;
    public bool weaponBtnDown = false;
    void Awake()
    {
        _isWeaponBtnDown = this;
        weaponBtn = transform.GetComponent<Button>();
        weaponBtn.onClick.AddListener(BtnDown);
    }

    void BtnDown()
    {
        weaponBtnDown = true;
    }


}