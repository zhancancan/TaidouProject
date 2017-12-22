using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PetTopBG : MonoBehaviour
{

    private Slider hpSlider;          //血条
    private Text petHPNum;            //血量
    private Image star1;              //星1
    private Image star2;              //星2
    private Image star3;              //星3
    private Image star4;              //星4
    private Image star5;              //星5
    private Text starLevelNum;        //星星等级
    private RawImage headPic;        //头像
    private Text petName;             //宠物名
    private Text petAtkNum;           //宠物攻击力
    private Text petDefNum;           //宠物护甲
    private Text petCombatNum;        //宠物战斗力
    private Text petSkillDescription; //宠物技能描述
    private Text petEnergyNum;        //宠物活力
    private Text petRecoverNum;       //宠物活力恢复时间
    private Text petAllNum;           //宠物活力全部恢复时间

    void Awake()
    {
        hpSlider = transform.Find("HPslider").GetComponent<Slider>();
        star1= transform.Find("StarBG1/Star1").GetComponent<Image>();
        star2= transform.Find("StarBG2/Star2").GetComponent<Image>();
        star3= transform.Find("StarBG3/Star3").GetComponent<Image>();
        star4= transform.Find("StarBG4/Star4").GetComponent<Image>();
        star5 = transform.Find("StarBG5/Star5").GetComponent<Image>();
        starLevelNum = transform.Find("StarLevelNum").GetComponent<Text>();
        petHPNum = transform.Find("PetHPNum").GetComponent<Text>();
        headPic = transform.Find("HeadCircle/Head").GetComponent<RawImage>();
        petName = transform.Find("PetName").GetComponent<Text>(); 
        petAtkNum = transform.Find("PetAtkNum").GetComponent<Text>();
        petDefNum = transform.Find("PetDefNum").GetComponent<Text>();
        petCombatNum = transform.Find("PetCombatNum").GetComponent<Text>();
        petSkillDescription = transform.Find("PetSkillDescription").GetComponent<Text>();
        petEnergyNum = transform.Find("PetEnergyNum").GetComponent<Text>();
        petRecoverNum = transform.Find("PetRecoverNum").GetComponent<Text>();
        petAllNum = transform.Find("PetAllNum").GetComponent<Text>();
    }
}
