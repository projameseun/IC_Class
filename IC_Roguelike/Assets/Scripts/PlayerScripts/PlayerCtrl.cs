using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum PlayerAni
{
    Idle,
    Front,
    Back,
    Right,
    Left,
    Length,
}


public class PlayerCtrl : MonoBehaviour
{
    //키보드
    float h, v;
    private float m_MoveSpeed = 2.0f; //초당 10픽셀을 이동해라 라는 속도 (이동속도)
    Vector3 MoveNextStep;            //보폭을 계산해 주기 위한 변수
    Vector3 MoveHStep;
    Vector3 MoveVStep;

    //----- 마우스 피킹 관련 변수들...
    private bool m_bMoveOnOff = false;     //현재 마우스피킹으로 이동중인지?의 여부
    private Vector3 m_DirVec;              //마우스피킹으로 이동하려는 방향 벡터
    private Vector3 m_TargetPos;           //마우스피킹 목표점
    private double m_MoveDurTime = 0.0;    //목표점까지 도착하는데 걸리는 시간
    private double m_AddTimeCount = 0.0;   //누적시간 카운트 
    private float a_CacStep;

    float m_AttackDist = 14.0f;            //공격거리
    float m_ShootCool = 1.0f;              //공격 쿨타임 (공격 주기)
                                           //----- 마우스 피킹 관련 변수들...
    private Vector3 a_CurPos;
    private Vector3 a_CacEndVec;

   
    //test 이미지
    public Sprite[] m_HeroSprite;

    //test rigi
    public Rigidbody2D rb;

    static public int PlayerHp;

    private void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = m_HeroSprite[(int)PlayerAni.Idle];
        //PlayerHp = 5;
    }
    private void Update()
    {

        PlayerMove();
    }

    void PlayerMove()
    {
        //-------------- 가감속 없이 이동 처리 하는 방법
        h = Input.GetAxisRaw("Horizontal"); //화살표키 좌우키를 눌러주면 -1.0f, 0.0f, 1.0f 사이값을 리턴해 준다.
        v = Input.GetAxisRaw("Vertical");   //화살표키 위아래키를 눌러주면 -1.0f, 0.0f, 1.0f 사이값을 리턴해 준다.
                                            //-------------- 가감속 없이 이동 처리 하는 방법
                                            //Debug.Log("h =" + h);
                                            //Debug.Log("v =" + v);
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) //오른쪽 
            this.gameObject.GetComponent<SpriteRenderer>().sprite = m_HeroSprite[(int)PlayerAni.Right];
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = m_HeroSprite[(int)PlayerAni.Left];
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = m_HeroSprite[(int)PlayerAni.Back];
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            this.gameObject.GetComponent<SpriteRenderer>().sprite = m_HeroSprite[(int)PlayerAni.Front];

        if (0.0f != h || 0.0f != v) //키보드 이동처리
        {
           
            //Vector3.right == new Vector3(1.0f, 0.0f, 0.0f)
            //Vector3.forward == new Vector3(0.0f, 0.0f, 1.0f)
            MoveHStep = Vector3.right * h;
            MoveVStep = Vector3.up * v;

          

            MoveNextStep = MoveHStep + MoveVStep;
            //MoveNextStep = MoveNextStep.normalized * m_MoveSpeed * Time.deltaTime;
            
            MoveNextStep = MoveNextStep.normalized * m_MoveSpeed;
            //transform.position = transform.position + MoveNextStep;
            
            rb.velocity = new Vector2(MoveNextStep.x,MoveNextStep.y);
        }
        else

        {
            rb.velocity = new Vector2(0, 0);
            this.gameObject.GetComponent<SpriteRenderer>().sprite = m_HeroSprite[(int)PlayerAni.Idle];
        }

        
    
    }

    public void MsPicking(Vector3 a_Pos) //마우스 클릭 입력 처리함수
    {
        Vector3 a_CacVec = a_Pos - this.transform.position;
        a_CacVec.y = 0.0f;
        if (a_CacVec.magnitude < 1.0f)
        {
            return;
        }

        m_bMoveOnOff = true;

        m_DirVec = a_CacVec;
        m_DirVec.Normalize();        // 단위 벡터를 만든다. 
        m_MoveDurTime = a_CacVec.magnitude / m_MoveSpeed; //도착하는데 걸리는 시간
        m_AddTimeCount = 0.0;
        m_TargetPos = new Vector3(a_Pos.x,
                                 this.transform.position.y,
                                 a_Pos.z); //a_Pos;         // 목표점
    }//public void MsPicking(Vector3 a_Pos)


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Potal")
        {
            GameManager.instance.LobbyUIManger.m_Dugeon.SetActive(true);
            WorldInfoBtn a_Object = new WorldInfoBtn();
            //재개화면
            //if (GameManager.instance.WdManager.NowPlayWorld.ExitChapter == true)
            //{
            //    GameManager.instance.LobbyUIManger.m_ResumePanel.SetActive(true);
            //    return;
            //}
            if(GameManager.instance.WdManager.NowPlayWorld.ExitChapter == true)
            {
                GameManager.instance.LobbyUIManger.SettingWorld_ChpaterList();
                return;
            }
            if (GameManager.instance.WdManager.NowPlayWorld.isChapter == false)
                a_Object.TestWorld();
            else if (GameManager.instance.WdManager.NowPlayWorld.isChapterClear == true && GameManager.instance.WdManager.NowPlayWorld.ExitChapter == false)
            {   //진행중인 월드에 챕터가 있다면 월드는 보여주지않는다 이때 재개화면 나오게하기
                a_Object.RandomSetting();
                GameManager.instance.LobbyUIManger.SettingWorld_ChpaterList();
                //GameManager.instance.LobbyUIManger.m_ResumePanel.SetActive(true);
            }    //GameManager.instance.LobbyUIManger.SettingWorld_WorldList();
            
        }
   
        // SceneManager.LoadScene("Lobby");


    }

}
