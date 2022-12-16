using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardScr : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Camera MainCamera;
    Vector3 Offset;
    public Transform DefaultParent;
    public Transform DefaultTempCardParent;
    GameObject TempCardGO;

    void Awake()
    {
        MainCamera= Camera.allCameras[0];
        TempCardGO = GameObject.Find("TempCardGO");
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
        DefaultParent = DefaultTempCardParent = transform.parent;
        TempCardGO.transform.SetParent(DefaultParent);
        TempCardGO.transform.SetSiblingIndex(transform.GetSiblingIndex());
        transform.SetParent(DefaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);
        newPos.z = 0;
        transform.position = newPos + Offset;

        if (TempCardGO.transform.parent != DefaultTempCardParent)
        {
            TempCardGO.transform.SetParent(DefaultTempCardParent);
        }

        CheckPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(DefaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.SetSiblingIndex(TempCardGO.transform.GetSiblingIndex());
        TempCardGO.transform.SetParent(GameObject.Find("BG").transform);
        TempCardGO.transform.localPosition = new Vector3(2000, -600);
    }

    void CheckPosition()
    {
        int newIndex = DefaultTempCardParent.childCount;

        for (int i = 0; i < DefaultTempCardParent.childCount; i++)
        {
            if (transform.position.x < DefaultTempCardParent.GetChild(i).position.x)
            {
                newIndex = i;

                if (TempCardGO.transform.GetSiblingIndex() < newIndex)
                    newIndex--;
                break;
            }
        }

        TempCardGO.transform.SetSiblingIndex(newIndex);
    }
}
