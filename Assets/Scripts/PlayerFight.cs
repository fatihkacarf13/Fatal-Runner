using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    [SerializeField] private NewPlayer _player;
    float minSize = -0.1f;
    float shrinkageRate = 0.5f;
    public float scale = -1f;
    bool fight = false;
    bool fightResult;
    bool fightOver;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Boss"))
        {
            fight = true;
            if (transform.localScale.y > other.transform.localScale.y)
            {
                fightResult = true;
            }
            else
            {
                fightResult = false;
            }
        }

    }
    void Update()
    {
        
        if (!fightResult && fight)
        {
            transform.position = new Vector3(transform.position.x, -1f * scale, transform.position.z);
            transform.localScale = Vector3.one * scale;
            scale += shrinkageRate * Time.deltaTime;
            if (scale > minSize)
            {
                Destroy(gameObject);
            }
        }
        if (fightResult && fight)
        {
            transform.position = new Vector3(transform.position.x, -1f * scale, transform.position.z);
            transform.localScale = Vector3.one * scale;
            scale += shrinkageRate * Time.deltaTime;
            if (scale > minSize)
            {
                fight = false;
            }
        }


    }

    private void OnDisable()
    {
        _player.RestartLevel();

    }
}