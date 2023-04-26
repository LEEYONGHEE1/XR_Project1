using UnityEngine;


public class ProjectileMove : MonoBehaviour

{
    // Start is called before the first frame update

    public enum PROJECTILETYPE                  //enum 타입으로 선언
    {
        PLAYER,
        MONSTER
    }

    public Vector3 launchDirection;

    public PROJECTILETYPE projectileType;

    private void FixedUpdate()
    {
        float moveAmount = 10 * Time.fixedDeltaTime;
        transform.Translate(launchDirection * moveAmount);
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log(collision.gameObject.name);

    //    if (collision.gameObject.tag == "Object")
    //    {
    //        Destroy(this.gameObject);    
    //    }

    //    if (collision.gameObject.tag == "Monster")
    //    {
    //        Destroy(this.gameObject);
    //        collision.gameObject.GetComponent<Monster>().Damaged(1);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Monster") && projectileType == PROJECTILETYPE.PLAYER)
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Monster>().Damaged(1);
            GameObject Temp = GameObject.FindGameObjectWithTag("GameManager");
            Temp.GetComponent<HUDTextManager>().UpdateHUDTextSet(
                "1", other.gameObject, new Vector3(0.0f, 10.0f, 0.0f));

        }

        if (other.CompareTag("Player") && projectileType == PROJECTILETYPE.MONSTER)
        {
            Destroy(this.gameObject);
            other.gameObject.GetComponent<PlayerHp>().Damaged(1);
            GameObject Temp = GameObject.FindGameObjectWithTag("GameManager");
            Temp.GetComponent<HUDTextManager>().UpdateHUDTextSet(
                "1", other.gameObject, new Vector3(0.0f, 10.0f, 0.0f));
        }

    }
}
