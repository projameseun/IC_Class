using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPanelController : MonoBehaviour, IDragHandler
{
    public GameObject playerObject;
    Vector2 touchPos;
    float deltaX, deltaY;

    public void OnDrag(PointerEventData eventData)
    {
        touchPos = Camera.main.ScreenToWorldPoint(touchPos);
        Debug.Log(touchPos);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
