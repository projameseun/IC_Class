using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void PlayerPrefs_ChapterListSave(List<ChapterInfo> a_ChapterList)
    {
        //월드를 누르고챕터가 생성되면 월드하나가 무조건 저장된다.
        // bool isActive = true;
        if (GameManager.instance.WdManager.SelectedWorldID != 0)
        {

        }
        else
        {
            PlayerPrefs.SetString("WorldSelect", "false");
        }
        PlayerPrefs.SetString("WorldSelect", "true");

        //0이면 
        PlayerPrefs.SetInt("WorldID", GameManager.instance.WdManager.SelectedWorldID);
       


        for (int i = 0; i < a_ChapterList.Count; i++)
        {
            string Savedata = "ChapterName " + (i + 1);
            PlayerPrefs.SetString(Savedata, a_ChapterList[i].ChapterName);
            string Savedata2 = "ChpaterID " + (i + 1);
            PlayerPrefs.SetInt(Savedata2, a_ChapterList[i].Chapterid);
            if (i == 0)
            {
                string SaveData3 = "NowChapter" + (i + 1);
                PlayerPrefs.SetInt(SaveData3, a_ChapterList[i].Chapterid);
            }
              
        }

        PlayerPrefs.Save();
        //PlayerPrefs.DeleteAll();
    }
}
