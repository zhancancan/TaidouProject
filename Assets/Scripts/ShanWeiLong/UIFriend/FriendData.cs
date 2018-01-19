using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendData {

    public struct FriendKeyInfo
    {
        public string id;
        public string name;
        public string level;
        public string profession;
    }

    public struct FriendInfo
    {
        public string friendId;
        public FriendKeyInfo info;
    }

    private static FriendData _instance;

    public static FriendData GetInstance()
    {
        if (_instance == null)
        {
            _instance = new FriendData();
        }
        return _instance;
    }

    Dictionary<string, FriendKeyInfo> dic = new Dictionary<string, FriendKeyInfo>();
    List<FriendInfo> friendList = new List<FriendInfo>();

    public void ReadCSV()
    {
        TextAsset friendText = Resources.Load<TextAsset>("ShanWeiLong/Friend");
        string str = friendText.text;
        string str1 = str.Replace("\r\n", "\n");
        string[] strArray = str1.Split('\n');
        for (int i = 1; i < strArray.Length-1; i++)
        {
            FriendKeyInfo info = new FriendKeyInfo();
            string[] proArray = strArray[i].Split(',');
            info.id = proArray[0];
            info.name = proArray[1];
            info.level = proArray[2];
            info.profession = proArray[3];
            dic.Add(info.id, info);
        }
    }

    FriendKeyInfo GetFriendKey(string id)
    {
        return dic[id];
    }

    public void AddToFriend(string friendId)
    {
        FriendInfo info = new FriendInfo();
        info.friendId = friendId;
        info.info = GetFriendKey(friendId);
        friendList.Add(info);
    }

    public List<FriendInfo> GetFriend()
    {
        return friendList;
    }
}
