using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBtn : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject monsterPrefab;

    public void PlayerBtn()
    {
        Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void MonsterBtn()
    {
        Instantiate(monsterPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
