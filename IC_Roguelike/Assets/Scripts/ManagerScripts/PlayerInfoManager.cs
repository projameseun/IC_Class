using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlayerInfoManager : MonoBehaviour
{
    public PlayerCtrl Player = null;
    //추후 개발 예정 2020 05 25 
    
    private void Update()
    {
        //------------------- 마우스 이동 코드
        //if (Input.GetMouseButtonDown(0)) //마우스 왼쪽 버튼 클릭시... (모바일에서 작동함)
        //{
        //    if (IsPointerOverUIObject() == false)
        //    {
        //        Player.MsPicking(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //    }//if (IsPointerOverUIObject() == false)
        //}//if (Input.GetMouseButton(0))
        // //------------------- 마우스 이동 코드



    }

//    PointerEventData a_EDCurPos; // using UnityEngine.EventSystems;
//    public bool IsPointerOverUIObject() //UGUI의 UI들이 먼저 피킹되는지 확인하는 함수
//    {
//        a_EDCurPos = new PointerEventData(EventSystem.current);

//#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_ANDROID)

//   //if (Input.touchCount > 1)
//   //     return true;

//   List<RaycastResult> results = new List<RaycastResult>();
//   for (int i = 0; i < Input.touchCount; ++i)
//   {
//    a_EDCurPos.position = Input.GetTouch(i).position;  //new Vector2(Input.mousePosition.x, Input.mousePosition.y);
//    results.Clear();
//    EventSystem.current.RaycastAll(a_EDCurPos, results);
//    if (0 < results.Count)
//     return true;
//   }

//   return false;
//#else
//        a_EDCurPos.position = Input.mousePosition;
//        List<RaycastResult> results = new List<RaycastResult>();
//        EventSystem.current.RaycastAll(a_EDCurPos, results);
//        return results.Count > 0;
//#endif
//    }







}
