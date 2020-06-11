using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    //내부 delegate클래스
    public delegate void AccountSave();
    string FilePath;
    public AccountSave mySave;
    //모든 게임데이터 로드

    public void GameDataSave()
    {
        mySave = null;

        //mySave += PlayerPrefs_WorldChapterListSave;
        mySave += JsonWorldListSave;
       
        Debug.Log("GameDataSave");

      
    }


    private void JsonWorldListSave()
    {
        //string jdata = JsonUtility.ToJson(new PlayerInfoSerialization<PlayerInfo>(PlayerManager.instance.MyPlayerInfoList));
        FilePath = Application.dataPath + "/StreamingAssets/DataTable/WorldInfo.json";
        //리스트는 저장이 안되지만 크랠스는 저장이된다.
        string jdata = JsonUtility.ToJson(new Serialization<WorldInfo>(GameManager.instance.WdManager.WorldList));
        //byte[] bytes = System.Text.Encoding.UTF8.GetBytes(jdata);
        File.WriteAllText(FilePath, jdata);
        Debug.Log("저장완료");
    }



    public void PlayerPrefs_WorldChapterListSave()
    {

        //월드를 누르고챕터가 생성되면 월드하나가 무조건 저장된다.
 
      
        PlayerPrefs.SetInt("WorldID", GameManager.instance.WdManager.SelectedWorldID);
     
        for (int i = 0; i < GameManager.instance.WdManager.NowPlayWorld.World_ChapterList.Count; i++)
        {
            string Savedata = "ChapterName " + (i + 1);
            PlayerPrefs.SetString(Savedata, GameManager.instance.WdManager.NowPlayWorld.World_ChapterList[i].ChapterName);
            string Savedata2 = "ChpaterID " + (i + 1);
            PlayerPrefs.SetInt(Savedata2,GameManager.instance.WdManager.NowPlayWorld.World_ChapterList[i].Chapterid);
 
        }

        //Debug.Log("다지우나요");
        PlayerPrefs.Save();
        //PlayerPrefs.DeleteAll();
    }

    public void PlayerPrefs_ChapterListSave()
    {
        //처음세팅할때만 월드새로될때만
        if (GameManager.instance.WdManager.SelectedWorldID == 0)
            GameManager.instance.WdManager.NowPlayWorld.ChapterProgress = 0;//처음에는 첫번째
        
        //현재월드에 저장된챕터
        PlayerPrefs.SetInt("ChpaterProgress", GameManager.instance.WdManager.NowPlayWorld.ChapterProgress);
        PlayerPrefs.SetInt("WorldID", GameManager.instance.WdManager.SelectedWorldID);
   
    }

    public void PlayerPrefs_ChapterClear()
    {
        PlayerPrefs.SetString("WorldSelect", "false");   //
        PlayerPrefs.SetInt("ChpaterProgress", GameManager.instance.WdManager.NowPlayWorld.ChapterProgress);
        PlayerPrefs.SetInt("WorldID", GameManager.instance.WdManager.SelectedWorldID);
    }

   
}
