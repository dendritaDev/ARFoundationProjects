using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    private Button button;
    [SerializeField] private RawImage buttonImage;


    private int itemId;
    private Sprite buttonTexture;

    public int ItemId { get => itemId; set => itemId = value; }
    public Sprite ButtonTexture { get => buttonTexture; 
        set 
        { 
            buttonTexture = value;
            buttonImage.texture = buttonTexture.texture;
        } 
    }

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectObject);
    }

    private void Update()
    {
        if(UIManagerIkea.Instance.OnEntered(gameObject))
        {
            transform.DOScale(Vector3.one * 1.8f, 0.3f);
        }
        else
        {
            transform.DOScale(Vector3.one, 0.3f);
            
        }
    }

    private void SelectObject()
    {
        DataHandler.Instance.SetFurniture(ItemId);
    }
}
