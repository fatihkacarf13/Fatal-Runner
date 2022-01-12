using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test2 : MonoBehaviour
{
    float minSize = -0.1f;
    float shrinkageRate = 0.50f;
    float scale = -1.0f;
    bool fight = false;
    bool fightResult;
    bool fightOver;

    private void OnTriggerEnter(Collider other)
    {
        fight = true;
        if (transform.localScale.y <= other.transform.localScale.y)
        {
            fightResult = false;
        }
        else
        {
            fightResult = true;
        }
    }
    void Update()
    {
        if (!fightResult && fight)
        {
            transform.localScale = Vector3.one * scale;
            scale += shrinkageRate * Time.deltaTime;
            if (scale > minSize)
            {
                Destroy(gameObject);
            }
        }
        if (fightResult && fight)
        {
            transform.localScale = Vector3.one * scale;
            scale += shrinkageRate * Time.deltaTime;
            if (scale > minSize)
            {
                fight = false;
            }
        }
        if (fightOver)
        {
            //SceneManager.LoadScene(0);
        }

    }
}