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
        
        if(DataSaver.instance.TScore < 0)
        {
            DataCheck2();
            GameOver();
        }
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
            GameOver();
        }
        else if(other.gameObject.CompareTag("Wall"))
        {
            GameOver ();
        }
    }

    public void GameOver ()
    {
        DataCheck2();
        Destroy(gameObject);
        Time.timeScale = 0;
        GameOverScreen.SetActive(true);
        PauseButton.SetActive(false);
    }
    private void DataCheck2()
    {
        if(DataSaver.instance.level == 0 )
        {
            if(DataSaver.instance.TScore > DataSaver.instance.EasyScore)
            {
                DataSaver.instance.EasyScore = DataSaver.instance.TScore;
                DataSaver.instance.SaveScore();
            }
        }
        if(DataSaver.instance.level == 1 )
        {
            if(DataSaver.instance.TScore > DataSaver.instance.MediumScore)
            {
                DataSaver.instance.MediumScore = DataSaver.instance.TScore;
                DataSaver.instance.SaveScore();
            }
        }
        if(DataSaver.instance.level == 2 )
        {
            if(DataSaver.instance.TScore > DataSaver.instance.HardScore)
            {
                DataSaver.instance.HardScore = DataSaver.instance.TScore;
                DataSaver.instance.SaveScore();
            }
        }
    }


}
