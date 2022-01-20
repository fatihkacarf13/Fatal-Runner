using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed;
    public float z;
    public bool _rotated = false;
    public float coolDown;



    private void Update()
    {
        if (!_rotated)
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, z), Time.deltaTime * speed);
            StartCoroutine(WaitForRotate(coolDown));
        }
        else
        {
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(0, 0, 0), Time.deltaTime * speed);
            StartCoroutine(ResetRotate(coolDown));
        }
    }

    private IEnumerator WaitForRotate(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _rotated = true;
    }
    private IEnumerator ResetRotate(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _rotated = false;
    }
}