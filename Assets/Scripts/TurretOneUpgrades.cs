using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretOneUpgrades : MonoBehaviour
{
    private TurretOneProjectileController projectiles;
    void Start()
    {
        projectiles = this.gameObject.GetComponent<TurretOneProjectileController>();
    }
    

}
