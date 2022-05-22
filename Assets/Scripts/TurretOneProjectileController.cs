using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurretOneProjectileController : MonoBehaviour
{
    private bool currentlyShooting = false;
    internal float damage = 2f;
    internal float attackSpeed = 0.2f;
    private List<GameObject> enemiesInRange = new List<GameObject>();
    private Transform laserFirePoint;
    private LineRenderer laser;
    private TextMeshProUGUI cashText;

    void Start()
    {
        laserFirePoint = GetComponent<Transform>();
        laser = GetComponent<LineRenderer>();
        laser.sortingOrder = 0;
        laser.material = new Material(Shader.Find("Sprites/Default"));
        laser.material.color = Color.red;
        cashText = GameObject.FindGameObjectWithTag("CashText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!currentlyShooting && enemiesInRange.Count > 0) {
            currentlyShooting = true;
            StartCoroutine(ShootTarget(enemiesInRange[0]));
        }

        if (currentlyShooting) {
            laser.sortingOrder = 50;
            ProjectLaser(laserFirePoint.position, enemiesInRange[0].GetComponent<Transform>().position);
        } else {
            laser.sortingOrder = -1;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy") {
            enemiesInRange.Add(col.gameObject);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy") {
            enemiesInRange.Remove(col.gameObject);
            currentlyShooting = false;
        }
    }

    public void UpgradePathOne(int upgradeNum)
    {
        switch (upgradeNum)
        {
            case 0:
                Debug.Log("First Upgrade Path One logic");
                break;
            case 1:
                Debug.Log("Second Upgrade Logic");
                break;
            case 2:
                Debug.Log("Third..>");
                break;
            case 3:
                Debug.Log("4");
                break;
            case 4:
                Debug.Log("fi5");
                break;
        }
    }
    public void UpgradePathTwo(int upgradeNum)
    {
        switch (upgradeNum)
        {
            case 0:
                Debug.Log("First Upgrade Path Twe logic");
                break;
            case 1:
                Debug.Log("Second Upgrade path two Logic");
                break;
            case 2:
                Debug.Log("Third..>");
                break;
            case 3:
                Debug.Log("4");
                break;
            case 4:
                Debug.Log("fi5");
                break;
        }
    }
    public void UpgradePathThree(int upgradeNum)
    {
        switch (upgradeNum)
        {
            case 0:
                Debug.Log("First Upgrade Path Three logic");
                break;
            case 1:
                Debug.Log("Second Upgrade path tre3 Logic");
                break;
            case 2:
                Debug.Log("Third..>");
                break;
            case 3:
                Debug.Log("4");
                break;
            case 4:
                Debug.Log("fi5");
                break;
        }
    }

    IEnumerator ShootTarget(GameObject target)
    {
        if (enemiesInRange.Contains(target)) {
            Globals.SetEnemyHealth(target.gameObject, damage);
            CheckIfDead(target.gameObject);
        }
        yield return new WaitForSeconds(attackSpeed);
        if (enemiesInRange.Contains(target)) {
            StartCoroutine(ShootTarget(target));
        } else {
            ProjectLaser(Vector3.zero, Vector3.zero);
        }
    }
    private void CheckIfDead(GameObject enemy)
    {
        if (enemy.GetComponent<EnemyController>().health <= 0) {
            ProjectLaser(Vector3.zero, Vector3.zero);
            Globals.cash += enemy.GetComponent<EnemyController>().cashToEarn;
            cashText.text = "Cash: " + Globals.cash.ToString();
            Destroy(enemy);
        }
    }

    private void ProjectLaser(Vector2 startPos, Vector2 endPos)
    {
        laser.SetPosition(0, startPos);
        laser.SetPosition(1, endPos);
    }
}
