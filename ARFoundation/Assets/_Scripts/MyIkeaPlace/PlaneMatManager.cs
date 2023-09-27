using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneMatManager : MonoBehaviour
{
    public Material planeMat;

    public Button[] planeTexButtons;

    private void Awake()
    {
        foreach (var item in planeTexButtons)
        {
            Texture tex = item.transform.Find("Mask/RawImage").GetComponent<RawImage>().texture;
            item.onClick.AddListener(()=>OnClickButton(tex));
        }
    }

    private void OnClickButton(Texture tex)
    {
        planeMat.mainTexture = tex;
    }
}
