using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }







}
