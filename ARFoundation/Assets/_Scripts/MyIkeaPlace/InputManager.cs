using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{

    [SerializeField] private Camera ARCamera;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject crossHair;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private Touch touch;
    private Pose pose;

    private void Update()
    {
        CrossHairCalculation();

        touch = Input.GetTouch(0);

        if (Input.touchCount < 0 || touch.phase != TouchPhase.Began)
            return;

        if (IsPointerOverUI(touch))
            return;


        Instantiate(DataHandler.Instance.GetFurniture(), pose.position, pose.rotation);
    }

    /// <summary>
    /// Miramos si de los touch a la pantalla que hace el usuario, alguno choca con la UI, y por tanto, quiere decir que estaba pulsando UI y no que tenía la itnencionde spawnear muebles. Por tanto,
    /// de ser así, devolvemos true y se hace return en el update
    /// </summary>
    /// <param name="touch"> touch en la pantalla del cual cogemos su posicion para saber si choca con alguna UI</param>
    /// <returns></returns>
    bool IsPointerOverUI(Touch touch)
    {
        
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = new Vector2(touch.position.x, touch.position.y);
        
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);

        return results.Count > 0;
    }


    void CrossHairCalculation()
    {
        //Centro de la pantalla
        Vector3 origin = ARCamera.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));

        //Spawn Furniture
        Ray ray = ARCamera.ScreenPointToRay(origin); //rayo al centro de la pantalla
        if (raycastManager.Raycast(ray, hits))
        {
            //Pose:  Representation of a Position and rotation of an object
            pose = hits[0].pose;
            crossHair.transform.position = pose.position;
            crossHair.transform.eulerAngles = new Vector3(90, 0, 0); //lo alineamos con el plano
        }
    }
}
