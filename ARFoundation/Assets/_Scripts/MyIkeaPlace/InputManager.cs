using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{

    [SerializeField] private Camera ARCamera;
    [SerializeField] private ARRaycastManager raycastManager;

    List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = ARCamera.ScreenPointToRay(Input.mousePosition);

            if(raycastManager.Raycast(ray, hits))
            {
                //Pose:  Representation of a Position and rotation of an object
                Pose pose = hits[0].pose;
                Instantiate(DataHandler.Instance.furniture, pose.position, pose.rotation);
            }
        }
    }
}
