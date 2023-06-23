using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    private PlayerMove _playerMove;

    public ParticleSystem dustEffect;

    private void Start()
    {
        _playerMove = gameObject.GetComponent<PlayerMove>();
    }

    private void LateUpdate()
    {
        StartSmoke();
        StopSmoke();
    }

    private void StartSmoke()
    {
        if (_playerMove.playPauseSmoke)
        {
            // var dustEffectMain = dustEffect.main;
            // dustEffectMain.startSpeed = _playerMove.GetComponent<Rigidbody>().velocity.magnitude;
            dustEffect.Play();
        }
    }

    private void StopSmoke()
    {
        if (!_playerMove.playPauseSmoke)
        {
            dustEffect.Stop();
        }
    }
}