using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurretController : MonoBehaviour
{

    public SpriteRenderer rangeDisplay;
    public GameObject upgradeButtonManager;
    public int turretPrice;
    public int sellValue;
    public int[] pathOneUpgradeCosts = new int[5];
    public int[] pathTwoUpgradeCosts = new int[5];
    public int[] pathThreeUpgradeCosts = new int[5];
    internal int pathOnePosition = 0;
    internal int pathTwoPosition = 0;
    internal int pathThreePosition = 0;

    void Start()
    {
        sellValue = Globals.UpdateSellValue(0, turretPrice);
    }

    void Update()
    {
        if (this.gameObject == Globals.turretSelected || this.gameObject == Globals.turretBeingUpgraded) {
            rangeDisplay.enabled = true;
        } else {
            rangeDisplay.enabled = false;
            upgradeButtonManager.SetActive(true);
        }
    }

    public void UpgradeOne ()
    {
        if (Globals.TryToBuy(pathOneUpgradeCosts[pathOnePosition])) {
            Globals.cash -= pathOneUpgradeCosts[pathOnePosition];
            sellValue = Globals.UpdateSellValue(sellValue, pathOneUpgradeCosts[pathOnePosition]);
            switch (Globals.turretBeingUpgraded.name)
            {
                case "LaserTurret":
                    Globals.turretBeingUpgraded.GetComponent<TurretOneProjectileController>().UpgradePathOne(pathOnePosition);
                    break;
            }
            pathOnePosition++;
        } else {
            Debug.Log("Not enough moolah!");
        }
    }
    public void UpgradeTwo ()
    {
        if (Globals.TryToBuy(pathTwoUpgradeCosts[pathTwoPosition])) {
            Globals.cash -= pathTwoUpgradeCosts[pathTwoPosition];
            sellValue = Globals.UpdateSellValue(sellValue, pathTwoUpgradeCosts[pathTwoPosition]);
            switch (Globals.turretBeingUpgraded.name)
            {
                case "LaserTurret":
                    Globals.turretBeingUpgraded.GetComponent<TurretOneProjectileController>().UpgradePathTwo(pathTwoPosition);
                    break;
            }
            pathTwoPosition++;
        } else {
            Debug.Log("Not enough monays!");
        }
    }
    public void UpgradeThree ()
    {
        if (Globals.TryToBuy(pathThreeUpgradeCosts[pathThreePosition])) {
            Globals.cash -= pathThreeUpgradeCosts[pathThreePosition];
            sellValue = Globals.UpdateSellValue(sellValue, pathThreeUpgradeCosts[pathThreePosition]);
            switch (Globals.turretBeingUpgraded.name)
            {
                case "LaserTurret":
                    Globals.turretBeingUpgraded.GetComponent<TurretOneProjectileController>().UpgradePathThree(pathThreePosition);
                    break;
            }
            pathThreePosition++;
        } else {
            Debug.Log("no dola dolla found!");
        }
    }
}
