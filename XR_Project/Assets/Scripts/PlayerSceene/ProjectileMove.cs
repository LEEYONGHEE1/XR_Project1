using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour

{
    // Start is called before the first frame update

    public Vector3 launchDirection;

    private void FixedUpdate()
    {
        float moveAmount = 3 * Time.fixedDeltaTime;
        transform.Translate(launchDirection * moveAmount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.tag == "Object")
        {
            Destroy(this.gameObject);    
        }

        if (collision.gameObject.tag == "Monster")
        {
            Destroy(this.gameObject);
            collision.gameObject.GetComponent<Monster>().Damaged(1);
        }
    }
}
