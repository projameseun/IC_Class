using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void PlayerPrefs_WorldChapterListSave()
    {
        //월드를 누르고챕터가 생성되면 월드하나가 무조건 저장된다.
        // bool isActive = true;
        if (GameManager.instance.WdManager.NowPlayWorld.isChapter == true)
        {
            //진행중인 월드가없을때 들어간다
            PlayerPrefs.SetString("WorldSelect", "true");   //
        }
        else
        {
            PlayerPrefs.SetString("WorldSelect", "false");   //
        }
    
          
        PlayerPrefs.SetInt("WorldID", GameManager.instance.WdManager.SelectedWorldID);
        PlayerPrefs.SetInt("ChpaterProgress", GameManager.instance.WdManager.NowPlayWorld.ChapterProgress);
        if (GameManager.instance.WdManager.NowPlayWorld.isChapter == true)
        {
            //Debug.Log("저장카운터" + a_ChapterList.Count);
            PlayerPrefs.SetInt("ChapterCount", GameManager.instance.WdManager.NowPlayWorld.World_ChapterList.Count);
            for (int i = 0; i < GameManager.instance.WdManager.NowPlayWorld.World_ChapterList.Count; i++)
            {
                string Savedata = "ChapterName " + (i + 1);
                PlayerPrefs.SetString(Savedata, GameManager.instance.WdManager.NowPlayWorld.World_ChapterList[i].ChapterName);
                string Savedata2 = "ChpaterID " + (i + 1);
                PlayerPrefs.SetInt(Savedata2, GameManager.instance.WdManager.NowPlayWorld.World_ChapterList[i].Chapterid);

            }
        }
        else
        {
            GameManager.instance.WdManager.NowPlayWorld.World_ChapterList.Clear();
            Debug.Log("몇번뜰까요");
        }

        //Debug.Log("다지우나요");
        PlayerPrefs.Save();
        //PlayerPrefs.DeleteAll();
    }

    //public void PlayerPrefs_ChapterListSave()
    //{
    //    //처음세팅할때만 월드새로될때만
    //    if (GameManager.instance.WdManager.SelectedWorldID == 0)
    //        GameManager.instance.WdManager.NowPlayWorld.ChapterProgress = 0;//처음에는 첫번째
        
    //    //현재월드에 저장된챕터
    //    PlayerPrefs.SetInt("ChpaterProgress", GameManager.instance.WdManager.NowPlayWorld.ChapterProgress);
    //    PlayerPrefs.SetInt("WorldID", GameManager.instance.WdManager.SelectedWorldID);
   
    //}

    public void PlayerPrefs_ChapterClear()
    {
        PlayerPrefs.SetString("WorldSelect", "false");   //
        PlayerPrefs.SetInt("ChpaterProgress", GameManager.instance.WdManager.NowPlayWorld.ChapterProgress);
        PlayerPrefs.SetInt("WorldID", GameManager.instance.WdManager.SelectedWorldID);
    }
}
