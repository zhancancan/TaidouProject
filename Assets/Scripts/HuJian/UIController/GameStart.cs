using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    private void Awake()
    {
        UIManager.Instance.PushUIPanel(ConstDates.UIStart);
    }

}
