using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float playerSpeed = 7f;
    private float horizontalInput;
    public GameObject projectile;
    public GameObject GameOverScreen;
    public GameObject PauseButton;

    void Update()
    {
        Movement();
        Projectile();
    }

    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * playerSpeed * horizontalInput);
    }

    void Projectile()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectile,transform.position,projectile.transform.rotation);
        }

        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                {
                    Instantiate(projectile,transform.position,projectile.transform.rotation);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
            PauseButton.SetActive(false);
        }
        else if(other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
            PauseButton.SetActive(false);

        }
    }


}
