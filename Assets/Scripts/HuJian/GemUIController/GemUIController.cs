using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemUIController : MonoBehaviour
{
    GameObject inLay;
    GameObject comPound;
    private void Awake()
    {
        inLay = GameObject.Find("Inlay");
        comPound = GameObject.Find("Compound");        
        comPound.gameObject.SetActive(false);
    }
    public void GotoCompound()
    {
        inLay.gameObject.SetActive(false);
        comPound.gameObject.SetActive(true);
    }
    public void GotoInlay()
    {
        inLay.gameObject.SetActive(true);
        comPound.gameObject.SetActive(false);
    }
}
