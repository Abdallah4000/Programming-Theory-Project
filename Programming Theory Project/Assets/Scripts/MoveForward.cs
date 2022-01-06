using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField]private float speed = 10f;
    private float speedPro = 20f;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(gameObject.CompareTag("Projectile"))
        {
            transform.Translate (Vector3.up * speedPro * Time.deltaTime);
            if(transform.position.z > 15f)
            {

                Destroy(gameObject);

            }
        }

        if(gameObject.CompareTag("Enemy"))
        {
            transform.Translate (Vector3.forward * speed * Time.deltaTime);
            if(transform.position.z < -9f)
            {
                // here we player lose
                //Debug.Log("1");
                Destroy(gameObject);

            }
        }
    }



}
