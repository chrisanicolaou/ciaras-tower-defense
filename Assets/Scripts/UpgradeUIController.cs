using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class UpgradeUIController : MonoBehaviour
{

    public GameObject UIDisplay;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            foreach (var hit in hits)
            {
                if (hit.collider != null) {              
                    var hitObj = hit.collider.gameObject;

                    if (hitObj.tag == "Upgrade") {
                        Globals.turretBeingUpgraded = hitObj.transform.parent.gameObject;
                    }
                } 
            }
        } 

        if (Globals.turretBeingUpgraded != null) {
            UIDisplay.SetActive(true);
        } else {
            UIDisplay.SetActive(false);
        }
    }
}
