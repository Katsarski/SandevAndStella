using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    private Rigidbody projectile;
    [SerializeField]
    private Transform weaponMountPoint;
    [SerializeField]
    private float fireForce = 300f;

    void Awake()
    {
        GetComponent<ShipInput>().OnFire += HandleFire;
    }
    private void HandleFire()
    {
        var spawnedProjectile = Instantiate(projectile, weaponMountPoint.position, weaponMountPoint.rotation);
        spawnedProjectile.AddForce(spawnedProjectile.transform.forward * fireForce);
    }

}
