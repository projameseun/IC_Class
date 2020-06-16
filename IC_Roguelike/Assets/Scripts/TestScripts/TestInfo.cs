using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TestInfo : MonoBehaviour
{
    public Text NowChapterTxt;
    public Text NowWorldTxt;    //진행중인월드
    public Text SelectWorldTxt;
    public Text NowStateTxt;
    public Text NowStageIDTxt;
    public Button ExitBtn;
    public Button ClearBtn;
    public int StageCount;
    public WorldInfoBtn m_WorldBtn = new WorldInfoBtn();

    private void Start()
    {
        StageCount = 0;
        if (ExitBtn != null)
        {
          
            ExitBtn.onClick.AddListener(() =>
            {
                //GameManager.instance.SaveManager.PlayerPrefs_ChapterListSave();
                //여기도 재개화면대변경할거임
                GameManager.instance.WdManager.NowPlayWorld.ExitChapter = true;
                GameManager.instance.SaveManager.PlayerPrefs_WorldChapterListSave();
              
                SceneManager.LoadScene("Lobby");
                StageCount = 0;
            });
        }

        if (ClearBtn != null)
        {

            ClearBtn.onClick.AddListener(() =>
            {
                //1.챕터변경 

                StageCount++;
                if (StageCount ==10 )
                {
                    StageClear();
                }
               



            });
        }
    }

    private void Update()
    {

        NowChapterTxt.text = "현재진행중인 챕터ID:" + GameManager.instance.WdManager.NowPlayWorld.ChapterProgress.ToString();
        NowWorldTxt.text = "현재진행중인 월드ID:" + GameManager.instance.WdManager.SelectedWorldID.ToString();
        SelectWorldTxt.text = "내가선택한 월드ID:" + GameManager.instance.WdManager.SelectedWorldID.ToString();
        NowStateTxt.text = "현재스테이지:" + (StageCount + 1).ToString();
        if(StageCount <= 9)
        NowStageIDTxt.text = "현재스테이지ID:" + GameManager.instance.WdManager.NowPlayWorld.World_ChapterList[GameManager.instance.WdManager.NowPlayWorld.ChapterProgress].
                           Chapter_StageList[StageCount].Stageid.ToString();

    }

    void StageClear()
    {
        GameManager.instance.WdManager.NowPlayWorld.ChapterProgress++;
        int NowChapterProgress = GameManager.instance.WdManager.NowPlayWorld.ChapterProgress;
        GameManager.instance.WdManager.NowPlayWorld.ExitChapter = false;
        GameManager.instance.WdManager.NowPlayWorld.isChapterClear = true;

       
        Debug.Log("챕터" + NowChapterProgress.ToString() + "완료했습니다");

      

        if (GameManager.instance.ChaptManager.ChapterList.Count == GameManager.instance.WdManager.NowPlayWorld.ChapterProgress)
        {
            Debug.Log("챕터를 모두 완료했습니다");
            GameManager.instance.WdManager.SelectedWorldID++;   //다음월드진행
            GameManager.instance.WdManager.NowPlayWorld.ChapterProgress = 0;
            GameManager.instance.WdManager.NowPlayWorld.isChapter = false;
            GameManager.instance.WdManager.NowPlayWorld.ExitChapter = false;
            GameManager.instance.WdManager.NowPlayWorld.isWorldClear = true;
            GameManager.instance.WdManager.NowPlayWorld.isChapterClear = false;

            GameManager.instance.SaveManager.PlayerPrefs_WorldChapterListSave();
            SceneManager.LoadScene("Lobby");
            return;
        }

        SceneManager.LoadScene("Lobby");
    }
}
