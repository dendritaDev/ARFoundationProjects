using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManagerIkea : MonoBehaviour
{
    private GraphicRaycaster raycaster;
    PointerEventData pData;
    EventSystem eventSystem;

    [SerializeField] private Transform selectionCenterPoint;

    public static UIManagerIkea instance;

    public static UIManagerIkea Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIManagerIkea>();
            }
            return instance;
        }
    }


    void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();        
        eventSystem = GetComponent<EventSystem>();
        pData = new PointerEventData(eventSystem);

        pData.position = selectionCenterPoint.position;
    }

    void Update()
    {
        
    }

    /// <summary>
    /// Le pasamos un botón para que nos compruebe si ese botón esta siendo pulsado por el raycast que lanzamos desde el punto central del scroll donde tenemos los botones
    /// </summary>
    /// <param name="button"></param>
    /// <returns></returns>
    public bool OnEntered(GameObject button)
    {
        List<RaycastResult> results = new List<RaycastResult>();

        raycaster.Raycast(pData, results);

        foreach (var result in results)
        {
            if(result.gameObject == button)
            {
                return true;
            }
        }
        return false;
    }
}
