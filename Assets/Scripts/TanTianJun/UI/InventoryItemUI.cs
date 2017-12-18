using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryItemUI : MonoBehaviour {
    Image image;
    Text txt;
    Image Image
    {
        get
        {
            if (image == null)
            {
                image = transform.Find("item").GetComponent<Image>();
            }
            return image;
        }
    }
    Text Txt
    {
        get
        {
            if (txt == null)
            {
                txt = transform.Find("Text").GetComponent<Text>();
            }
            return txt;
        }
    }
     public  InventoryItem it;
    public void SetInventoryItem(InventoryItem it)
    {
        this.it = it;
        Image.sprite = it.Inventory.Icon;
        if (it.Count <= 1)
        {
            Txt.text = "";
        }
        else
        {
            Txt.text = it.Count.ToString();
        }
    }
    public void Clear()
    {
        it = null;
        Txt.text = "";
        Image.sprite = Resources.Load("TanTianJun/Image/bg_道具", typeof(Sprite)) as Sprite;
    }
    Button btn;
    private void Awake()
    {
        btn = GetComponent<Button>();
        
        btn.onClick.AddListener(delegate() {
            if (it != null)
            {
                object[] objectArray = new object[3];
                objectArray[0] = it;
                objectArray[1] = true;
                objectArray[2] = this;

                transform.parent.parent.parent.parent.parent.SendMessage("OnInventoryClick", objectArray);
            }
        });
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
           
        }
    }
}
