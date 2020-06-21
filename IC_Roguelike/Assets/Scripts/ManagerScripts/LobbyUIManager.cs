using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyUIManager : MonoBehaviour
{
    public GameObject m_ChapterPanel;
    public ScrollRect m_ChapterScroll;
    public GameObject m_ChpaterPrefab;
    public GameObject m_ResumePanel;
   // public GameObject m_WorldPrefab;
    public GameObject m_Dugeon;

    [Header("테스트하는곳")]
    public GameObject[] WorldUIList;

    [Header("재개화면 UI")]
    public Button EnterBtn;
    public Button GiveUpBtn;
    public Text NowWorldID;
    public Text NowChapterID;
    public Text PlayerHp;

    private void Start()
    {
        GameManager.instance.LobbyUIManger = this;
        m_ChapterPanel.SetActive(false);

        if(EnterBtn != null)
        {
           
           EnterBtn.onClick.AddListener(()=>
           {
               Debug.Log("입장");
               //현재진행중인챕터 저장 
               //월드에 해당되는 챕터 저장 
               // GameManager.instance.SaveManager.PlayerPrefs_ChapterListSave();
               //ChapterInfoBtn MakedObject = new ChapterInfoBtn();

               //MakedObject.RandomSetting();

               GameManager.instance.SaveManager.PlayerPrefs_WorldChapterListSave();
               SceneManager.LoadScene("LogGame");

           });
        }

        if(GiveUpBtn != null)
        {
            GiveUpBtn.onClick.AddListener(() =>
            {
                Debug.Log("포기");
                

            });
        }

        
    }

    private void Update()
    {
        
        PlayerHp.text = "플레이어목숨:" + PlayerCtrl.PlayerHp.ToString();
        NowChapterID.text = "현재진행중인 챕터ID:" + GameManager.instance.WdManager.NowPlayWorld.ChapterProgress.ToString();
        NowWorldID.text = "현재진행중인 월드ID:" + GameManager.instance.WdManager.SelectedWorldID.ToString();
        //SelectWorldTxt.text = "내가선택한 월드ID:" + GameManager.instance.WdManager.SelectedWorldID.ToString();
    }

    public void SettingWorld_WorldList()
    {
        //월드 프리팹으로 변경하며 그때 쓰기 
        for(int i=0; i<WorldUIList.Length; i++)
        {
            //1.프리팹 content생성 (Chpater)
            //2.Id값 넣어주기 
            //3.지금선택된 챕터가 아니라면 다른 챕터들은 버튼 안되게하기 
            
            if(i <= GameManager.instance.WdManager.SelectedWorldID - 1)
            {
                WorldUIList[i].GetComponent<Image>().raycastTarget = true;
                WorldUIList[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            else
            {
                WorldUIList[i].GetComponent<Image>().raycastTarget = false;
                WorldUIList[i].GetComponent<Image>().color = new Color32(255, 255, 255, 128);
            }
 
         

        }

        WorldUIList[0].GetComponent<Image>().raycastTarget = true;
        WorldUIList[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);

    }

    public void SettingWorld_ChpaterList()
    {
        GameManager.instance.WdManager.NowPlayWorld.World_ChapterList[GameManager.instance.WdManager.NowPlayWorld.ChapterProgress].
                       Chapter_StageList.Clear();

        m_ChapterPanel.SetActive(true);
        //지금은 예시로 다섯개 지정해놨는데 나중에는 카운터만큼 들어가게한다 
        Debug.Log(GameManager.instance.WdManager.NowPlayWorld.World_ChapterList.Count);
        for (int i = 0; i < GameManager.instance.WdManager.NowPlayWorld.World_ChapterList.Count; i++)
        {
            //1.프리팹 content생성 (Chpater)
            //2.Id값 넣어주기 
            //3.지금선택된 챕터가 아니라면 다른 챕터들은 버튼 안되게하기 
            GameObject MakedObject =
            Instantiate(m_ChpaterPrefab, m_ChapterScroll.content.transform);
           
            //테스트
            if (i != GameManager.instance.WdManager.NowPlayWorld.ChapterProgress)
            {
                MakedObject.GetComponent<Image>().color = new Color32(255, 255, 255, 128);
                MakedObject.GetComponent<Image>().raycastTarget = false;
            }
            else
            {
                MakedObject.GetComponent<Image>().raycastTarget = true;
               
            }
            MakedObject.GetComponent<ChapterInfoBtn>().m_Text.text = GameManager.instance.WdManager.NowPlayWorld.World_ChapterList[i].Chapterid.ToString();
            MakedObject.GetComponent<ChapterInfoBtn>().Count = i+1;
            // Debug.Log(m_ChpaterBtn.GetComponent<Text>().text);

        }


     
    }

   
}
