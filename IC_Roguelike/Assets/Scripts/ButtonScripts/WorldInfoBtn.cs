using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldInfoBtn : MonoBehaviour
{
    public Button m_WorldBtn;
    public WorldInfo m_WorldInfo = new WorldInfo();
    private void Start()
    {
       
        #region WorldClick
        if (m_WorldBtn != null)
        {

            
            m_WorldBtn.onClick.AddListener(() =>
            {
                GameManager.instance.WdManager.NowPlayWorld = m_WorldInfo;
                Debug.Log("WorldClick");
                //GameManager.instance.WdManager.NowPlayWorld = this.GetComponent<WorldInfo>();
                //1.랜덤으로 World_RandomChpaterList를 돌린다 
                //2.퍼센트에 따라서 조건이 나올확률이다.
                if (GameManager.instance.WdManager.NowPlayWorld.isChapter == false) //챕터가 만약에 저장된게없다면 들어오게됨
                {
                
                    RandomSetting();
                    if (GameManager.instance.WdManager.NowPlayWorld.isWorldClear == false)
                        GameManager.instance.WdManager.SelectedWorldID = m_WorldInfo.Worldid;
                    //if (GameManager.instance.WdManager.SelectedWorldID > m_WorldInfo.Worldid)
                    //{
                    //    if (GameManager.instance.WdManager.NowPlayWorld.isWorldClear == false) 
                    //    GameManager.instance.WdManager.SelectedWorldID = m_WorldInfo.Worldid;
                    //}
                    //else
                    //{
                    //    if (GameManager.instance.WdManager.NowPlayWorld.isWorldClear == false)
                    //        GameManager.instance.WdManager.SelectedWorldID = m_WorldInfo.Worldid;
                    //}

                    GameManager.instance.WdManager.NowPlayWorld.isChapter = true;
                    

                }//     if (GameManager.instance.WdManager.NowPlayWorld.isChapter == false)
               else
                {
                    if(GameManager.instance.WdManager.NowPlayWorld.ExitChapter != true)
                    RandomSetting();

                  
                }
               

                //처음세팅할때만 저장할때 키는곳

                GameManager.instance.SaveManager.PlayerPrefs_WorldChapterListSave();

                //다섯개가 성성되고 챕터패널이 활성화되는곳
                LobbyUIManager a_UIMager = FindObjectOfType<LobbyUIManager>();
                a_UIMager.SettingWorld_ChpaterList();
            });// m_WorldBtn.onClick.AddListener(() =>
        }// if (m_WorldBtn != null)
        #endregion WorldClick
    }

    
    public void TestWorld()
    {
              
                //일단은테스트
             GameManager.instance.LobbyUIManger.SettingWorld_WorldList();
            
                Debug.Log("test");
            //GameManager.instance.WdManager.SelectedWorldID

        
    }

    public void RandomSetting()
    {
            
            int ChapterId = PercentInfo.RandomSelcet(GameManager.instance.WdManager.NowPlayWorld.World_RandomChapterList);  //랜덤챕터리스트
        //Debug.Log(ChapterId);
            for (int j = 0; j < GameManager.instance.ChaptManager.ChapterList.Count; j++)
            {
                if (ChapterId == GameManager.instance.ChaptManager.ChapterList[j].Chapterid)    //랜덤챕터리스트 와 챕터리스트 아이디 비교
                {
                GameManager.instance.WdManager.NowPlayWorld.World_ChapterList.Add(GameManager.instance.ChaptManager.ChapterList[j]);
                    break;
                }
            }//for (int j = 0; j < World_RandomChapterList.Count; j++)
        

        
    }
}
