using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TestInfo : MonoBehaviour
{
    public Text NowChapterTxt;
    public Button ExitBtn;
    public Button ClearBtn;

    private void Start()
    {
        if (ExitBtn != null)
        {
          
            ExitBtn.onClick.AddListener(() =>
            {
                GameManager.instance.SaveManager.PlayerPrefs_ChapterListSave();
                SceneManager.LoadScene("Lobby");
            });
        }

        if (ClearBtn != null)
        {

            ClearBtn.onClick.AddListener(() =>
            {
                //1.챕터변경 
                if(GameManager.instance.WdManager.NowPlayWorld.ChapterProgress < GameManager.instance.WdManager.NowPlayWorld.World_ChapterList.Count-1)
                GameManager.instance.WdManager.NowPlayWorld.ChapterProgress++;
                else
                {
                    GameManager.instance.WdManager.NowPlayWorld.ChapterProgress = 0; //챕터프로그래스초기화
                    GameManager.instance.WdManager.SelectedWorldID++;
                    GameManager.instance.WdManager.NowPlayWorld.isChapter = false;
                    GameManager.instance.SaveManager.PlayerPrefs_ChapterClear();
                    SceneManager.LoadScene("Lobby");
                    Debug.Log("챕터를 모두 완료했습니다");
                    if (GameManager.instance.WdManager.SelectedWorldID >= 5)
                        PlayerPrefs.DeleteAll();
                    //월드세팅을 해준다
                }
            });
        }
    }

    private void Update()
    {
        NowChapterTxt.text = "현재진행중인 챕터ID:" + GameManager.instance.WdManager.NowPlayWorld.ChapterProgress.ToString();
    }
}
