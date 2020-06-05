using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;


public class ChapterManager : MonoBehaviour
{
    public ChapterInfo NowChapter;
    public List<ChapterInfo> ChapterList = new List<ChapterInfo>();

    public GameObject m_ChapterPanel;
    //임시테스트용이다 지금은 json이없어서
    private void Start()
    {
        m_ChapterPanel.SetActive(false);
        //처음설정할때만 
        for (int i = 0; i < 5; i++)
        {

            ChapterList.Add(new ChapterInfo()
            {
                Chapterid = i + 1,
                ChapterName = "테스트" + (i + 1).ToString()
            });
        }
        //Debug.Log("오나");
    }
    public void SetChapterList(List<ChapterInfo> a_ChapterList)
    {
       // Debug.Log("챕터 리스트");
        ChapterList = a_ChapterList;
    }    
    
    public void SettingWorld_Chpater(List<ChapterInfo> a_ChpaterList)
    {
        m_ChapterPanel.SetActive(true);
        NowChapter = a_ChpaterList[0];
        //Debug.Log(NowChapter.Chapterid);
        //for(int i=0; i<a_ChpaterList.Count; i++)
        //{
            
        //}
        
    }
}
