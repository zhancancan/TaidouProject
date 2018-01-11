using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISkillItem : MonoBehaviour {

    public PosType posType;
    Skill skill;

    Image im;
    Image Im
    {
        get
        {
            if (im == null)
            {
                im = this.GetComponent<Image>();
            }
            return im;
        }
    }

    private void Start()
    {
        SkillShow();
    }

    void SkillShow()
    {
        skill = SkillManager._instance.GetSkillByPosition(posType);
        Im.sprite = skill.Icon;
    }

}
