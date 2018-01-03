using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChoiceController : MonoBehaviour {

    Button loginGameBtn;
    Animator boyAnim;
    public GameObject boyModel;

    bool isWalk = false;
    private void Awake()
    {
        loginGameBtn = transform.Find("LoginGameBTN").GetComponent<Button>();
        boyAnim = boyModel.GetComponent<Animator>();
        loginGameBtn.onClick.AddListener(()=> {
            isWalk = true;
        });
    }
    private void Update()
    {
        if (isWalk)
        {
            boyAnim.SetTrigger("BoyChoice");
            boyModel.transform.position -= transform.forward * 100f * Time.deltaTime;
        }
    }
}
