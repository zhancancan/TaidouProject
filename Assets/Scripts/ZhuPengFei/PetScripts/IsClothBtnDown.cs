using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsClothBtnDown : MonoBehaviour {

    public static IsClothBtnDown _isBtnDown;
    Button clothBtn;
    public bool btnDown = false;
    void Awake()
    {
        _isBtnDown = this;
        clothBtn = transform.GetComponent<Button>();
        clothBtn.onClick.AddListener(BtnDown);
    }

    void BtnDown()
    {
        btnDown = true;
    }
    

}
