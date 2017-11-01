using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public float firingCoolDown;

    public bool canFire;

    public GameObject projectile;
    public GameObject shipTurretPoint;
    public GameObject projectileContainer;
    public ParticleSystem particleEffect;

    private void Start()
    {
        SubscribeToEvents();
    }

    IEnumerator FiringCoolDownWait()
    {
        yield return new WaitForSeconds(firingCoolDown);
        canFire = true;
        yield return null;
    }

    public void PlayerFire()
    {
        if (canFire)
        {
            if (projectile != null)
            {
                Instantiate(projectile, shipTurretPoint.transform.position, Quaternion.Euler(World.o.transform.right), projectileContainer.transform);
                //GameObject pE = Instantiate(particleEffect); ..Ei näin
                //pE.transform.parent = transform;
                //pE.transform.position = shipTurretPoint.transform.position - new Vector3(.4f, 0f, 0f);
                particleEffect.Play(true);

            }

            canFire = false;
            StartCoroutine(FiringCoolDownWait());
        }
    }

    private void SubscribeToEvents()
    {
        PlayerInput.Shoot += PlayerFire;
    }
}
