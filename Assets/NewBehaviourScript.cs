using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewBehaviourScript : MonoBehaviour {

    private Button btn;
    InventoryItem it;
    void Awake()
    {
        btn = this.GetComponent<Button>();
        btn.onClick.AddListener(qqqq);
    }
    private void qqqq()
    {
        transform.parent.SendMessage("abcd");
      
    }
}
