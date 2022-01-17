using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPunch : MonoBehaviour
{
    [SerializeField] private Drag _drag;
    [SerializeField] private NewPlayer _player;
    [SerializeField] private AnimationStateController _animStateController;

    void Start()
    {
        _player = FindObjectOfType<NewPlayer>();
        _drag = _player.GetComponent<Drag>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            EnablePunch();
        }
    }

    private void EnablePunch()
    {
        if (_drag.enabled==false)
        {
            _animStateController.Punch();
        }
    }
}
