﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISelectSever : UIBase
{
    public override void OnEntering()
    {
        gameObject.SetActive(true);
    }
    public override void OnPausing()
    {

    }
    public override void OnResuming()
    {

    }
    public override void OnExiting()
    {
        gameObject.SetActive(false);
    }
    public void GoToHome()
    {
        gameObject.SetActive(false);        
    }

}