using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupTurret : MonoBehaviour
{
    public Button turretOneButton;
    public GameObject turretOne;
    private GameObject turretFollowing;
    private Camera _cam;

    void Start()
    {
        turretOneButton.onClick.AddListener(delegate {TaskWithParameters(turretOne); });
        _cam = Camera.main;
    }

    void Update()
    {
        if (Globals.isBeingPlaced) {
            turretFollowing.GetComponent<Transform>().position = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) || Input.GetKeyDown(KeyCode.Mouse0)) {
            Globals.isBeingPlaced = false;
            StartCoroutine("ResetGlobals");
            Destroy(turretFollowing, 0.01f);
        }
    }

    void TaskWithParameters(GameObject turret)
    {
        Globals.isBeingPlaced = true;
        turretFollowing = Instantiate(turret, _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10)), Quaternion.identity);
        turretFollowing.name = turret.name;
        Globals.turretSelected = turretFollowing;
    }

    IEnumerator ResetGlobals ()
    {
        yield return new WaitForSeconds(0.01f);
        Globals.turretSelected = null;
        Globals.blockSelected = null;
    }
}
