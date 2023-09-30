using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.AR;
using TMPro;

public class LineManager : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] private ARPlacementInteractable placementInteractable;
    [SerializeField] private TextMeshPro mText;
    [SerializeField] private TextMeshProUGUI textButton;
    
    private int pointCount = 0;
    LineRenderer line;
    public bool isContinuous = false;

    private void Start()
    {
        placementInteractable.objectPlaced.AddListener(DrawLine);
    }

    public void ToggleBetweenDiscreteAndContinuous()
    {
        isContinuous = !isContinuous;
        if(isContinuous)
        {
            textButton.text = "Continuous";
        }
        else
        {
            textButton.text = "Discrete";
        }
    }

    void DrawLine(ARObjectPlacementEventArgs args)
    {
        pointCount++;
        if(pointCount < 2)
        {
            line = Instantiate(lineRenderer);
            line.positionCount = 1;
        }
        else
        {
            line.positionCount = pointCount;
            if(!isContinuous)
                pointCount = 0;
        }

        //Set position of the new position xd
        line.SetPosition(line.positionCount - 1, args.placementObject.transform.position);

        if(line.positionCount > 1)
        {
            Vector3 pointA = line.GetPosition(line.positionCount - 1);
            Vector3 pointB = line.GetPosition(line.positionCount - 2);

            float dist = Vector3.Distance(pointA, pointB);

            TextMeshPro distText = Instantiate(mText);
            distText.text = "" + dist;

            //Rotation of the Text
            Vector3 directionVector = pointB - pointA;
            Vector3 normal = args.placementObject.transform.up;
            Vector3 upd = Vector3.Cross(directionVector, normal).normalized;
            Quaternion rotation = Quaternion.LookRotation(-normal, upd);
            distText.transform.rotation = rotation;

            //Position of the Text
            distText.transform.position = (pointA + directionVector * 0.5f) + upd * 0.05f;
        }

    }
}
