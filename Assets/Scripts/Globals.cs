using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static int waveNum = 0;
    public static int lives = 10;
    public static float resellMultiplier = 0.5f;
    public static bool isBeingPlaced = false;
    public static bool isMidRound = false;
    public static bool isGoingFast = false;

    public static int cash = 1000;

    #nullable enable
    public static GameObject? turretSelected;
    public static GameObject? blockSelected;
    public static GameObject? turretBeingUpgraded;

    public static void SetEnemyHealth(GameObject target, float amount)
    {
        target.GetComponent<EnemyController>().health -= amount;
    }

    public static bool TryToBuy(int amount)
    {
        if (amount <= Globals.cash) {
            return true;
        } else {
            return false;
        }
    }

    public static int UpdateSellValue(int sellValue, int amount)
    {
        return sellValue + Mathf.FloorToInt((float)amount * Globals.resellMultiplier);
    }
}
