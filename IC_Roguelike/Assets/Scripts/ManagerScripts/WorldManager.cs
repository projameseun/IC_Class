using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
   //public static WorldManager instance = null;

    public List<WorldInfo> WorldList;
    public int SelectedWorldID;

    public void SetWorldList(List<WorldInfo> LoadWorldList)
    {
        Debug.Log("SetWorldLIst");
        WorldList = LoadWorldList;
    }

    
}
