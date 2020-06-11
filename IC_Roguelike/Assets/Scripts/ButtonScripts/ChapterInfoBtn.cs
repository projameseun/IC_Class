using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterInfoBtn : MonoBehaviour
{
    public Button m_ChapterBtn;
    public Text m_Text;
    public int Count;   //현재진행중인챕터인덱스숫자
    //여기에서 Now챕터를 만들어야된다 
    private void Start()
    {
        if (m_ChapterBtn != null)
        {
            m_ChapterBtn.onClick.AddListener(() =>
            {
                //현재진행중인챕터 저장 
                //월드에 해당되는 챕터 저장 
                // GameManager.instance.SaveManager.PlayerPrefs_ChapterListSave();
                GameManager.instance.SaveManager.PlayerPrefs_WorldChapterListSave();
                int NowChapterCount = GameManager.instance.WdManager.NowPlayWorld.ChapterProgress;
                GameManager.instance.ChaptManager.NowChapter = GameManager.instance.WdManager.NowPlayWorld.World_ChapterList[NowChapterCount];
                SceneManager.LoadScene("Ingame");

            });//  m_ChapterBtn.onClick.AddListener(() =>
        }//if(ChapterBtn != null)
    }
}
