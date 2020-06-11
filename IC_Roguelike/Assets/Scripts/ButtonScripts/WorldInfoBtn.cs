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

                Debug.Log("WorldClick");
                //GameManager.instance.WdManager.NowPlayWorld = this.GetComponent<WorldInfo>();
                //1.랜덤으로 World_RandomChpaterList를 돌린다 
                //2.퍼센트에 따라서 조건이 나올확률이다.
                // if (GameManager.instance.WdManager.NowPlayWorld.isChapter == false)
                //처음에만설정할때 테스트나중에 바꿀예정
                //if (GameManager.instance.WdManager.NowPlayWorld.isChapter == false)
                //{
                //    Debug.Log("챕터가 false 입니다");
                //    RandomSetting();

                //    GameManager.instance.WdManager.NowPlayWorld = m_WorldInfo;
                //    GameManager.instance.WdManager.SelectedWorldID = m_WorldInfo.Worldid;
                //    GameManager.instance.WdManager.NowPlayWorld.isChapter = true;

                //    GameManager.instance.WdManager.WorldList.Add(m_WorldInfo);
                //}
                //처음에만설정할때 테스트나중에 바꿀예정
                for (int i = 0; i < GameManager.instance.WdManager.WorldList.Count; i++)//챕터가 만약에 저장된게없다면 들어오게됨
                {
                    if (GameManager.instance.WdManager.WorldList[i].isChapter == false)
                    {
                        Debug.Log("챕터가 false 입니다");
                        RandomSetting();

                        GameManager.instance.WdManager.NowPlayWorld = m_WorldInfo;
                        GameManager.instance.WdManager.SelectedWorldID = m_WorldInfo.Worldid;
                        GameManager.instance.WdManager.NowPlayWorld.isChapter = true;

                        GameManager.instance.WdManager.WorldList.Add(m_WorldInfo);
                        break;
                        //이부분은 나중에 종민님이 넘겨준 json파일로할건데 지금은 PlayerPrefabs로
                        //처음 저장할대 제대로 로그찍히는지 보는곳
                        // 로그찍는곳 제대로 챕터리스트 들어갔는지 확인 나중에 지울 예정
                        //for (int i = 0; i < 5; i++)
                        //{
                        //    Debug.Log("확률적으로 나온배열:" + m_WorldInfo.World_ChapterList[i].ChapterName);
                        //}
                    }
                }//     if (GameManager.instance.WdManager.NowPlayWorld.isChapter == false)




                //처음세팅할때만 저장할때 키는곳

                GameManager.instance.SaveManager.PlayerPrefs_WorldChapterListSave(GameManager.instance.WdManager.NowPlayWorld.World_ChapterList);
               
                GameManager.instance.SaveManager.mySave();
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

    void RandomSetting()
    {
        for (int i = 0; i < m_WorldInfo.World_RandomChapterList.Count; i++)
        {
            int ChapterId = PercentInfo.RandomSelcet(m_WorldInfo.World_RandomChapterList);  //랜덤챕터리스트

            for (int j = 0; j < m_WorldInfo.World_RandomChapterList.Count; j++)
            {
                if (ChapterId == GameManager.instance.ChaptManager.ChapterList[j].Chapterid)    //랜덤챕터리스트 와 챕터리스트 아이디 비교
                {
                    m_WorldInfo.World_ChapterList.Add(GameManager.instance.ChaptManager.ChapterList[j]);
                    break;
                }
            }//for (int j = 0; j < World_RandomChapterList.Count; j++)
        }//for (int i = 0; i < World_RandomChapterList.Count; i++)

       
    }
}
