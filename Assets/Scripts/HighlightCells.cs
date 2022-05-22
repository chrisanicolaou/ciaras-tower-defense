using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighlightCells : MonoBehaviour
{
    private SpriteRenderer cell;
    private Color red = new Color(1f, 0f, 0f, 0.3f);
    private Color green = new Color(0f, 1f, 0f, 0.3f);
    private Color transparent = new Color(0f,0f,0f,0f);
    private bool isSelected = false;
    private TextMeshProUGUI cashText;

    void Start()
    {
        cell = GetComponent<SpriteRenderer>();
        cashText = GameObject.FindGameObjectWithTag("CashText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (isSelected && Input.GetKeyDown(KeyCode.Mouse0) && this.gameObject == Globals.blockSelected) {
            var turretCash = Globals.turretSelected.GetComponent<TurretController>().turretPrice;
            if (Globals.cash >= turretCash) {
                Globals.cash -= turretCash;
                cashText.text = "Cash: " + Globals.cash.ToString();
                cell.color = transparent;
                Globals.turretSelected.GetComponent<CircleCollider2D>().enabled = true;
                var newTurret = Instantiate(Globals.turretSelected, Globals.blockSelected.transform.position, Quaternion.identity, this.gameObject.transform);
                newTurret.name = Globals.turretSelected.name;
                isSelected = false;
                Globals.turretSelected = null;
                Globals.blockSelected = null;
            } else {
                isSelected = false;
                Globals.turretSelected = null;
                Globals.blockSelected = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)) {
            cell.color = transparent;
        }

        if (this.gameObject.transform.childCount != 0) {
            this.gameObject.tag = "TurretOnNode";
        }

        if (this.gameObject.transform.childCount == 0 && this.gameObject.tag == "TurretOnNode") {
            this.gameObject.tag = "TurretSpace";
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (Globals.isBeingPlaced && col.gameObject.tag == "Turret") {
            if (this.gameObject.tag == "TurretSpace" && col.gameObject.GetComponent<TurretController>().turretPrice <= Globals.cash) {
                Globals.blockSelected = this.gameObject;
                cell.color = green;
                isSelected = true;
            } else {
                cell.color = red;
                isSelected = false;
            }
        }
    }
    void OnTriggerStay2D(Collider2D col)
    {
        if (Globals.isBeingPlaced && col.gameObject.tag == "Turret") {
            if (this.gameObject.tag == "TurretSpace" && col.gameObject.GetComponent<TurretController>().turretPrice <= Globals.cash) {
                Globals.blockSelected = this.gameObject;
                cell.color = green;
                isSelected = true;
            } else {
                cell.color = red;
                isSelected = false;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        cell.color = transparent;
        StartCoroutine("Deselect");
    }

    IEnumerator Deselect()
    {
        yield return new WaitForSeconds(0f);
        isSelected = false;
    }
}
