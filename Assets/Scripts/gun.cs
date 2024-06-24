using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public float damage = 20f;
    public float range = 15f;
    
    public float gunShotRadius = 15f;
    public LayerMask enemyLayerMask;

    public Camera playerCam;
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        
        //shot radius
        Collider[] enemyColliders;
        enemyColliders = Physics.OverlapSphere(transform.position, gunShotRadius, enemyLayerMask);
        
        //
        foreach (var enemyCollider in enemyColliders)
        {
            enemyCollider.GetComponent<EnemyAwareness>().isAggro = true;
        }
        
        RaycastHit hit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
           Debug.Log(hit.transform.name); 
           
           imp target = hit.transform.GetComponent<imp>();
           if (target != null)
           {
               target.TakeDamage(damage);
           }
        }
    }
}
