using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallRange : MonoBehaviour
{
    public GameObject force;
    public GameObject wall;
    public Rigidbody[] boxsRigidbody;

    private void Awake()
    {
        boxsRigidbody = GetComponentsInChildren<Rigidbody>();
        EnableKinetic();


    }


    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<NewPlayer>();

        if (player)
        {
            if (NewPlayer.Instance.playerPower >= 15)
            {
                DisableKinetic();
                StartCoroutine(WaitForBreak());

            }
            else
            {

                StartCoroutine(WaitForDeath());

            }

        }
    }

    private IEnumerator WaitForBreak()
    {
        float waitTime = 0.2f;
        NewPlayer.Instance.animStateController.PlayerWall();
        yield return new WaitForSeconds(waitTime);
        force.SetActive(true);
        yield return new WaitForSeconds(waitTime * 2);
        force.SetActive(false);
        yield return new WaitForSeconds(waitTime * 10);
        gameObject.SetActive(false);
        Destroy(wall.gameObject);
    }

    private IEnumerator WaitForDeath()
    {
        float waitTime = 3f;
        yield return new WaitForSeconds(0.2f);
        NewPlayer.Instance.animStateController.PlayerDeath();
        PlayerPunch.Instance.death = true;
        MoveZ.Instance.isMove = false;
        Drag.Instance.enabled = false;
        yield return new WaitForSeconds(waitTime);
        NewPlayer.Instance.RestartLevel();
    }

    private void EnableKinetic()
    {
        foreach (Rigidbody col in boxsRigidbody)
        {
            col.isKinematic = true;
        }
    }
    private void DisableKinetic()
    {
        foreach (Rigidbody col in boxsRigidbody)
        {
            col.isKinematic = false;
        }
    }

}
