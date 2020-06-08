using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUIManager : MonoBehaviour
{
    public GameObject m_ChapterPanel;
    public ScrollRect m_ChapterScroll;
    public GameObject m_ChpaterPrefab;
    public GameObject m_Dugeon;
    private void Start()
    {
        GameManager.instance.LobbyUIManger = this;
        m_ChapterPanel.SetActive(false);
    }

    public void SettingWorld_ChpaterList()
    {

        m_ChapterPanel.SetActive(true);
        //지금은 예시로 다섯개 지정해놨는데 나중에는 카운터만큼 들어가게한다 
        Debug.Log(GameManager.instance.WdManager.NowPlayWorld.World_ChapterList.Count);
        for (int i = 0; i < 5; i++)
        {
            //1.프리팹 content생성 (Chpater)
            //2.Id값 넣어주기 
            //3.지금선택된 챕터가 아니라면 다른 챕터들은 버튼 안되게하기 
            GameObject MakedObject =
            Instantiate(m_ChpaterPrefab, m_ChapterScroll.content.transform);
            //테스트
            if (i != 0)
            {
                MakedObject.GetComponent<Image>().color = new Color32(255, 255, 255, 128);
                MakedObject.GetComponent<Image>().raycastTarget = false;
            }
            else
            {
                MakedObject.GetComponent<Image>().raycastTarget = true;
            }
            MakedObject.GetComponent<ChapterInfoBtn>().m_Text.text = GameManager.instance.WdManager.NowPlayWorld.World_ChapterList[i].Chapterid.ToString();
            // Debug.Log(m_ChpaterBtn.GetComponent<Text>().text);

        }





    }
}
