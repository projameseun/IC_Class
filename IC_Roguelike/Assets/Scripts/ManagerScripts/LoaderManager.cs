﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


[System.Serializable]//이거 반드시 쓸것
public class Serialization<T>
{
    public Serialization(List<T> _target) => Sheet1 = _target;

    public List<T> Sheet1;
}

public class LoaderManager : MonoBehaviour
{
    //내부 delegate클래스
    private delegate void AccountLoad();
    string FilePath;
    private AccountLoad myLoader;
    //모든 게임데이터 로드
  
    public void GameDataLoad()
    {
        
        myLoader += JsonWorldInfoLoad;
        myLoader += JsonDiffcultyWeightLoad;
        myLoader += JsonChapterInfoLoad;
        myLoader += JsonStageInfoLoad;
        myLoader += PlayerPrefs_ChapterListLoad;


    }
    private void JsonDiffcultyWeightLoad()  //챕터의난이도
    {
        //Debug.Log("TestDelegate");
        FilePath = Application.dataPath + "/StreamingAssets/DataTable/DifficultyWeight.json";
        string jdata = File.ReadAllText(FilePath);

        List<ChapterInfo> a_LoadChapList;
        a_LoadChapList = JsonUtility.FromJson<Serialization<ChapterInfo>>(jdata).Sheet1;
    }
    //월드로드
   private void JsonWorldInfoLoad()
    {
        ////테이블 명은 분리해주세요
        FilePath = Application.dataPath + "/StreamingAssets/DataTable/WorldInfo.json";
        string jdata = File.ReadAllText(FilePath);

        List<WorldInfo> a_WorldList;
        a_WorldList = JsonUtility.FromJson<Serialization<WorldInfo>>(jdata).Sheet1;

        //여기서 데이터 처리
        for (int i = 0; i < a_WorldList.Count; i++)
        {
            string[] datas = a_WorldList[i].Wolrd_RandomChapter.Split(',');

            a_WorldList[i].World_RandomChapterList = new List<PercentInfo>();

            for (int j = 0; j < datas.Length; j++)
            {
                string[] Splits = datas[j].Split(':');
                PercentInfo InsertData = new PercentInfo();
                InsertData.ID = int.Parse(Splits[0]);
                //InsertData.Percent = float.Parse(Splits[1]);
                InsertData.Percent = int.Parse(Splits[1]);
                a_WorldList[i].World_RandomChapterList.Add(InsertData);
            }
        }
        //여기서 게임매니저의 인스턴스의 월드매니저의 SetWorldList(a_LoadItemList)호출
        GameManager.instance.WdManager.SetWorldList(a_WorldList);
    }// private void JsonWorldInfoLoad()
    
    //챕터로드
    private void JsonChapterInfoLoad()
    {
        FilePath = Application.dataPath + "/StreamingAssets/DataTable/ChapterInfo.json";
        string jdata = File.ReadAllText(FilePath);

        List<ChapterInfo> a_ChapterList;
        a_ChapterList = JsonUtility.FromJson<Serialization<ChapterInfo>>(jdata).Sheet1;

        //로드부분
         for(int i=0; i<a_ChapterList.Count; i++)
        {
            string[] datas = a_ChapterList[i].ChapterName.Split(',');
            a_ChapterList[i].Chapter_MapList = new List<PercentInfo>();
            for(int j=0; j<datas.Length; j++)
            {
                string[] Splits = datas[j].Split(':');
                PercentInfo InsertData = new PercentInfo();
                InsertData.ID = int.Parse(Splits[0]);
                InsertData.Percent = int.Parse(Splits[1]);
                a_ChapterList[i].Chapter_MapList.Add(InsertData);
            }// for(int j=0; j<datas.Length; j++)
        }//for(int i=0; i<a_ChapterList.Count; i++)

        GameManager.instance.ChaptManager.SetChapterList(a_ChapterList);
    }//   private void JsonChapterInfoLoad()

    //스테이지로드
    private void JsonStageInfoLoad()
    {
        FilePath = Application.dataPath + "/StreamingAssets/DataTable/StageInfo.json";
        string jdata = File.ReadAllText(FilePath);

        List<StageInfo> a_StageList;
        a_StageList = JsonUtility.FromJson<Serialization<StageInfo>>(jdata).Sheet1;

        //로드
        for(int i=0; i<a_StageList.Count;i++)
        {
            string[] datas = a_StageList[i].StageName.Split(',');
            for(int j=0; j<datas.Length; j++)
            {
                string[] Splits = datas[j].Split(':');
                a_StageList[i].Stageid = int.Parse(Splits[0]);
                a_StageList[i].expAmount = int.Parse(Splits[1]);
                a_StageList[i].currDiffculty = int.Parse(Splits[2]);
                //a_StageList[i].StageName = (Splits[3]);

            }//  for(int j=0; j<datas.Length; j++)
        }//for(int i=0; i<a_StageList.Count;i++)

        GameManager.instance.StManager.SetStageList(a_StageList);

    }// private void JsonStageInfoLoad()


    #region PlayerPrefsLoad
    public void PlayerPrefs_ChapterListLoad()
    {

        if (PlayerPrefs.HasKey("WorldID"))
        {
            Debug.Log("로드중입니다");

            GameManager.instance.WdManager.SelectedWorldID = PlayerPrefs.GetInt("WorldID");
  
            GameManager.instance.WdManager.NowPlayWorld.ChapterProgress = PlayerPrefs.GetInt("ChpaterProgress");
            if (PlayerPrefs.GetString("WorldSelect") == "true")
            {
                Debug.Log("해당월드가 존재합니다");
                GameManager.instance.WdManager.NowPlayWorld.isChapter = true;
            }
            else if(PlayerPrefs.GetString("WorldSelect") == "false")    //다시챕터초기화시작
            {
                Debug.Log("flase로 들어왔습니다");
                GameManager.instance.WdManager.NowPlayWorld.isChapter = false;
                return;
            }
            else
            {
                Debug.Log("해당월드 셀렉이 존재하지않습니다");
                return;
            }

            if (PlayerPrefs.GetString("ExitChapter") == "true")
            {
                Debug.Log("ExitTrue");
                GameManager.instance.WdManager.NowPlayWorld.ExitChapter = true;
            }
            else
            {
                Debug.Log("ExitFalse");
                GameManager.instance.WdManager.NowPlayWorld.ExitChapter = false;
            }
            if (PlayerPrefs.GetString("WorldClear") == "true")
            {
                GameManager.instance.WdManager.NowPlayWorld.isWorldClear = true;
            }
            else
                GameManager.instance.WdManager.NowPlayWorld.isWorldClear = false;

      
  

            if (PlayerPrefs.GetString("ChapterClear") == "true")
            {
                GameManager.instance.WdManager.NowPlayWorld.isChapterClear = true;
            }
            else
                GameManager.instance.WdManager.NowPlayWorld.isChapterClear = false;

            //PlayerHP
            PlayerCtrl.PlayerHp = PlayerPrefs.GetInt("PlayerHP");


            GameManager.instance.WdManager.NowPlayWorld.Worldid = PlayerPrefs.GetInt("WorldID");
            int Count = PlayerPrefs.GetInt("ChapterCount");
            for (int i = 0; i < Count; i++)
            {
                ChapterInfo newNode = new ChapterInfo();
                newNode.Chapterid = PlayerPrefs.GetInt("ChpaterID " + (i +1));
                newNode.ChapterName = PlayerPrefs.GetString("ChapterName " + (i + 1));
                
                GameManager.instance.WdManager.NowPlayWorld.World_ChapterList.Add(newNode);
               
                
            }
           
        int Count2 = PlayerPrefs.GetInt("ChapterRandomCount");

            for (int i = 0; i < Count2; i++)
            {
                PercentInfo newNode = new PercentInfo();
                newNode.ID = PlayerPrefs.GetInt("ChapterRandomName " + (i + 1));
                newNode.Percent = PlayerPrefs.GetFloat("ChpaterRandomPercent " + (i + 1));
                GameManager.instance.WdManager.NowPlayWorld.World_RandomChapterList.Add(newNode);
               

            }
            //일단은랜덥챕터리스트저장



        }//if (PlayerPrefs.HasKey("WorldID"))
    }// void PlayerPrefs_ChapterListLoad()
    #endregion PlayerPrefsLoad


    private void Start()
    {
        //GameDataLoad();
         PlayerPrefs_ChapterListLoad();
        //myLoader();
    }

    //추가 구현사항
    //delegate 변수에 Load함수 등록할것
    //시작과 동시에 등록
    //프리셋들이 추가될때마다 함수도 추가

}
