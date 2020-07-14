using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling;
using UnityEngine;



public class Node:MonoBehaviour
{
    private MapTile[,] TileArray = null; //맵타일의 3X3이 노드

    
    //노드의 타입에 따라서 
    //일정타일을 None타일에서 오브젝트,몬스터 타일로 변경

    private void Start()
    {
        TileArray = new MapTile[3,3];
        
        SetTileType();
    }

    private void SetTileType()
    {
        for(int i=0; i<TileArray.GetLength(0); i++)
        {
            for(int j=0; j<TileArray.GetLength(1); j++)
            {
               
                    
            }
        }
    }
}
