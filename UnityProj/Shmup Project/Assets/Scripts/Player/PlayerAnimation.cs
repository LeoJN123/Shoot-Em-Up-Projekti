using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public GameObject shipGraphics;
    public ParticleSystem muzzleParticle;
    public Animator anim;

    private void Start()
    {
    }

    private void Update()
    {
        UpdateAnimatorValues();
    }

    private void UpdateAnimatorValues()
    {
        anim.SetFloat("XSpeed", PlayerInput.horizontalInput);
        anim.SetFloat("YSpeed", PlayerInput.verticalInput);
    }

    private void Fire()
    {
        muzzleParticle.Play();
    }

    private void SubscribeToEvents()
    {
        PlayerInput.Shoot += Fire;
    }
}
