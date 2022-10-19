using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip Enviorement, win, lose, coin, enemy;

    public AudioSource ambient, player;

    public void Start()
    {
        ambient.clip = Enviorement;
        ambient.Play();

    }

    public void Win() {
        player.Stop();
        player.clip = win;
        player.Play();
        ambient.Stop();

    }
    public void Llose()
    {
        player.Stop();
        player.clip = lose;
        player.Play();
        ambient.Stop();

    }
    public void Coin()
    {
        player.Stop();
        player.clip = coin;
        player.Play();
    }

    public void Enemy()
    {
        player.Stop();
        player.clip = enemy;
        player.Play();
    }
}
