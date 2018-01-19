using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendView : MonoBehaviour {

    public void Refresh(List<FriendData.FriendInfo> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            GameObject go = Instantiate(Resources.Load<GameObject>(ConstDates.ResourcePrefabDirSwl + "/Friend"));
            go.transform.SetParent(transform);
            go.GetComponent<FriendKeyView>().Refresh(list[i]);
        }
    }

}
