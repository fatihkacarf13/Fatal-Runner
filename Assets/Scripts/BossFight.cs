using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    [SerializeField] private MoveZ _moveZ;
    [SerializeField] private NewPlayer _player;
    float minSize = -0.1f;
    float shrinkageRate = 0.5f;
    public float scale =-2f ;
    bool fight = false;
    bool fightResult;


    private void Awake()
    {
        _moveZ = FindObjectOfType<MoveZ>();
        
    }
    public void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<NewPlayer>();

        if (player)
        {
            _moveZ.isMove = false;
            fight = true;
            if (transform.localScale.y <= player.transform.localScale.y)
            {
                fightResult = false;
            }
            else
            {
                fightResult = true;
            }
        }



    }

    void FixedUpdate()
    {
        
        if (!fightResult && fight)
        {
            transform.position = new Vector3(transform.position.x,  -1f*scale, transform.position.z);
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


}
