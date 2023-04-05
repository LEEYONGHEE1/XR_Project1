using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed = 10;
    public GameObject PlayerPivot;
    public Camera viewCamera;
    public Vector3 velocity;
    public ProjectileController ProjectileController;

    // Start is called before the first frame update
    void Start()
    {
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousPos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        Vector3 targetPosition = new Vector3(mousPos.x, transform.position.y, mousPos.z);
        PlayerPivot.transform.LookAt(targetPosition, Vector3.up);
        velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 10.0f, ForceMode.Impulse);
        }

        if(Input.GetMouseButtonDown(0))
        {
            ProjectileController.FireProjectile();
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + velocity * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }
}
