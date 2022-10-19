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
    public bool jump;
    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        if (hozMovement > 0)
        {
            if (!jump)
                animator.SetInteger("Movement", 1);
            transform.localScale = new Vector3(10, 10, 10);
        }
        else if (hozMovement < 0)
        {
            if (!jump)
                animator.SetInteger("Movement", 1);
            transform.localScale = new Vector3(-10, 10, 10);
        }
        else
        {
            if (!jump)
                animator.SetInteger("Movement", 0);
        }
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);

            if (scoreValue == 4)
            {
                score.text = "You Win Fajardo";
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetInteger("Movement", 2);
                rd2d.velocity = new Vector2(0, jumpForce);
                jump = true;
            }
            jump = false;
        }
    }
}
