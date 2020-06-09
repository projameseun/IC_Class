using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    public WorldManager WdManager;
    public ChapterManager ChaptManager;
    public StageManager StManager;
    public PlayerInfoManager PlayManager;   
    public LoaderManager LoaderManager;     //로드를 총관리하는곳
    public SaveManager SaveManager;         //세이브를 총관리하는곳
    public LobbyUIManager LobbyUIManger;

    //초기화버튼 나중에지울거
    public Button InitBtn;
    //void Awake()
    //{
    //    instance = this;
    //}
    //나중에 Dondestroy 씬넘어갈때 피하는 방법
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if(InitBtn != null)
        {
            InitBtn.onClick.AddListener(() =>
            {
                PlayerPrefs.DeleteAll();
            });
        }
    }

}
