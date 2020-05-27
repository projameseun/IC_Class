using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    public WorldManager WdManager;
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

}
