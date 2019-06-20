using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private ILauncher launcher;
    // Start is called before the first frame update
    [SerializeField]
    private float fireRefreshRate = 1f;
    private float nextFireTime;
    void Awake()
    {
        launcher = GetComponent<ILauncher>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CanFire() && Input.GetButtonDown("Fire1"))
        {
            FireWeapon();
        }
    }

    private bool CanFire()
    {
        return Time.time >= nextFireTime;
    }

    private void FireWeapon()
    {
        nextFireTime = Time.time + fireRefreshRate;
        launcher.Launch(this);
    }
}
