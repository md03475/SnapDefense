using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable2 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject thisObject;

    public static GameObject itemBeingDragged;

    public Vector3 respawnPosition;

    private CanvasGroup canvasGroup;

    public Transform startParent;

    //public bool enable = false;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("OnBeginDrag");
        itemBeingDragged = gameObject;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        respawnPosition = transform.position;
        startParent = transform.parent;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("OnDrag");
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        itemBeingDragged = null;
        if (transform.parent == startParent)
        {
            transform.position = respawnPosition;
        }
        else if (transform.parent != startParent)
        {
            GameObject duplicate = Instantiate(thisObject);
            duplicate.transform.position = respawnPosition;
            duplicate.transform.parent = startParent;
        }
    }
}
