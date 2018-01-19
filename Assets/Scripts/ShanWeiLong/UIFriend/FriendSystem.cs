using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSystem : MonoBehaviour
{

    public FriendView fv;

    private FriendData fd;

	void Start ()
	{
	    fd = FriendData.GetInstance();

	    fd.ReadCSV();

        fd.AddToFriend("1001");
        fd.AddToFriend("1002");
        fd.AddToFriend("1003");
        fd.AddToFriend("1004");
        fd.AddToFriend("1005");
        fd.AddToFriend("1006");
        fd.AddToFriend("1007");

	    UpdateView();
	}
	
	void UpdateView ()
	{
	    List<FriendData.FriendInfo> list = new List<FriendData.FriendInfo>();
	    list = fd.GetFriend();
	    fv.Refresh(list);
	}
}
