using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGemstoneCompose : UIBase
{
    private GameObject inLay;
    private GameObject comPound;
    private Button exit;

    private void Awake()
    {
        inLay = transform.Find("GemBG/InlayBtn/Inlay").gameObject;
        comPound = transform.Find("GemBG/CompoundBtn/Compound").gameObject;
        exit = transform.Find("GemBG/EscBtn").GetComponent<Button>();
        comPound.gameObject.SetActive(false);
    }

    void Start()
    {
        exit.onClick.AddListener(()=> {UIManager.Instance.PopUIPanel();});
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

    public override void OnEntering()
    {
        gameObject.SetActive(true);
    }

    public override void OnPausing()
    {
        gameObject.SetActive(false);
    }

    public override void OnResuming()
    {

    }

    public override void OnExiting()
    {
        gameObject.SetActive(false);
    }
}
