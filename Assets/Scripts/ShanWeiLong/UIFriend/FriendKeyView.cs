using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendKeyView : MonoBehaviour
{

    public Text name;
    public Text level;
    public Text profession;

    public void Refresh(FriendData.FriendInfo info)
    {
        FriendData.FriendKeyInfo keyInfo = info.info;
        name.text = keyInfo.name;
        level.text = keyInfo.level;
        profession.text = keyInfo.profession;
    }

}
