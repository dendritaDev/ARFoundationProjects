using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameObject furniture;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SelectObject);
    }

    private void SelectObject()
    {
        DataHandler.Instance.furniture = furniture;
    }
}
