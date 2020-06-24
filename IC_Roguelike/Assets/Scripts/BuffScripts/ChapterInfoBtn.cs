using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterInfoBtn : MonoBehaviour
{
    public Button m_ChapterBtn;
    public ChapterInfo m_ChapterInfo = new ChapterInfo();
    public Text m_Text;
    public int Count;   //현재진행중인챕터인덱스숫자
    //여기에서 Now챕터를 만들어야된다 
    private void Start()
    {
        if (m_ChapterBtn != null)
        {
            m_ChapterBtn.onClick.AddListener(() =>
            {
                //스테이지 세팅 스테이지는 무조건 나오면 다시돌리기랜덤으로
            



                //현재진행중인챕터 저장 
                //월드에 해당되는 챕터 저장 
                // GameManager.instance.SaveManager.PlayerPrefs_ChapterListSave();
                GameManager.instance.SaveManager.PlayerPrefs_WorldChapterListSave();
                int NowChapterCount = GameManager.instance.WdManager.NowPlayWorld.ChapterProgress;
                GameManager.instance.ChaptManager.NowChapter = GameManager.instance.WdManager.NowPlayWorld.World_ChapterList[NowChapterCount];

                RandomSetting();
                SceneManager.LoadScene("InGame");

            });//  m_ChapterBtn.onClick.AddListener(() =>
        }//if(ChapterBtn != null)
    }

    public void RandomSetting()
    {
        GameManager.instance.ChaptManager.NowChapter.IsClear = false;

        for (int i = 0; i < 10; i++)
        {
            int ChapterId = PercentInfo.StageRandomSelect(m_ChapterInfo.Chapter_MapList);  //랜덤챕터리스트
            Debug.Log("Chapter ID" + ChapterId);
                                                                                           //Debug.Log(ChapterId);
            for (int j = 0; j < GameManager.instance.StManager.StageList.Count; j++)
            {
                if (ChapterId == GameManager.instance.StManager.StageList[j].Stageid)    //랜덤챕터리스트 와 챕터리스트 아이디 비교
                {
                    GameManager.instance.ChaptManager.NowChapter.Chapter_StageList.Add(GameManager.instance.StManager.StageList[j]);
                    

                }
            }//for (int j = 0; j < World_RandomChapterList.Count; j++)
        }
    }
}
