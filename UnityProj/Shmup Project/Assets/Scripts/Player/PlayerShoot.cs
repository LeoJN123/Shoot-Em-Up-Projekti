using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

    public float firingCoolDown;

    public bool canFire;

    public GameObject projectile;
    public GameObject shipTurretPoint;
    public GameObject projectileContainer;

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
                Instantiate(projectile, shipTurretPoint.transform.position, Quaternion.identity, projectileContainer.transform);
                
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
