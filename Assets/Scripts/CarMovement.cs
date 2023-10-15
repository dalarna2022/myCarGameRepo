using System.Collections;
using System.Collections.Generic;

using TMPro;  //Library txt

using UnityEngine;

using UnityEngine.SceneManagement;



public class CarMovement : MonoBehaviour
{
    public float speed;

    private Vector3 myPosition;

    public float xBound = 2;

    public int score;  
    public int maxScore;

    public TextMeshProUGUI roadScore;   
    public TextMeshProUGUI currentScore;   
    public TextMeshProUGUI uppermostScore;


    public GameObject panelGameOver;

    private Camera cam;
    public bool moveWithTheMouse;


    // Start is called before the first frame update
    private void Start()
    {
        maxScore = PlayerPrefs.GetInt("MaxScore");

        if (moveWithTheMouse)
        {
            cam = Camera.main;
        }
        else
        {
            myPosition = transform.position;
        }

    }



    // Update is called once per frame
    private void Update()
    {
        if (moveWithTheMouse)
        {
            TouchMove();
        }
        else
        {
            myPosition.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            myPosition.x = Mathf.Clamp(myPosition.x, -xBound, xBound);

            transform.position = myPosition;
        }

    }





    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            GameObject.Find("Audio GameOver").GetComponent<AudioSource>().Play();
            Time.timeScale = 0;  

            panelGameOver.SetActive(true);

            GameObject.Find("Audio BG").GetComponent<AudioSource>().mute = true;
            currentScore.text = "Current Score:       " + score.ToString();

            if (score >= maxScore)
            {
                maxScore = score;
                uppermostScore.text = "Uppermost Score : " + maxScore.ToString();
                PlayerPrefs.SetInt("MaxScore", maxScore);  
            }
            else
            {
                uppermostScore.text = "Uppermost Score: " + maxScore.ToString();
            }

        }

        if (collision.gameObject.tag == "Coin")
        {
            GameObject.Find("Audio Coin").GetComponent<AudioSource>().Play();

            score += 1;
            roadScore.text = score.ToString();
            Destroy(collision.gameObject);
        }
    }


    private void TouchMove()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(Mathf.Clamp(mousePos.x, -xBound, xBound), transform.position.y, transform.position.z);
    }

    public void BtnPlay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
