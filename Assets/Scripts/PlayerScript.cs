using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public float speed;
    public float jumpForce;
    public Text score;
    public Animator animator;
    private int scoreValue = 0;
    public bool jump, playing;
    public Image healt;
    public float healtN = 1;
    public GameObject button;

    public Sounds sounds;
    public Transform init;
    // Start is called before the first frame update
    void Start()
    {
        playing = true;
        button.SetActive(false);
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playing)
        {
            float hozMovement = Input.GetAxis("Horizontal");
            if (hozMovement > 0)
            {
                if (!jump)
                {
                    animator.SetInteger("Movement", 1);
                    transform.localScale = new Vector3(10, 10, 10);
                }

            }
            else if (hozMovement < 0)
            {
                if (!jump)
                {
                    animator.SetInteger("Movement", 1);
                    transform.localScale = new Vector3(-10, 10, 10);
                }

            }
            else
            {
                if (!jump)
                    animator.SetInteger("Movement", 0);
            }
            rd2d.AddForce(new Vector2(hozMovement * speed, 0));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.collider.tag == "Ground" && playing)
        {
            jump = false;
        }

        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
            sounds.Coin();

            if (scoreValue == 4)
            {
                sounds.Win();
                animator.SetInteger("Movement", 0);
                transform.position = init.position;
                sounds.Start();
                Healty();
            }
            if (scoreValue == 8)
            {
                score.text = "You Win Fajardo";
                sounds.Win();
                playing = false;
                animator.SetInteger("Movement", 0);

            }
        }
        else if (collision.collider.tag == "Enemy")
        {
            if (playing)
            {
                sounds.Enemy();
                Destroy(collision.collider.gameObject);
                healtN = healtN - 0.33f;
                healt.fillAmount = healtN;
                if (healtN < 0.1f)
                {
                    score.text = "You Lose";
                    button.SetActive(true);
                    playing = false;
                    sounds.Llose();
                    animator.SetInteger("Movement", 0);

                }
            }
        }

    }
    public void Healty()
    {
        sounds.Enemy();
        healtN = 1;
        healt.fillAmount = healtN;
       
    }
    public void Healt()
    {
        sounds.Enemy();
        healtN = healtN - 0.33f;
        healt.fillAmount = healtN;
        if (healtN < 0.1f)
        {
            score.text = "You Lose";
            button.SetActive(true);
            playing = false;
            sounds.Llose();
            animator.SetInteger("Movement", 0);

        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && playing)
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetInteger("Movement", 2);
                rd2d.velocity = new Vector2(rd2d.velocity.x, jumpForce);
                Invoke("WaitJump", 1f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && playing)
        {
            jump = true;
            animator.SetInteger("Movement", 2);
        }

    }



    private void WaitJump()
    {
    }

    public void ResetScene()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
