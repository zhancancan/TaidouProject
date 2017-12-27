using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnLockUI : MonoBehaviour {
    private void Awake()
    {
        gameObject.SetActive(false);

    }
    public void Show()
    { 
            gameObject.SetActive(true);
           
    }

   
 
}
