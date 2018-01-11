using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRename : MonoBehaviour
{
    private InputField nameInput;
    private Button okBtn;
    private Button cancelBtn;

	void Awake ()
	{
	    nameInput = transform.Find("NewNameInput").GetComponent<InputField>();
	    okBtn = transform.Find("Ok").GetComponent<Button>();
	    cancelBtn = transform.Find("Cancel").GetComponent<Button>();
	}

    void Start()
    {
        okBtn.onClick.AddListener(OnOkBtnClick);
        cancelBtn.onClick.AddListener(OnCancelBtnClick);
    }

    void OnOkBtnClick()
    {
        if (this.gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }

    void OnCancelBtnClick()
    {
        if (this.gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
    }
}
