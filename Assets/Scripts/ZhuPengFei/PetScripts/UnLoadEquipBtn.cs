using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnLoadEquipBtn : MonoBehaviour {

    private Button btn;
    InventoryItem it;
    void Awake()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(UnLoad);
    }
    //卸载按钮点击事件
    private void UnLoad()
    {
        transform.parent.SendMessage("CleanPetEquipUI");
    }
}
