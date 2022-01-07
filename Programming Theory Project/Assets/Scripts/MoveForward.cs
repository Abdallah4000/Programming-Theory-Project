using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed1 = 7f;
    private float speed2 = 14f;
    private float speed3 = 21f;

    private float speedPro = 20f;

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(gameObject.CompareTag("Projectile"))
        {
            transform.Translate (Vector3.up * speedPro * Time.deltaTime);
            if(transform.position.z > 20f)
            {

                Destroy(gameObject);

            }
        }

        if(gameObject.CompareTag("Enemy"))
        {
            if(DataSaver.instance.level== 0)
            {
                transform.Translate (Vector3.forward * speed1 * Time.deltaTime);
            }
            else if (DataSaver.instance.level== 1)
            {
                transform.Translate (Vector3.forward * speed2 * Time.deltaTime);
            }
            else if (DataSaver.instance.level== 2)
            {
                transform.Translate (Vector3.forward * speed3 * Time.deltaTime);
            }


            if(transform.position.z < -9f)
            {
                DataSaver.instance.TScore -= 10;
                Destroy(gameObject);

            }
        }
    }



}
