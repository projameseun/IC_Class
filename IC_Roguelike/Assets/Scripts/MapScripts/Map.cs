using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Map : MonoBehaviour
{

    [SerializeField] private int MapID;   //맵 ID
    [SerializeField] private int height;  //노드길이
    [SerializeField] private int width;


    //노드정보를 담은 2차원배열
    public Node[,] NodeArray = null;

    //노드의 타일의 랜덤이미지 스프라이트
    private Sprite[] RandomSprite;

    private GameObject MapNode;
    public GameObject MapManager = null;

    //해당스테이지 데이터를 넣는 변수(클래스)
    StageInfo MapStage = null;

    int posX = 0;
    int posY = 0;
    private void Start()
    {
        NodeArray = new Node[width, height];
        //Debug.Log("1" + NodeArray.GetLength(0));
        //Debug.Log("2" + NodeArray.GetLength(1));

        SetNodeRandomType();
    }

    //노드의 스프라이트를 랜덤으로 세팅하는작업 
    public void SetNodeRandomSprite()
    {
        
    }
    //노드들의 타입을 랜덤으로 세팅하는 작업
    public void SetNodeRandomType()
    {
        //여기서 wall생성
        for (int i = 0; i < NodeArray.GetLength(1); i++)
        {
            for (int j = 0; j < NodeArray.GetLength(0); j++)
            {

                //Debug.Log("test");
                //NodeArray[0].
                MapNode = Resources.Load("Prefabs/MapNode") as GameObject;
                GameObject a_Node = (GameObject)Instantiate(MapNode);
                a_Node.transform.SetParent(MapManager.transform, false);
                a_Node.transform.position = new Vector3(posX, posY, 0);
                

                posX += 3;
                if (j == width - 1)
                {
                    posX = 0;
                    posY -= 3;
                }
                //Debug.Log(a_Node.transform.position);
            }
        }
    }

    

}
