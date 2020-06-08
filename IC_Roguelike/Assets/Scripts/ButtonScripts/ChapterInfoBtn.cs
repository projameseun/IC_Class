using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChapterInfoBtn : MonoBehaviour
{
    public Button m_ChapterBtn;
    public Text m_Text;
    //여기에서 Now챕터를 만들어야된다 
    private void Start()
    {
        if (m_ChapterBtn != null)
        {
            m_ChapterBtn.onClick.AddListener(() =>
            {

                SceneManager.LoadScene("Ingame");

            });//  m_ChapterBtn.onClick.AddListener(() =>
        }//if(ChapterBtn != null)
    }
}
