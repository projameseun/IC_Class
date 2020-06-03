﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class ChapterManager : MonoBehaviour
{
    public ChapterInfo NowChapter;
    public List<ChapterInfo> ChapterList = new List<ChapterInfo>();

    //임시테스트용이다 지금은 json이없어서
    private void Start()
    {
       

        for (int i=0; i<5; i++)
        {
        
      
            ChapterList.Add(new ChapterInfo() {Chapterid = i+1,
                                                ChapterName ="테스트" + (i+1).ToString()});
        }
        //Debug.Log("오나");
    }
    public void SetChapterList(List<ChapterInfo> a_ChapterList)
    {
       // Debug.Log("챕터 리스트");
        ChapterList = a_ChapterList;
    }    
}
