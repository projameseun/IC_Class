using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    //-------------- 카메라가 주인공을 따라다니게 하기 위한 변수
    public GameObject m_HeroObj = null;

    private float smoothTime = 0.2f;
    private float xVelocity = 0.0f;
    private float zVelocity = 0.0f;
    Vector3 newPosition = Vector3.zero;
    //-------------- 카메라가 주인공을 따라다니게 하기 위한 변수

    //----- 카메라 줌 인아웃
    private float maxDist = 50.0f;
    private float minDist = 5.0f;
    private float zoomSpeed = 1.0f;
    private float distance = 10.0f;
    //----- 카메라 줌 인아웃

    // Start is called before the first frame update
    void Start()
    {
        distance = Camera.main.GetComponent<Camera>().orthographicSize;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        newPosition = transform.position;
        newPosition.x = Mathf.SmoothDamp(transform.position.x,
            m_HeroObj.transform.position.x, ref xVelocity, smoothTime);
        newPosition.z = Mathf.SmoothDamp(transform.position.z,
            m_HeroObj.transform.position.z, ref zVelocity, smoothTime);
        transform.position = newPosition;

        //this.transform.position = 
        //    new Vector3(m_HeroObj.transform.position.x, 
        //                this.transform.position.y, 
        //                m_HeroObj.transform.position.z);

        //------------------- PC에서만 작동되는 줌인 줌아웃 기능
        if (Input.GetAxis("Mouse ScrollWheel") < 0 && distance < maxDist)
        {
            distance += zoomSpeed;
            Camera.main.GetComponent<Camera>().orthographicSize = distance;
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0 && distance > minDist)
        {
            distance -= zoomSpeed;
            Camera.main.GetComponent<Camera>().orthographicSize = distance;
        }
        //------------------- PC에서만 작동되는 줌인 줌아웃 기능
    }
}
