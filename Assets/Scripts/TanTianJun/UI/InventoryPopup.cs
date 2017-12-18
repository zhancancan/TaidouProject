using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPopup : MonoBehaviour {

    InventoryItem it;
    Image img;
    Text nametxt, destxt, btntxt;
    Button closebtn;
    private void Awake()
    {
        img = transform.Find("Bg/Introduction/Img").GetComponent<Image>();
        nametxt = transform.Find("Bg/Introduction/NameText").GetComponent<Text>();
        destxt = transform.Find("Bg/Introduction/DesText").GetComponent<Text>();
        btntxt = transform.Find("Bg/usetenbtn/Text/Text").GetComponent<Text>();
        closebtn = transform.Find("Bg/Close").GetComponent<Button>();
        closebtn.onClick.AddListener(() => {it=null; gameObject.SetActive(false); });
    }
    public void Show(InventoryItem it)
    {
        gameObject.SetActive(true);
        this.it = it;

        img.sprite = it.Inventory.Icon;
     
        nametxt.text = it.Inventory.Name;
        destxt.text = it.Inventory.Des;
        btntxt.text = "(" + it.Count.ToString() + ")";
    } 
}
