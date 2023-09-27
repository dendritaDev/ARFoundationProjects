using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public Vector3 rotationVector;
    public PlanetsData planetsData;

    private void Start()
    {
        Renderer renderer = this.GetComponent<Renderer>();

        renderer.material.SetTexture("_MainTex", planetsData.texture);
    }


    private void Update()
    {
        Vector3 rotation = rotationVector * Time.deltaTime;

        transform.Rotate(rotation);
    }
}
