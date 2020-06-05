﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WorldInfo : MonoBehaviour
{

    public int Worldid;     //월드 id값
    public string WorldName;    //월드종류 이름값
    public string Wolrd_RandomChapter;


    //추가
    public Button m_WorldBtn;   //월드버튼
   

    public WorldInfo() { }

    public WorldInfo(int worldid, string worldName, List<PercentInfo> world_RandomChapterList)
    {
        Worldid = worldid;
        WorldName = worldName;
        World_RandomChapterList = world_RandomChapterList;
    }
    

    //인게임에서 사용(진행중인 월드가 없으면 리셋)
    //진행중이라면 저장해야하는 데이터
    //해당월드의 챕터 구성리스트(화염챕터1 화염챕터)
    public List<ChapterInfo> World_ChapterList = new List<ChapterInfo>();

    //해당월드를 구성할수 있는 챕터리스트
    public List<PercentInfo> World_RandomChapterList = new List<PercentInfo>();

    //마지막 챕터의 id
    public int EndChater;
    //월드 진행도
    public float WorldProgress;

    public bool isChapter;

    private void Start()
    {
        //World_ChapterListLoad();
        #region WorldClick
        if (m_WorldBtn != null)
        {
            m_WorldBtn.onClick.AddListener(() =>
            {
               
                Debug.Log("WorldClick");
                //1.랜덤으로 World_RandomChpaterList를 돌린다 
                //2.퍼센트에 따라서 조건이 나올확률이다.
                if (isChapter == false)
                {
                    for (int i = 0; i < World_RandomChapterList.Count; i++)
                    {
                        int ChapterId = PercentInfo.RandomSelcet(World_RandomChapterList);

                        for (int j = 0; j < World_RandomChapterList.Count; j++)
                        {
                            if (ChapterId == GameManager.instance.ChaptManager.ChapterList[j].Chapterid)
                            {
                                World_ChapterList.Add(GameManager.instance.ChaptManager.ChapterList[j]);
                                break;
                            }
                        }//for (int j = 0; j < World_RandomChapterList.Count; j++)
                    }//for (int i = 0; i < World_RandomChapterList.Count; i++)
                     //RandomSelcet();

                    //로그찍는곳 제대로 챕터리스트 들어갔는지 확인 나중에 지울 예정
                    //for (int i = 0; i < 5; i++)
                    //{
                    //    Debug.Log("확률적으로 나온배열:" + World_ChapterList[i].ChapterName);
                    //}
                }
                World_ChapterListSave();
                //다섯개가 성성되고 챕터패널이 활성화되는곳
                GameManager.instance.ChaptManager.SettingWorld_Chpater(World_ChapterList);
                
            });// m_WorldBtn.onClick.AddListener(() =>
        }// if (m_WorldBtn != null)
        #endregion WorldClick


    }//private void Start()

    void World_ChapterListLoad()
    {
        if(PlayerPrefs.HasKey("Name"))
        {
            Debug.Log("로드중입니다");
            for (int i = 0; i < World_ChapterList.Count; i++)
            {
                World_ChapterList[i].Chapterid = PlayerPrefs.GetInt("ID");
                World_ChapterList[i].ChapterName = PlayerPrefs.GetString("Name");
                
                Debug.Log(World_ChapterList[i].ChapterName);
            }

            isChapter = true;
        }
    }

    void World_ChapterListSave()
    {
        for (int i = 0; i < World_ChapterList.Count; i++)
        {
           
            PlayerPrefs.SetString("Name", World_ChapterList[i].ChapterName);
            PlayerPrefs.SetInt("ID", World_ChapterList[i].Chapterid);
            Debug.Log(World_ChapterList[i].ChapterName);
            
        }

        PlayerPrefs.Save();
    }


}
