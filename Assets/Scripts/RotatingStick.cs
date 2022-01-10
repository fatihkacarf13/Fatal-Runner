using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotatingStick : MonoBehaviour
{
    public int speed;
    void Update()
    {
        transform.Rotate(new Vector3(0, speed, 0)*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider col)
    {
        var player = col.GetComponent<NewPlayer>();
        if (player)
        {
            Destroy(col.gameObject);
        }
    }
}
