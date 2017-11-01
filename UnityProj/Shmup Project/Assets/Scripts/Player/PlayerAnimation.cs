using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    public GameObject shipGraphics;
    public ParticleSystem muzzleParticle;
    public Animator anim;
	public Transform Jet;

	float jetScale;
	float zScale = 0f;

	public float tailLength = 1f;



    private void Start()
    {
		jetScale = Jet.localScale.z;

    }

    private void Update()
    {
        UpdateAnimatorValues();


		Vector3 inputDirection = new Vector3(PlayerInput.horizontalInput, PlayerInput.verticalInput, 0).normalized;
		Vector3 localInputDirection = transform.InverseTransformDirection(inputDirection);
		Vector3 globalInputDirection = World.o.transform.TransformDirection(localInputDirection);

		float value = globalInputDirection.x;

		zScale += (value - zScale) * 3 * Time.deltaTime;
        
		Jet.localScale = new Vector3 (Jet.localScale.x, Jet.localScale.y, Mathf.Max (.5f,jetScale * (1 + zScale*tailLength)));

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
