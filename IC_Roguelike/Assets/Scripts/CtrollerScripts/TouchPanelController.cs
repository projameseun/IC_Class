using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchPanelController : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    public GameObject playerObject;
    Vector2 touchPos;

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 worldPoint = Input.mousePosition;
        worldPoint = Camera.main.ScreenToWorldPoint(worldPoint);

        Vector2 diffPos = worldPoint - touchPos;

        touchPos = Input.mousePosition;
        touchPos = Camera.main.ScreenToWorldPoint(touchPos);

        playerObject.transform.position = new Vector2(playerObject.transform.position.x + diffPos.x,
                                                        playerObject.transform.position.y + diffPos.y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        touchPos = Input.mousePosition;
        touchPos = Camera.main.ScreenToWorldPoint(touchPos);

        //Debug.Log("touchPos : " + touchPos);
    }
}
