using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChapterInfo : MonoBehaviour
{
   
    public int Chapterid;    //챕터 테이블 ID값
    public string ChapterName;  //챕터 종류 이름값
 
    public Button m_ChapterBtn;
   

    public ChapterInfo() { }
    public ChapterInfo(int chapterid, string chapterName, string chpater_Map)
    {
        Chapterid = chapterid;
        ChapterName = chapterName;
        
    }

    private void Start()
    {
       

        if(m_ChapterBtn != null)
        {
            m_ChapterBtn.onClick.AddListener(() =>
            {

            });//  m_ChapterBtn.onClick.AddListener(() =>
        }//if(ChapterBtn != null)
    }

    


    //인게임에서 사용(진행중인 월드가 없으면 리셋)
    //진행중이라면 저장해야 하는 데이터
    //해당 챕터의 스테이지 구성 리스트(약 10개 예상)
    public List<StageInfo> Chapter_StageList = new List<StageInfo>();

    //해당 챕터를 구성할수 있는 스테이지 리스트
    //이 값을 이용해서 구성리스트 랜덤으로 작성
    public List<PercentInfo> Chapter_MapList = new List<PercentInfo>();



    //챕터의 소환될 몬스터 구성 리스트
    public List<PercentInfo> Chapter_MonsterList = new List<PercentInfo>();
    //챕터의 소환된 오브젝트 구성 리스트
    public List<PercentInfo> Chapter_ObjectList = new List<PercentInfo>();
    //최대 오브젝트 갯수
    public int maxObjAmount;
    //각 스테이지 난이도 조절용 int리스트
    //챕터 스테이지 리스트와 길이가 같다.
    public List<int> diffcultyMode = new List<int>();
    //완료 되었는가?
    public bool IsClear = false;

    
}
