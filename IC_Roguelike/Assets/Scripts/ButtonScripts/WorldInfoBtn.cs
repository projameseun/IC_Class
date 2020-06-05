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
                if (GameManager.instance.WdManager.NowPlayWorld.isChapter == false)
                {
                    for (int i = 0; i < m_WorldInfo.World_RandomChapterList.Count; i++)
                    {
                        int ChapterId = PercentInfo.RandomSelcet(m_WorldInfo.World_RandomChapterList);

                        for (int j = 0; j < m_WorldInfo.World_RandomChapterList.Count; j++)
                        {
                            if (ChapterId == GameManager.instance.ChaptManager.ChapterList[j].Chapterid)
                            {
                                m_WorldInfo.World_ChapterList.Add(GameManager.instance.ChaptManager.ChapterList[j]);
                                break;
                            }
                        }//for (int j = 0; j < World_RandomChapterList.Count; j++)
                    }//for (int i = 0; i < World_RandomChapterList.Count; i++)
                     //RandomSelcet();

                   // 로그찍는곳 제대로 챕터리스트 들어갔는지 확인 나중에 지울 예정
                    for (int i = 0; i < 5; i++)
                    {
                        Debug.Log("확률적으로 나온배열:" + m_WorldInfo.World_ChapterList[i].ChapterName);
                    }
                }

                GameManager.instance.WdManager.SelectedWorldID = 1;
                GameManager.instance.LoaderManager.PlayerPrefs_ChapterListSave(m_WorldInfo.World_ChapterList);
                //다섯개가 성성되고 챕터패널이 활성화되는곳
                // GameManager.instance.ChaptManager.SettingWorld_Chpater(World_ChapterList);

            });// m_WorldBtn.onClick.AddListener(() =>
        }// if (m_WorldBtn != null)
        #endregion WorldClick
    }
}
