using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshToggler : MonoBehaviour
{
    
    private bool isActive = true;

    public void MeshToggle()
    {
        isActive = !isActive;
        this.gameObject.SetActive(isActive);
    }
}
