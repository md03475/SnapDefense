using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LoadoutSlot : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        //if (eventData.pointerDrag != null)
        //{
        //    eventData.pointerDrag.transform.position = this.transform.position;
        //}

        //if (!item)
        //{

        Draggable2.itemBeingDragged.transform.SetParent(transform);
        Draggable2.itemBeingDragged.transform.position = this.transform.position;
        if (transform.childCount > 1)
        {
            Destroy(transform.GetChild(0).gameObject);
        }
        //}
    }
}
