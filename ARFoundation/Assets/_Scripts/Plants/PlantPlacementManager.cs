using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using DG.Tweening;

public class PlantPlacementManager : MonoBehaviour
{
    [Header(" Elements ")]
    public GameObject[] flowers;

    [Header(" AR ")]

    [SerializeField] private ARSessionOrigin sessionOrigin;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private ARPlaneManager planeManager;

    private List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    private void Update()
    {
        if(Input.touchCount < 1)
            return;

        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            bool collision = raycastManager.Raycast(Input.mousePosition, raycastHits, TrackableType.PlaneWithinPolygon);

            if(collision)
            {
                GameObject _object = Instantiate(flowers[Random.Range(0, 3/*flowers.Length - 1*/)]);
                _object.transform.position = raycastHits[0].pose.position;
                _object.transform.DOScale(0f, 0f);
                _object.transform.DOScale(0.5f, 1.25f).SetEase(Ease.InBounce);
            }

            planeManager.enabled = false;
        }

        
    }
}
