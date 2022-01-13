using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] private MoveZ _moveZ;
    bool bossDeath = false;
    [SerializeField] private NewPlayer _player;

    private void Awake()
    {
        _moveZ = FindObjectOfType<MoveZ>();
        _player = FindObjectOfType<NewPlayer>();
    }
    public void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<NewPlayer>();

        if (player)
        {
            _moveZ.isMove = false;

            if (player.transform.localScale.y >= transform.localScale.y)
            {
                bossDeath = true;
                player.Score += 20;


            }
            else
            {
                player.Score = 0;
                Destroy(player.gameObject);
                player.RestartLevel();
            }
        }

        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

    }

    void Update()
    {
        if (bossDeath)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 10);
        }
    }

    //public void OnDisable()
    //{
    //    _player.NextLevel();
    //}

}
