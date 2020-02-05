using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPlatform : Platform
{
    private Animator _animator;

    protected override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.Play("FanPlatform");
            GameMgr.instance.player.PlayerJump();
        }
    }
}
