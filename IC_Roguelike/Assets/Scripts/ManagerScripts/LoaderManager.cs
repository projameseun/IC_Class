using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]//이거 반드시 쓸것
public class Serialization<T>
{

    public Serialization(List<T> _target) => Sheet1 = _target;

    public List<T> Sheet1;
}


public class LoaderManager : MonoBehaviour
{
    //내부 delegate클래스
    private delegate void AccountLoad();
    string FilePath;
    private AccountLoad myLoader;
    //모든 게임데이터 로드
    public void GameDataLoad()
    {
        myLoader += JsonWorldInfoLoad;
        myLoader += JsonDiffcultyWeightLoad;
    }
    private void JsonDiffcultyWeightLoad()
    {
        FilePath = Application.dataPath + "/StreamingAssets/DataTable/DifficultyWeight.json";
        string jdata = File.ReadAllText(FilePath);

        List<ChapterInfo> a_LoadItemList;
        a_LoadItemList = JsonUtility.FromJson<Serialization<ChapterInfo>>(jdata).Sheet1;
    }
   private void JsonWorldInfoLoad()
    {
        //테이블 명은 분리해주세요
        FilePath = Application.dataPath + "/StreamingAssets/DataTable/WorldInfo.json";
        string jdata = File.ReadAllText(FilePath);

        List<WorldInfo> a_LoadItemList;
        a_LoadItemList = JsonUtility.FromJson<Serialization<WorldInfo>>(jdata).Sheet1;

        //여기서 데이터 처리
        for(int i=0;i< a_LoadItemList.Count; i++)
        {
            string[] datas = a_LoadItemList[i].Wolrd_RandomChapter.Split(',');
            for(int j = 0; j < datas.Length; j++)
            {
                string[] Splits = datas[j].Split(':');
                a_LoadItemList[i].World_RandomChapterList[j].ID =int.Parse( Splits[0]);
                a_LoadItemList[i].World_RandomChapterList[j].Percent = int.Parse(Splits[1]);
            }
        }
        //여기서 게임매니저의 인스턴스의 월드매니저의 SetWorldList(a_LoadItemList)호출
    }

    private void Start()
    {
        GameDataLoad();

        myLoader();
    }

    //추가 구현사항
    //delegate 변수에 Load함수 등록할것
    //시작과 동시에 등록
    //프리셋들이 추가될때마다 함수도 추가

}
