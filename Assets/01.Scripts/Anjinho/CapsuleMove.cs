using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleMove : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed = 10f;
    public float jumpHeight = 3f;
    public float dash = 5f;
    public float rotspeed = 5f;

    private Vector3 dir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");
        dir.Normalize();
    }

    private void FixedUpdate()
    {
        if (dir !=  Vector3.zero)
        {
            transform.forward = Vector3.Lerp(transform.forward, dir, rotspeed * Time.deltaTime);
        }
        
        rigidbody.MovePosition(this.gameObject.transform.position + dir * speed * Time.deltaTime);
    }
}
