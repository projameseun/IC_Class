using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
   //public static WorldManager instance = null;

    public List<WorldInfo> WorldList;
    public int SelectedWorldID = 0; //월드 클릭햇을때 저장
    public WorldInfo NowPlayWorld = new WorldInfo();  //진행중인월드
 

    private void Start()
    {
        //SelectedWorldID = 1;
    }
    public void SetWorldList(List<WorldInfo> LoadWorldList)
    {
        Debug.Log("SetWorldLIst");
        WorldList = LoadWorldList;
    }

    
}
