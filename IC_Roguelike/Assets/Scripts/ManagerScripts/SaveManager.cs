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
             //진행중인 월드가없을때 들어간다
            PlayerPrefs.SetString("WorldSelect", "true");   //
        else
        
            PlayerPrefs.SetString("WorldSelect", "false");   //
        
        if(GameManager.instance.WdManager.NowPlayWorld.ExitChapter == true)
             PlayerPrefs.SetString("ExitChapter", "true"); 
        else
    
            PlayerPrefs.SetString("ExitChapter", "false");
       
        if (GameManager.instance.WdManager.NowPlayWorld.isWorldClear == true)
        
            PlayerPrefs.SetString("WorldClear", "true");
        
        else               
            PlayerPrefs.SetString("WorldClear", "false");

        if (GameManager.instance.WdManager.NowPlayWorld.isChapterClear == true)
            PlayerPrefs.SetString("ChapterClear", "true");
        else
            PlayerPrefs.SetString("ChapterClear", "false");
          
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

            //일단은랜덥챕터리스트저장
            PlayerPrefs.SetInt("ChapterRandomCount", GameManager.instance.WdManager.NowPlayWorld.World_RandomChapterList.Count);
            for (int i = 0; i < GameManager.instance.WdManager.NowPlayWorld.World_RandomChapterList.Count; i++)
            {
                string Savedata = "ChapterRandomName " + (i + 1);
                PlayerPrefs.SetInt(Savedata, GameManager.instance.WdManager.NowPlayWorld.World_RandomChapterList[i].ID);
                string Savedata2 = "ChpaterRandomPercent " + (i + 1);
                PlayerPrefs.SetFloat(Savedata2, GameManager.instance.WdManager.NowPlayWorld.World_RandomChapterList[i].Percent);
                Debug.Log(Savedata);
                Debug.Log(Savedata2);
            }
            //일단은랜덥챕터리스트저장
          
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

    //임시함수 나가기버튼눌럿을대
   public void PlayerPrefs_ExitChapter()
    {
        //여기있는건다임시임
        PlayerPrefs.SetString("ExitChapter", "true");
    }

    public void PlayerPrefs_ChapterClear()
    {
        PlayerPrefs.SetString("WorldSelect", "false");   //
        PlayerPrefs.SetInt("ChpaterProgress", GameManager.instance.WdManager.NowPlayWorld.ChapterProgress);
        PlayerPrefs.SetInt("WorldID", GameManager.instance.WdManager.SelectedWorldID);
    }
}
