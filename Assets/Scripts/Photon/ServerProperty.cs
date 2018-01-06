using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerProperty : MonoBehaviour {
    Button btn;
    private void Awake()
    {
        btn = transform.GetComponent<Button>();
        btn.onClick.AddListener(() =>
        {
            transform.root.SendMessage("OnServerSelect", this.gameObject);
            GameObject.Find("GameManager").SendMessage("OnServerSelect", this.gameObject);

        });
    }
    public string ip = "127.0.0.1:4530";
    private string _name;
    public string name {
        
        set
        {
            transform.Find("SeverNameTxt").GetComponent<Text>().text = value;
            _name = value;
        }
        get
        {
            return _name;
        }
    }
    public int count = 100;
    
}
