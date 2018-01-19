using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendController : MonoBehaviour
{
    private Button close;
    private Button addBtn;
    private Button removeBtn;
    private Button teamBtn;
    private Button lookBtn;
    private Button transation;
    private Button callBtn;
    private Button addYes;
    private Button addNo;
    private Button delYes;
    private Button delNo;
    private Button lookClose;
    private InputField addInputField;

    private GameObject addFriend;
    private GameObject deleteFriend;
    private GameObject lookFriend;

    void Awake ()
    {
        addFriend = transform.Find("AddFriend").gameObject;
        deleteFriend = transform.Find("DeleteFriend").gameObject;
        lookFriend = transform.Find("LookFriend").gameObject;
        addInputField = addFriend.transform.Find("AddInputField").GetComponent<InputField>();
        addYes = addFriend.transform.Find("Yes").GetComponent<Button>();
        addNo = addFriend.transform.Find("No").GetComponent<Button>();
        delYes = deleteFriend.transform.Find("Yes").GetComponent<Button>();
        delNo = deleteFriend.transform.Find("No").GetComponent<Button>();
        lookClose = lookFriend.transform.Find("Close").GetComponent<Button>();

        close = transform.Find("FriendBg/Close").GetComponent<Button>();
        addBtn = transform.Find("FriendBg/AddFriendBtn").GetComponent<Button>();
        removeBtn = transform.Find("FriendBg/RemoveFriendBtn").GetComponent<Button>();
        teamBtn = transform.Find("FriendBg/TeamBtn").GetComponent<Button>();
        lookBtn = transform.Find("FriendBg/LookFriendBtn").GetComponent<Button>();
        transation = transform.Find("FriendBg/TransationFriendBtn").GetComponent<Button>();
        callBtn = transform.Find("FriendBg/CallFriendBtn").GetComponent<Button>();
    }

    private void Start()
    {
        close.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
        });

        addBtn.onClick.AddListener(() =>
        {
            addFriend.SetActive(true);
        });

        removeBtn.onClick.AddListener(() =>
        {
            deleteFriend.SetActive(true);
        });

        lookBtn.onClick.AddListener(() =>
        {
            lookFriend.SetActive(true);
        });

        addNo.onClick.AddListener(() =>
        {
            addFriend.SetActive(false);
        });

        delNo.onClick.AddListener(() =>
        {
            deleteFriend.SetActive(false);
        });

        lookClose.onClick.AddListener(() =>
        {
            lookFriend.SetActive(false);
        });
    }

}
