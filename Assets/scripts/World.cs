using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour 
{
    // List to store bullets in
    private List<Bullet> bullets;

    // Use this for initialization
    void Start () 
    {
        bullets = new List<Bullet> ();
    }

    // Function to add bullets to the world
    public void add(Bullet bullet) 
    {
        bullets.Add(bullet);
    }

    // Function to move all existing bullets
    public void updateBullets() 
    {
        foreach(Bullet b in bullets) 
        {
            b.move();
        }
    }
}

