using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class LoaderManager : MonoBehaviour
{
    //내부 delegate클래스
    private delegate void AccountLoad();

    private AccountLoad myLoader;
    //모든 게임데이터 로드
    public void GameDataLoad()
    {
        myLoader += JsonDiffcultyWeightLoad;
    }
   
  
   private void JsonDiffcultyWeightLoad()
    {
        
    }

    private void Start()
    {
        GameDataLoad();

        myLoader();
    }

    //추가 구현사항
    //delegate 변수에 Load함수 등록할것
    //시작과 동시에 등록
    //프리셋들이 추가될때마다 함수도 추가

}
