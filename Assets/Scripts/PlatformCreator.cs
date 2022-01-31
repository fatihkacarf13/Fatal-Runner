using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    private Renderer renderer;
    private Color defaultColor;

    private void Awake()
    {
        renderer = transform.GetChild(0).GetComponent<Renderer>();
        defaultColor = renderer.material.color;
        renderer.material.color = Color.gray*0.75f;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            renderer.material.color = defaultColor;
        }
    }







}
