using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDir : MonoBehaviour
{
    private PlayerMove move;

    private RaycastHit hitInfo;
    public Vector3 targetPositon = Vector3.zero;
    private bool isMouseClick;

    void Start ()
    {
        targetPositon = transform.position;
        move = GetComponent<PlayerMove>();
	}
	
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            hitInfo = new RaycastHit();
            if (Physics.Raycast(ray, out hitInfo) && hitInfo.collider.tag == Tags.Ground)
            {
                ShowClickEffect(hitInfo.point);
                isMouseClick = true;
            }
        }

	    if (Input.GetMouseButtonUp(0))
	    {
            isMouseClick = false;
	    }
        
        if (isMouseClick)
	    {
            if (hitInfo.collider.tag == Tags.Ground)
            {
                LookAtTarget(hitInfo.point);
            }
	    }
        else
        {
            if (move.isMoving)
            {
                LookAtTarget(targetPositon);
            }
        }
    }

    //创建鼠标点击地面时的效果
    void ShowClickEffect(Vector3 hitPoint)
    {
        hitPoint = new Vector3(hitPoint.x, hitPoint.y + 0.1f, hitPoint.z);
        GameObject obj = PrefabManager.Instance.GetUIPrefabInstance(ConstDates.Effect_MouseClick_Green);
        obj.transform.position = hitPoint;
        obj.transform.rotation = Quaternion.identity;
    }

   //修改人物朝向
    void LookAtTarget(Vector3 hitPoint)
    {
        targetPositon = new Vector3(hitPoint.x,transform.position.y, hitPoint.z);
        this.transform.LookAt(targetPositon);
    }
}
