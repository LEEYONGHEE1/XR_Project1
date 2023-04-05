using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{

    public Vector3 launchDirection;
    public GameObject projectile;


    // Start is called before the first frame update
    public void FireProjectile()
    {
        GameObject temp = (GameObject)Instantiate(projectile);

        temp.transform.position = this.gameObject.transform.position;
        temp.transform.localScale = Vector3.one * 0.3f;
        temp.GetComponent<ProjectileMove>().launchDirection = transform.forward;

        Destroy(temp, 10.0f);
    }
}
