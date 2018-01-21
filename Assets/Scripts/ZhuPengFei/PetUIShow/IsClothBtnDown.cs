using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsClothBtnDown : MonoBehaviour {

    public static IsClothBtnDown _isClothBtnDown;
    Button clothBtn;
    public bool clothBtnDown = false;
    void Awake()
    {
        _isClothBtnDown = this;
        clothBtn = transform.GetComponent<Button>();
        clothBtn.onClick.AddListener(BtnDown);
    }

    void BtnDown()
    {
        clothBtnDown = true;
    }
    

}
