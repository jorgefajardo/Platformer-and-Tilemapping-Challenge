using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterCollidert : MonoBehaviour
{
    public PlayerScript player;
    public Transform init;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" )
        {
            player.Healt();
            player.transform.position = init.position;
        }

    }
}
