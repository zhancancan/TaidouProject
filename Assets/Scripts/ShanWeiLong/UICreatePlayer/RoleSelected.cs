using System.Collections;
using System.Collections.Generic;
using TaidouCommon.Model;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class RoleSelected : MonoBehaviour {
    [HideInInspector]
    public Text PersonName;
    [HideInInspector]
    public Text profession;
    [HideInInspector]
    public Image seximg;
    [HideInInspector]
    public Text level;
    public GameObject[] go;
    GameObject born;
    Button show;

    private AnimatorController warriorAnimatorController;
    private AnimatorController mageAnimatorController;
    private AnimatorController archerAnimatorController;
    private void Awake()
    {
        PersonName = transform.Find("PersonName").GetComponent<Text>();
        profession = transform.Find("PersonPosition").GetComponent<Text>();
        level = transform.Find("PersonLevel").GetComponent<Text>();
        seximg = transform.Find("PersonHead").GetComponent<Image>();
        born = GameObject.Find("born").gameObject;
        show = GetComponent<Button>();
        show.onClick.AddListener(UpdateShow);

        warriorAnimatorController
            = Resources.Load<AnimatorController>(ConstDates.ResourceAnimatorPrefabDirSwl + ConstDates.WarriorAnimator);
        mageAnimatorController
            = Resources.Load<AnimatorController>(ConstDates.ResourceAnimatorPrefabDirSwl + ConstDates.MageAnimator);
        archerAnimatorController
            = Resources.Load<AnimatorController>(ConstDates.ResourceAnimatorPrefabDirSwl + ConstDates.ArcherAnimator);
    }
    void Start () {
        
    }
	
    GameObject showrole;
    Role role;

    void UpdateShow()
    { 
       PhotonEngine.Instance.role=role;
        if (GameObject.FindGameObjectWithTag("Role"))
        {
            showrole = GameObject.FindGameObjectWithTag("Role");
            Destroy(showrole);
        }
        if (profession.text.Contains("战士"))
        {
                if (seximg.sprite.name.Contains("女"))
                {
                    GameObject goFemale = Instantiate(go[4], born.transform.position, Quaternion.Euler(0, -168, 0));
                    Animator anim = goFemale.GetComponent<Animator>();
                    anim.runtimeAnimatorController = Instantiate(warriorAnimatorController);
                }
                else
                {
                    GameObject goMale = Instantiate(go[5], born.transform.position, Quaternion.Euler(0, -168, 0));
                    Animator anim = goMale.GetComponent<Animator>();
                    anim.runtimeAnimatorController = Instantiate(warriorAnimatorController);
                }
           
        }
        else if(profession.text.Contains("法师") )
        {
            if (seximg.sprite.name.Contains("女"))
            {
                GameObject goFemale = Instantiate(go[2], born.transform.position, Quaternion.Euler(0, -168, 0));
                Animator anim = goFemale.GetComponent<Animator>();
                anim.runtimeAnimatorController = Instantiate(mageAnimatorController);
            }
            else
            {
                GameObject goMale = Instantiate(go[3], born.transform.position, Quaternion.Euler(0, -168, 0));
                Animator anim = goMale.GetComponent<Animator>();
                anim.runtimeAnimatorController = Instantiate(mageAnimatorController);
            }
        }
        else if(profession.text.Contains("弓箭手") )
        {
            if (seximg.sprite.name.Contains("女"))
            {
                GameObject goFemale = Instantiate(go[0], born.transform.position, Quaternion.Euler(0, -168, 0));
                Animator anim = goFemale.GetComponent<Animator>();
                anim.runtimeAnimatorController = Instantiate(archerAnimatorController);
            }
            else
            {
                GameObject goMale = Instantiate(go[1], born.transform.position, Quaternion.Euler(0, -168, 0));
                Animator anim = goMale.GetComponent<Animator>();
                anim.runtimeAnimatorController = Instantiate(archerAnimatorController);
            }
        }
        else
        {
            return;
        }
        
    }
}
