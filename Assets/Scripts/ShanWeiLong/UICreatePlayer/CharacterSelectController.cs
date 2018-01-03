using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectController : MonoBehaviour {

    //返回按键
    Button returnBtn;
    //创建人物按键
    Button createPersonBtn;
    //男按键
    Button soldierBtn;
    //女按键
    Button assassinBtn;
    //输入创建人物名称文本框
    InputField createNameField;
    //战士介绍
    GameObject soldierTXT;
    //刺客介绍
    GameObject assassinTXT;

    //战士，刺客模型
    private GameObject soldierObj;
    private GameObject assassinObj;

    private void Awake()
    {
        //需要修改
        soldierObj = Instantiate(Resources.Load<GameObject>(ConstDates.ResourcePrefabDirSwl + "/BoyCreateModel"));
        assassinObj = Instantiate(Resources.Load<GameObject>(ConstDates.ResourcePrefabDirSwl + "/GirlCreateModel"));

        returnBtn = transform.Find("ReturnBTN").GetComponent<Button>();
        createPersonBtn=transform.Find("CreatePersonBTN").GetComponent<Button>();
        soldierBtn = transform.Find("SoldierBTN").GetComponent<Button>();
        assassinBtn = transform.Find("AssassinBTN").GetComponent<Button>();
        createNameField = transform.Find("CreateNameInputField").GetComponent<InputField>();
        soldierTXT = GameObject.Find("SoldierIntroductionTXT");
        assassinTXT = GameObject.Find("AssassinIntroductionTXT");
        assassinTXT.SetActive(false);
        assassinObj.SetActive(false);

        Animator soldierAnim = soldierObj.GetComponent<Animator>();
        Animator assassinAnim = assassinObj.GetComponent<Animator>();

        //点击返回键
        returnBtn.onClick.AddListener(()=> { Debug.Log(111); });

        //点击创建人物
        createPersonBtn.onClick.AddListener(()=> { Debug.Log(222); });

        //战士按钮
        soldierBtn.onClick.AddListener(()=> {
            soldierTXT.SetActive(true);
            assassinTXT.SetActive(false);
            soldierObj.SetActive(true);
            assassinObj.SetActive(false);
            soldierAnim.SetTrigger("BoyShow");
        });

        //刺客按钮
        assassinBtn.onClick.AddListener(()=> {
            soldierTXT.SetActive(false);
            assassinTXT.SetActive(true);
            soldierObj.SetActive(false);
            assassinObj.SetActive(true);
            assassinAnim.SetTrigger("GirlShow");
        });

        //任务名称文本框
        //createNameField.onValueChanged.AddListener();
    }
}
