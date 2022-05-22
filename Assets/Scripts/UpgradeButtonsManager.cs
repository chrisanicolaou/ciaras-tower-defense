using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeButtonsManager : MonoBehaviour
{
    
    public TextMeshProUGUI sellText, upgradePathOneText, upgradePathTwoText, upgradePathThreeText;
    public GameObject upgradeOneButton, upgradeTwoButton, upgradeThreeButton;
    public GameObject UIDisplay;
    private bool isDisplayOn = false;

    #nullable enable
    private GameObject? selectedTurret = null;
    
    void Update()
    {
        if (UIDisplay.activeInHierarchy && !isDisplayOn) {
            UpdateTexts();
            isDisplayOn = true;
        }

        if (!UIDisplay.activeInHierarchy && isDisplayOn) {
            isDisplayOn = false;
        }

        if (Globals.turretBeingUpgraded != selectedTurret && Globals.turretBeingUpgraded != null) {
            selectedTurret = Globals.turretBeingUpgraded;
            var thisTurret = Globals.turretBeingUpgraded.GetComponent<TurretController>();
            if (thisTurret.pathOnePosition >= 3) {
                upgradeTwoButton.SetActive(false);
                upgradeThreeButton.SetActive(false);
            } else if (thisTurret.pathTwoPosition >= 3) {
                upgradeOneButton.SetActive(false);
                upgradeThreeButton.SetActive(false);
            } else if (thisTurret.pathThreePosition >= 3) {
                upgradeOneButton.SetActive(false);
                upgradeTwoButton.SetActive(false);
            } else {
                upgradeOneButton.SetActive(true);
                upgradeTwoButton.SetActive(true);
                upgradeThreeButton.SetActive(true);
            }
            UpdateTexts();
        }

    }
        public void UpgradeOne()
    {
        if (Globals.turretBeingUpgraded != null) {
            var thisTurret = Globals.turretBeingUpgraded.GetComponent<TurretController>();
            thisTurret.UpgradeOne();
            if (thisTurret.pathOnePosition >= 3) {
                upgradeTwoButton.SetActive(false);
                upgradeThreeButton.SetActive(false);
            } else {
                upgradeTwoButton.SetActive(true);
                upgradeThreeButton.SetActive(true);
            }
            UpdateTexts();
        }
    }
    public void UpgradeTwo()
    {
        if (Globals.turretBeingUpgraded != null) {
            var thisTurret = Globals.turretBeingUpgraded.GetComponent<TurretController>();
            thisTurret.UpgradeTwo();
            if (thisTurret.pathTwoPosition >= 3) {
                upgradeOneButton.SetActive(false);
                upgradeThreeButton.SetActive(false);
            } else {
                upgradeOneButton.SetActive(true);
                upgradeThreeButton.SetActive(true);
            }
            UpdateTexts();
        }
    }
    public void UpgradeThree()
    {
        if (Globals.turretBeingUpgraded != null) {
            var thisTurret = Globals.turretBeingUpgraded.GetComponent<TurretController>();
            thisTurret.UpgradeThree();
            if (thisTurret.pathThreePosition >= 3) {
                upgradeOneButton.SetActive(false);
                upgradeTwoButton.SetActive(false);
            } else {
                upgradeOneButton.SetActive(true);
                upgradeTwoButton.SetActive(true);
            }
            UpdateTexts();
        }
    }

    public void ExitUpgrade()
    {
        Globals.turretBeingUpgraded = null;
    }

    public void SellTurret()
    {
        if (Globals.turretBeingUpgraded != null) {
            Globals.cash += Globals.turretBeingUpgraded.GetComponent<TurretController>().sellValue;
            Destroy(Globals.turretBeingUpgraded);
            Globals.turretBeingUpgraded = null;
        }
    }

    public void UpdateTexts()
    {
        if (Globals.turretBeingUpgraded != null) {
            var currentTurret = Globals.turretBeingUpgraded.GetComponent<TurretController>();
            sellText.text = currentTurret.sellValue.ToString();
            upgradePathOneText.text = currentTurret.pathOneUpgradeCosts[currentTurret.pathOnePosition].ToString();
            upgradePathTwoText.text = currentTurret.pathTwoUpgradeCosts[currentTurret.pathTwoPosition].ToString();
            upgradePathThreeText.text = currentTurret.pathThreeUpgradeCosts[currentTurret.pathThreePosition].ToString();
        }
    }
}
