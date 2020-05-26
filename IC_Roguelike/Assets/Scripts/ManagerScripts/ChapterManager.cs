using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterManager : MonoBehaviour
{
    public ChapterInfo NowChapter;
    public List<ChapterInfo> ChapterList; 

    public void SetChapterList(List<ChapterInfo> a_ChapterList)
    {
        Debug.Log("챕터 리스트");
        ChapterList = a_ChapterList;
    }    
}
