using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
  
    public List<WorldInfo> WorldList;
    public int SelectedWorldID;

    public void SetWorldList(List<WorldInfo> LoadWorldList)
    {
        WorldList = LoadWorldList;
    }
}
