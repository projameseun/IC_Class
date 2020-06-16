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
    public Button ExitBtn;
    public Button ClearBtn;

    public WorldInfoBtn m_WorldBtn = new WorldInfoBtn();

    private void Start()
    {
        if (ExitBtn != null)
        {
          
            ExitBtn.onClick.AddListener(() =>
            {
                //GameManager.instance.SaveManager.PlayerPrefs_ChapterListSave();
                GameManager.instance.WdManager.NowPlayWorld.ExitChapter = true;
                GameManager.instance.SaveManager.PlayerPrefs_WorldChapterListSave();
                SceneManager.LoadScene("Lobby");
               
            });
        }

        if (ClearBtn != null)
        {

            ClearBtn.onClick.AddListener(() =>
            {
                //1.챕터변경 

              
                    GameManager.instance.WdManager.NowPlayWorld.ChapterProgress++;
                int NowChapterProgress = GameManager.instance.WdManager.NowPlayWorld.ChapterProgress;
                GameManager.instance.WdManager.NowPlayWorld.ExitChapter = false;
                GameManager.instance.WdManager.NowPlayWorld.isChapterClear = true;

                Debug.Log("챕터"+ NowChapterProgress.ToString()+"완료했습니다");

                SceneManager.LoadScene("Lobby");
                if (GameManager.instance.ChaptManager.ChapterList.Count == GameManager.instance.WdManager.NowPlayWorld.ChapterProgress)
                {
                    Debug.Log("챕터를 모두 완료했습니다");
                    GameManager.instance.WdManager.SelectedWorldID++ ;   //다음월드진행
                    GameManager.instance.WdManager.NowPlayWorld.ChapterProgress = 0;
                    GameManager.instance.WdManager.NowPlayWorld.isChapter = false;
                    GameManager.instance.WdManager.NowPlayWorld.ExitChapter = false;
                    GameManager.instance.WdManager.NowPlayWorld.isWorldClear = true;
                    GameManager.instance.WdManager.NowPlayWorld.isChapterClear = false;

                    GameManager.instance.SaveManager.PlayerPrefs_WorldChapterListSave();
                    SceneManager.LoadScene("Lobby");
                }
                   
                    //월드세팅을 해준다
                
            });
        }
    }

    private void Update()
    {
        NowChapterTxt.text = "현재진행중인 챕터ID:" + GameManager.instance.WdManager.NowPlayWorld.ChapterProgress.ToString();
        NowWorldTxt.text = "현재진행중인 월드ID:" + GameManager.instance.WdManager.SelectedWorldID.ToString();
        SelectWorldTxt.text = "내가선택한 월드ID:" + GameManager.instance.WdManager.SelectedWorldID.ToString();
       // NowStateTxt.text = "현재스테이지:" + GameManager.instance.WdManager.NowPlayWorld.World_ChapterList
    }
}
