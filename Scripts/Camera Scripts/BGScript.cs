using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScript : MonoBehaviour
{
    private Renderer renderer;
    private float mainTextureOffsetX = -0.00006f;
    [HideInInspector]
    public bool isScrollMaterialBG;
    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
    }
    void Update()
    {

        if (isScrollMaterialBG)
        {
            renderer.material.mainTextureOffset -= new Vector2(mainTextureOffsetX, 0);
        }
    }
}
