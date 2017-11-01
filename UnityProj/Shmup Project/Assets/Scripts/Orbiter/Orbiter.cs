using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrbiterLevel { BetaOrbiter, AlphaOrbiter };

public class Orbiter : MonoBehaviour {

    public GameObject parentPlayer;

    public Vector3 orbiterOffset;
    public Vector3 orbiterRotation;
    [Space(5)]
    [Tooltip("Level of the Orbiter")]
    public OrbiterLevel OrbiterLev = OrbiterLevel.BetaOrbiter;

    public float firingCoolDown;
    public bool canFire;
    public GameObject projectile;
    public GameObject projectileContainer;


    private void Awake()
    {
        SubscribeToEvents();
        parentPlayer = GameObject.Find("Player");
        //transform.parent = parentPlayer.transform.Find("Orbiter Container");
        //transform.localPosition = orbiterOffset;
    }

    private void Update()
    {
        HandlePositions();
    }

    private void HandlePositions()
    {
        //transform.rotation = Quaternion.LookRotation(-(parentPlayer.transform.up), parentPlayer.transform.up);

        //transform.position = parentPlayer.transform.position + orbiterOffset;

        transform.eulerAngles = orbiterRotation;
    }

    IEnumerator FiringCoolDownWait()
    {
        yield return new WaitForSeconds(firingCoolDown);
        canFire = true;
        yield return null;
    }

    private void FireGun()
    {
        if (canFire)
        {
            if (projectile != null)
            {
                Instantiate(projectile, transform.position, Quaternion.Euler(World.o.transform.right), projectileContainer.transform);

            }

            canFire = false;
            StartCoroutine(FiringCoolDownWait());
        }
    }

    private void SubscribeToEvents()
    {
        PlayerInput.Shoot += FireGun;
    }
}
