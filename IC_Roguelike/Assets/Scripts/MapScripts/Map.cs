using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Map : MonoBehaviour
{
    private int MapID;   //맵 ID
    private int height;  //노드길이
    private int width;


    //노드정보를 담은 2차원배열
    private Node[,] NodeArray = null;

    //노드의 타일의 랜덤이미지 스프라이트
    private Sprite[] RandomSprite;

    //해당스테이지 데이터를 넣는 변수(클래스)
    StageInfo MapStage = null;

    //노드의 스프라이트를 랜덤으로 세팅하는작업 
    public void SetNodeRandomSprite()
    {

    }
    //노드들의 타입을 랜덤으로 세팅하는 작업
    public void SetNodeRandomType()
    {

    }

}
