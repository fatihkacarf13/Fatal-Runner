using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossJumpScore : MonoBehaviour
{
    private int _bossScore = 1;
    private int _range = 3;
    [SerializeField] private GameObject _jumpScorePlatform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JumpScore"))
        {
            _bossScore++;
            CreateNewJumpPlatform(_bossScore);
        }
    }


    private void CreateNewJumpPlatform(int value)
    {
        var nextLoc = new Vector3(_jumpScorePlatform.transform.position.x, _jumpScorePlatform.transform.position.y, _jumpScorePlatform.transform.position.z+ _range);
        _range += 3;
        var tmp = Instantiate(_jumpScorePlatform, nextLoc, Quaternion.identity).GetComponentInChildren<TextMeshPro>();
        tmp.text = value.ToString()+"x";
    }
    
    //private void ChangeColor()
    //{
    //    _jumpScorePlatform.GetComponentInChildren<MeshRenderer>()

    //}
}
