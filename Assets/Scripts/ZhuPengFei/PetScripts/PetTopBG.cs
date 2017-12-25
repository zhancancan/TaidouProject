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
    private RawImage petHead;          //头像
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
        hpSlider = transform.Find("HPSlider").GetComponent<Slider>();
        star1= transform.Find("StarBG1/Star1").GetComponent<Image>();
        star2= transform.Find("StarBG2/Star2").GetComponent<Image>();
        star3= transform.Find("StarBG3/Star3").GetComponent<Image>();
        star4= transform.Find("StarBG4/Star4").GetComponent<Image>();
        star5 = transform.Find("StarBG5/Star5").GetComponent<Image>();
        starLevelNum = transform.Find("StarLevelNum").GetComponent<Text>();
        petHPNum = transform.Find("PetHPNum").GetComponent<Text>();
        petHead = transform.Find("HeadCircle/PetHead").GetComponent<RawImage>();
        petName = transform.Find("PetName").GetComponent<Text>(); 
        petAtkNum = transform.Find("PetAtkNum").GetComponent<Text>();
        petDefNum = transform.Find("PetDefNum").GetComponent<Text>();
        petCombatNum = transform.Find("PetCombatNum").GetComponent<Text>();
        petSkillDescription = transform.Find("PetSkillDescription").GetComponent<Text>();
        petEnergyNum = transform.Find("PetEnergyNum").GetComponent<Text>();
        petRecoverNum = transform.Find("PetEnergyRecoverNum").GetComponent<Text>();
        petAllNum = transform.Find("PetAllEnergyNum").GetComponent<Text>();
        //注册事件
        PetInfo._petInstance.OnPetInfoChanged += this.OnPetInfoChanged;
    }

    void Update()
    {
        //更新宠物活力恢复计时器
        UpdateEnergyAndShow();
    }

    //注销事件，避免游戏物体销毁，仍有空方法在运行
    void OnDestroy()
    {
        PetInfo._petInstance.OnPetInfoChanged -= this.OnPetInfoChanged;
    }

    //当宠物信息发生更改时，会触发这个方法
    void OnPetInfoChanged(PetInfoType type)
    {
        if (type==PetInfoType.PetAtk||type==PetInfoType.PetCombat||type==PetInfoType.PetDef||
            type==PetInfoType.PetEnergy||type==PetInfoType.PetHead||type==PetInfoType.PetHP||
            type==PetInfoType.PetName||type==PetInfoType.PetSkill||type==PetInfoType.StarLevel||type==PetInfoType.All)
        {
            UpdateShowPetUI();
        }
    }

    //更新显示
    void UpdateShowPetUI()
    {
        PetInfo petInfo = PetInfo._petInstance;
        hpSlider.value = petInfo.PetHP / 100f;
        starLevelNum.text = petInfo.StarLevelNum.ToString();
        petHPNum.text = petInfo.PetHP+"/100";
        petName.text = petInfo.PetName.ToString();
        petHead.texture = TextureManager.Instance.GetTexture(ConstDates.ResourceTexturesDirZpf, ConstDates.Head_Elf);    //加载Resources中的头像图片
        petAtkNum.text = petInfo.PetAtk.ToString();
        petDefNum.text = petInfo.PetDef.ToString();
        petCombatNum.text = petInfo.PetCombat.ToString();
        petSkillDescription.text = petInfo.PetSkill.ToString();
        petEnergyNum.text = petInfo.PetEnergy.ToString()+"/100";

        


    }

    //更新活力时间
    void UpdateEnergyAndShow()
    {
        PetInfo petInfo = PetInfo._petInstance;
        petEnergyNum.text = petInfo.PetEnergy + "/100";
        //判断宠物活力值是否为满值，如果为满值则恢复时间和全部时间都为00:00:00
        if (petInfo.PetEnergy>=100)
        {
            petRecoverNum.text = "00:00:00";
            petAllNum.text = "00:00:00";
        }
        //不为满值
        else
        {
            //恢复为60秒恢复一格，则倒计时为60-增长体力计时器的秒数
            int petShowTime = 60 - (int)petInfo.petEnergyTimer;
            string str = petShowTime <= 9 ? "0" + petShowTime:petShowTime.ToString();
            petRecoverNum.text = "00:00:" + str;


            //满值=恢复时间+全部时间     恢复时间总值为1分钟，则全部时间总值为99分钟
            int PetAllTimeMinutes = 99 - petInfo.PetEnergy;
            int PetAllTimeHours = PetAllTimeMinutes / 60;
            PetAllTimeMinutes = PetAllTimeMinutes % 60;
            string petHourStr = PetAllTimeHours <= 9 ? "0" + PetAllTimeHours : PetAllTimeHours.ToString();
            string petMinutesStr = PetAllTimeMinutes <= 9 ? "0" + PetAllTimeMinutes : PetAllTimeMinutes.ToString();
            petAllNum.text = petHourStr + ":" + petMinutesStr+":"+str;
        }
    }
}
