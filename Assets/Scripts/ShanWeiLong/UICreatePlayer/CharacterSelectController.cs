using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEditor.Animations;
using UnityEngine.SceneManagement;
using System;
using TaidouCommon.Model;
using System.Text.RegularExpressions;

public enum ProfessionType
{
    战士,
    法师,
    弓箭手
}

public class CharacterSelectController : MonoBehaviour {

    //返回按键
    Button returnBtn;
    //创建人物按键
    Button createPersonBtn;
    //男按键
    Button maleBtn;
    //女按键
    Button femaleBtn;
    //战士按键
    Button warriorBtn;
    //法师按键
    Button mageBtn;
    //弓箭手按键
    Button archerBtn;
    //输入创建人物名称文本框
    InputField createNameField;
   public  Text nametxt;
    //战士介绍
    GameObject warriorTXT;
    //刺客介绍
    GameObject mageTXT;
    //弓箭手介绍
    GameObject archerTXT;
    //男预制体生成点
    GameObject bornPointMale;
    //女预制体生成点
    GameObject bornPointFemale;
    //展示点
    GameObject showPoint;

    //战士，法师，弓箭手模型
    private GameObject warriorFemaleObj;
    private GameObject warriorMaleObj;
    private GameObject mageFemaleObj;
    private GameObject mageMaleObj;
    private GameObject archerFemaleObj;
    private GameObject archerMaleObj;

    //场景中生成的预制体
    GameObject goWarriorFemale;
    GameObject goWarriorMale;
    GameObject goMageFemale;
    GameObject goMageMale;
    GameObject goArcherFemale;
    GameObject goArcherMale;

    Animator warriorFemaleAnim;
    Animator warriorMaleAnim;
    Animator mageFemaleAnim;
    Animator mageMaleAnim;
    Animator archerFemaleAnim;
    Animator archerMaleAnim;
    AnimatorController warriorAnimatorController;
    AnimatorController mageAnimatorController;
    AnimatorController archerAnimatorController;


    public static CharacterSelectController _instance;
    private void Awake()
    {
        _instance = this;
        //需要修改
        warriorFemaleObj = Resources.Load<GameObject>(ConstDates.ResourcePlayerPrefabDirSwl + ConstDates.WarriorFemale);
        warriorMaleObj = Resources.Load<GameObject>(ConstDates.ResourcePlayerPrefabDirSwl + ConstDates.WarriorMale);
        mageFemaleObj = Resources.Load<GameObject>(ConstDates.ResourcePlayerPrefabDirSwl + ConstDates.MageFemale);
        mageMaleObj = Resources.Load<GameObject>(ConstDates.ResourcePlayerPrefabDirSwl + ConstDates.MageMale);
        archerFemaleObj = Resources.Load<GameObject>(ConstDates.ResourcePlayerPrefabDirSwl + ConstDates.ArcherFemale);
        archerMaleObj = Resources.Load<GameObject>(ConstDates.ResourcePlayerPrefabDirSwl + ConstDates.ArcherMale);
      
        //生成，展示点
        bornPointFemale = GameObject.Find("BornPointFemale");
        bornPointMale = GameObject.Find("BornPointMale");
        showPoint = GameObject.Find("ShowPoint");

        returnBtn = transform.Find("ReturnBTN").GetComponent<Button>();
        createPersonBtn=transform.Find("CreatePersonBTN").GetComponent<Button>();
        maleBtn = transform.Find("MaleBTN").GetComponent<Button>();
        femaleBtn = transform.Find("FemaleBTN").GetComponent<Button>();
        warriorBtn = transform.Find("WarriorBTN").GetComponent<Button>();
        mageBtn = transform.Find("MageBTN").GetComponent<Button>();
        archerBtn = transform.Find("ArcherBTN").GetComponent<Button>();
        createNameField = transform.Find("CreateNameInputField").GetComponent<InputField>();
        warriorTXT = transform.Find("Introduction/WarriorIntroductionTXT").gameObject;
        mageTXT = transform.Find("Introduction/MageIntroductionTXT").gameObject;
        archerTXT = transform.Find("Introduction/ArcherIntroductionTXT").gameObject;
        warriorTXT.SetActive(false);
        mageTXT.SetActive(false);
        archerTXT.SetActive(false);
        nametxt = createNameField.transform.Find("Text").GetComponent<Text>();

    }
    public string profession;
    public bool isman;
    private void Start()
    {
        //状态机
        /*RuntimeAnimatorController*/ warriorAnimatorController
            = Resources.Load<AnimatorController>(ConstDates.ResourceAnimatorPrefabDirSwl + ConstDates.WarriorAnimator);
        /*RuntimeAnimatorController*/ mageAnimatorController
            = Resources.Load<AnimatorController>(ConstDates.ResourceAnimatorPrefabDirSwl + ConstDates.MageAnimator);
        /*RuntimeAnimatorController*/ archerAnimatorController
            = Resources.Load<AnimatorController>(ConstDates.ResourceAnimatorPrefabDirSwl + ConstDates.ArcherAnimator);

        //人物Animator获取
        warriorFemaleAnim = warriorFemaleObj.GetComponent<Animator>();
        warriorMaleAnim = warriorMaleObj.GetComponent<Animator>();
        mageFemaleAnim = mageFemaleObj.GetComponent<Animator>();
        mageMaleAnim = mageMaleObj.GetComponent<Animator>();
        archerFemaleAnim = archerFemaleObj.GetComponent<Animator>();
        archerMaleAnim = archerMaleObj.GetComponent<Animator>();
        warriorFemaleAnim.runtimeAnimatorController = Instantiate(warriorAnimatorController);
        warriorMaleAnim.runtimeAnimatorController = Instantiate(warriorAnimatorController);
        mageFemaleAnim.runtimeAnimatorController = Instantiate(mageAnimatorController);
        mageMaleAnim.runtimeAnimatorController = Instantiate(mageAnimatorController);
        archerFemaleAnim.runtimeAnimatorController = Instantiate(archerAnimatorController);
        archerMaleAnim.runtimeAnimatorController = Instantiate(archerAnimatorController);

        //生成人物预制体
        goWarriorFemale = Instantiate(warriorFemaleObj, bornPointFemale.transform.position, Quaternion.identity);
        goWarriorMale = Instantiate(warriorMaleObj, bornPointMale.transform.position, Quaternion.identity);
        goMageFemale = Instantiate(mageFemaleObj, bornPointFemale.transform.position, Quaternion.identity);
        goMageMale = Instantiate(mageMaleObj, bornPointMale.transform.position, Quaternion.identity);
        goArcherFemale = Instantiate(archerFemaleObj, bornPointFemale.transform.position, Quaternion.identity);
        goArcherMale = Instantiate(archerMaleObj, bornPointMale.transform.position, Quaternion.identity);
        warriorTXT.SetActive(true);
        goMageFemale.SetActive(false);
        goMageMale.SetActive(false);
        goArcherFemale.SetActive(false);
        goArcherMale.SetActive(false);
        mageTXT.SetActive(false);
        archerTXT.SetActive(false);
        profession = ProfessionType.战士.ToString();
        isman = true;

        //点击返回键
        returnBtn.onClick.AddListener(() => { SceneManager.LoadSceneAsync(ConstDates.SelectPlayerSceneIndex); });

        //点击创建人物
        createPersonBtn.onClick.AddListener(create);

        //战士按钮
        warriorBtn.onClick.AddListener(() =>
        {
            warriorTXT.SetActive(true);
            goWarriorFemale.SetActive(true);
            goWarriorMale.SetActive(true);
            goMageFemale.SetActive(false);
            goMageMale.SetActive(false);
            goArcherFemale.SetActive(false);
            goArcherMale.SetActive(false);
            mageTXT.SetActive(false);
            archerTXT.SetActive(false);
            profession = ProfessionType.战士.ToString();
        });

        //法师按钮
        mageBtn.onClick.AddListener(() => {
            mageTXT.SetActive(true);
            goWarriorFemale.SetActive(false);
            goWarriorMale.SetActive(false);
            goMageFemale.SetActive(true);
            goMageMale.SetActive(true);
            goArcherFemale.SetActive(false);
            goArcherMale.SetActive(false);
            warriorTXT.SetActive(false);
            archerTXT.SetActive(false);
            profession = ProfessionType.法师.ToString();
        });

        //弓箭手按钮
        archerBtn.onClick.AddListener(() => {
            archerTXT.SetActive(true);
            goWarriorFemale.SetActive(false);
            goWarriorMale.SetActive(false);
            goMageFemale.SetActive(false);
            goMageMale.SetActive(false);
            goArcherFemale.SetActive(true);
            goArcherMale.SetActive(true);
            warriorTXT.SetActive(false);
            mageTXT.SetActive(false);
            profession = ProfessionType.弓箭手.ToString();
        });

        //男按钮
        maleBtn.onClick.AddListener(() => {
            femaleBtn.interactable = false;
            if (goWarriorMale.activeSelf == true)
            {
                goWarriorMale.transform.LookAt(showPoint.transform.position);
                warriorMaleAnim.SetBool("Walk", true);
                goWarriorMale.transform.DOMove(showPoint.transform.position, 2).OnComplete(() => {
                    goWarriorMale.transform.LookAt(new Vector3(
                         Camera.main.transform.position.x,
                         Camera.main.transform.position.y - 2,
                         Camera.main.transform.position.z
                        ));
                    femaleBtn.interactable = true;
                    warriorMaleAnim.SetBool("Walk", false);
                    warriorMaleAnim.SetTrigger("Skill1");
                });
            }
            else if (goMageMale.activeSelf == true)
            {
                goMageMale.transform.LookAt(showPoint.transform.position);
                mageMaleAnim.SetBool("Walk", true);
                goMageMale.transform.DOMove(showPoint.transform.position, 2).OnComplete(() => {
                    goMageMale.transform.LookAt(new Vector3(
                         Camera.main.transform.position.x,
                         Camera.main.transform.position.y - 2,
                         Camera.main.transform.position.z
                        ));
                    femaleBtn.interactable = true;
                    mageMaleAnim.SetTrigger("Skill1");
                });
            }
            else if (goArcherMale.activeSelf == true)
            {
                goArcherMale.transform.LookAt(showPoint.transform.position);
                archerMaleAnim.SetBool("Walk", true);
                goArcherMale.transform.DOMove(showPoint.transform.position, 2).OnComplete(() => {
                    goArcherMale.transform.LookAt(new Vector3(
                         Camera.main.transform.position.x,
                         Camera.main.transform.position.y - 2,
                         Camera.main.transform.position.z
                        ));
                    femaleBtn.interactable = true;
                    archerMaleAnim.SetTrigger("Skill3");
                });
            }

            if (Vector3.Distance(goWarriorFemale.transform.position, showPoint.transform.position) <= 0.01f)
            {
                goWarriorFemale.transform.LookAt(bornPointFemale.transform.position);
                warriorFemaleAnim.SetBool("Walk", true);
                goWarriorFemale.transform.DOMove(bornPointFemale.transform.position, 2).OnComplete(() => {
                    goWarriorFemale.transform.LookAt(new Vector3(
                         Camera.main.transform.position.x - 2,
                         Camera.main.transform.position.y - 2,
                         Camera.main.transform.position.z
                        ));
                    warriorFemaleAnim.SetBool("Walk", false);
                });
            }
            else if(Vector3.Distance(goMageFemale.transform.position, showPoint.transform.position) <= 0.01f)
            {
                goMageFemale.transform.LookAt(bornPointFemale.transform.position);
                mageFemaleAnim.SetBool("Walk", true);
                goMageFemale.transform.DOMove(bornPointFemale.transform.position, 2).OnComplete(() => {
                    goMageFemale.transform.LookAt(new Vector3(
                         Camera.main.transform.position.x - 2,
                         Camera.main.transform.position.y - 2,
                         Camera.main.transform.position.z
                        ));
                    mageFemaleAnim.SetBool("Walk", false);
                });
            }
            else if (Vector3.Distance(goArcherFemale.transform.position, showPoint.transform.position) <= 0.01f)
            {
                goArcherFemale.transform.LookAt(bornPointFemale.transform.position);
                archerFemaleAnim.SetBool("Walk", true);
                goArcherFemale.transform.DOMove(bornPointFemale.transform.position, 2).OnComplete(() => {
                    goArcherFemale.transform.LookAt(new Vector3(
                         Camera.main.transform.position.x - 2,
                         Camera.main.transform.position.y - 2,
                         Camera.main.transform.position.z
                        ));
                    archerFemaleAnim.SetBool("Walk", false);
                });
            }
            isman = true;
        });

        //女按钮
        femaleBtn.onClick.AddListener(() => {
            maleBtn.interactable = false;
            if (goWarriorFemale.activeSelf == true)
            {
                goWarriorFemale.transform.LookAt(showPoint.transform.position);
                goWarriorFemale.transform.DOMove(showPoint.transform.position, 2).OnComplete(() => {
                    goWarriorFemale.transform.LookAt(new Vector3(
                         Camera.main.transform.position.x,
                         Camera.main.transform.position.y - 2,
                         Camera.main.transform.position.z
                        ));
                    maleBtn.interactable = true;
                    warriorFemaleAnim.SetTrigger("Skill1");
                });
            }
            else if (goMageFemale.activeSelf == true)
            {
                goMageFemale.transform.LookAt(showPoint.transform.position);
                goMageFemale.transform.DOMove(showPoint.transform.position, 2).OnComplete(() => {
                    goMageFemale.transform.LookAt(new Vector3(
                         Camera.main.transform.position.x,
                         Camera.main.transform.position.y - 2,
                         Camera.main.transform.position.z
                        ));
                    maleBtn.interactable = true;
                    mageFemaleAnim.SetTrigger("Skill1");
                });
            }
            else if (goArcherFemale.activeSelf == true)
            {
                goArcherFemale.transform.LookAt(showPoint.transform.position);
                goArcherFemale.transform.DOMove(showPoint.transform.position, 2).OnComplete(() => {
                    goArcherFemale.transform.LookAt(new Vector3(
                         Camera.main.transform.position.x,
                         Camera.main.transform.position.y - 2,
                         Camera.main.transform.position.z
                        ));
                    maleBtn.interactable = true;
                    archerFemaleAnim.SetTrigger("Skill3");
                });
            }

            if (Vector3.Distance(goWarriorMale.transform.position, showPoint.transform.position) <= 0.01f)
            {
                goWarriorMale.transform.LookAt(bornPointMale.transform.position);
                goWarriorMale.transform.DOMove(bornPointMale.transform.position, 2).OnComplete(() => {
                    goWarriorMale.transform.LookAt(new Vector3(
                         Camera.main.transform.position.x + 2,
                         Camera.main.transform.position.y - 2,
                         Camera.main.transform.position.z
                        ));
                });
            }
            else if (Vector3.Distance(goMageMale.transform.position, showPoint.transform.position) <= 0.01f)
            {
                goMageMale.transform.LookAt(bornPointMale.transform.position);
                goMageMale.transform.DOMove(bornPointMale.transform.position, 2).OnComplete(() => {
                    goMageMale.transform.LookAt(new Vector3(
                         Camera.main.transform.position.x + 2,
                         Camera.main.transform.position.y - 2,
                         Camera.main.transform.position.z
                        ));
                });
            }
            else if (Vector3.Distance(goArcherMale.transform.position, showPoint.transform.position) <= 0.01f)
            {
                goArcherMale.transform.LookAt(bornPointMale.transform.position);
                goArcherMale.transform.DOMove(bornPointMale.transform.position, 2).OnComplete(() => {
                    goArcherMale.transform.LookAt(new Vector3(
                         Camera.main.transform.position.x + 2,
                         Camera.main.transform.position.y - 2,
                         Camera.main.transform.position.z
                        ));
                });
            }
            isman = false;
        });

        //人物名称文本框
        //createNameField.onValueChanged.AddListener();
    }
    int index = -1;
    Role role;
    public List<Role> rolelist = null;
    Regex reg = new Regex(@"^.{4,10}$");
    private void create()
    {
        if (nametxt.text != "" && reg.IsMatch(nametxt.text))
        {
                PlayerSelect._instance.ShowRole(role);
        }
        else
        {
            MessageManager._instance.ShowMessage("名字长度4-10位");
        }
    }
}
