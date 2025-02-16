using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Transform originSlot;
    CanvasGroup canvasGroup;


    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originSlot = transform.parent;
        transform.SetParent(transform.root);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //seguir el mouse
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //hacer clickeable de nuevo
        canvasGroup.blocksRaycasts = true;

        canvasGroup.alpha = 1f;

        Slot dropSlot = eventData.pointerEnter?.GetComponent<Slot>();

        //esto es porque si hay un objeto no podemos hacer click sobre el slot directamente, hay que acceder a él a través del item
        if(dropSlot == null)
        {
            GameObject dropItem = eventData.pointerEnter;
            if (dropItem != null)
            {
                dropSlot = dropItem.GetComponentInParent<Slot>();
            }
        }


        Slot prevSlot = originSlot.GetComponent<Slot>();

        if (dropSlot != null)
        {
            //si ya hay un item hacemos swap
            if (dropSlot.currentItem != null)
            {
                dropSlot.currentItem.transform.SetParent(prevSlot.transform);
                prevSlot.currentItem = dropSlot.currentItem;
                dropSlot.currentItem.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            }
            
            //slot vacío
            else
            {
                prevSlot.currentItem = null;
            }

            //mover el item
            transform.SetParent(dropSlot.transform);
            dropSlot.currentItem = gameObject;
        }

        //si lo suelta fuera de un slot
        else
        {
            //reculamos
            transform.SetParent(originSlot);
        }

        //centrar
        GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

    }

    

   
}
