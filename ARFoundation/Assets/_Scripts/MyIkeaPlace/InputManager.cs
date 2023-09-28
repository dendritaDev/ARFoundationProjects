using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class InputManager : ARBaseGestureInteractable
{

    [SerializeField] private Camera ARCamera;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject crossHair;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Touch touch;
    private Pose pose;

    protected override bool CanStartManipulationForGesture(TapGesture gesture)
    {
        //si no colissiona con nada
        if (gesture.TargetObject == null)
            return true;
        return false;
    }

    protected override void OnEndManipulation(TapGesture gesture)
    {
        if (gesture.WasCancelled)
            return;

        
        if (gesture.targetObject != null || IsPointerOverUI(gesture))
            return;

        if (GestureTransformationUtility.Raycast(gesture.startPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            GameObject placedObj = Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation);

            var anchorObject = new GameObject("PlacementAnchor");
            anchorObject.transform.position = pose.position;
            anchorObject.transform.rotation = pose.rotation;
            placedObj.transform.parent = anchorObject.transform;
        }


    }

    private void FixedUpdate()
    {
        CrossHairCalculation();
        //Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation);
    }

    /// <summary>
    /// Miramos si de los touch a la pantalla que hace el usuario, alguno choca con la UI, y por tanto, quiere decir que estaba pulsando UI y no que tenía la itnencionde spawnear muebles. Por tanto,
    /// de ser así, devolvemos true y se hace return en el update
    /// </summary>
    /// <param name="touch"> touch en la pantalla del cual cogemos su posicion para saber si choca con alguna UI</param>
    /// <returns></returns>
    bool IsPointerOverUI(TapGesture touch)
    {
        
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.startPosition.x, touch.startPosition.y);
        
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }


    void CrossHairCalculation()
    {
        //Centro de la pantalla
        Vector3 origin = ARCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));

        if (GestureTransformationUtility.Raycast(origin, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            //Pose:  Representation of a Position and rotation of an object
            pose = hits[0].pose;
            crossHair.transform.position = pose.position;
            crossHair.transform.eulerAngles = new Vector3(90, 0, 0); //lo alineamos con el plano
        }
    }
}
