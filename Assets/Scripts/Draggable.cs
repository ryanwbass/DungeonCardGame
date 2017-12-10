using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

    public Transform parentToReturnTo;
    public Transform placeHolderParent;

    bool returnCardToHand;
    bool isDragginCard;
    bool castSpell;

    GameObject placeHolder = null;
    
    private void Start()
    {
        isDragginCard = false;
        returnCardToHand = false;
        castSpell = false;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && isDragginCard && !returnCardToHand)
        {
            returnCardToHand = true;
            ReturnToParent();
        }
    }

    void ReturnToParent()
    {
        isDragginCard = false;
        returnCardToHand = false;
        castSpell = false;
        this.transform.SetParent(parentToReturnTo);
        this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
        Destroy(placeHolder);
    }

    void SetUpDrag()
    {
        isDragginCard = true;
        castSpell = true;
        placeHolder = new GameObject();
        placeHolder.transform.SetParent(this.transform.parent, true);
        LayoutElement le = placeHolder.AddComponent<LayoutElement>();
        le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleHeight = 0;
        le.flexibleWidth = 0;

        placeHolder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

        parentToReturnTo = this.transform.parent;
        placeHolderParent = parentToReturnTo;
        this.transform.SetParent(this.transform.parent.parent);

        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(GameManager.instance.GetPlayer().GetComponent<Player>().GetCurrentMana() < GetComponent<Card>().GetManaCost())
        {
            returnCardToHand = true;
            return;
        }
        
        SetUpDrag();
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(returnCardToHand)
        {
            if (isDragginCard)
            {
                ReturnToParent();
            }
            return;
        }
        if (isDragginCard)
        {
            this.transform.position = eventData.position;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GetComponent<CanvasGroup>().blocksRaycasts = true;

        
        if (!castSpell)
        {
            returnCardToHand = false;
            return; 
        }
        
        Destroy(placeHolder);
        GetComponent<Card>().PlayCard(eventData.position);
        Destroy(this.gameObject);
        castSpell = false;

    }
}
