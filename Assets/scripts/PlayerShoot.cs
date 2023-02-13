using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour 
{
    public World _world;
    
    // Variables to store the current direction and speed of the bullet
    public Vector2 Direction { get; set; }
    public float Speed { get; set; }
    
    // Function to shoot a bullet
    public void Shoot() 
    { 
        // Create a new bullet and give it the position and speed of the player
        Bullet bullet = new Bullet(transform.position, Direction, Speed);
        
        // Add the bullet to the list in the world
        _world.add(bullet);
    }

    void Update() 
    {
        //Get the Rigidbody2D component of the bullet
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //Set the velocity according to the Direction and Speed properties
        rb.velocity = Direction * Speed;
    }

    // Function to detect collisions
    private void OnCollisionEnter2D(Collision2D coll) 
    {
        // Check if the collided object is a bullet
        if (coll.gameObject.GetComponent<Bullet>() != null) 
        {
            // Check if the bullet is within 200 meters of the Player
            Vector3 distance = transform.position - coll.transform.position;
            if (distance.magnitude <= 200.0f) 
            {
                //Delete the bullet if it is within 200 meters
                _world.bullets.Remove((Bullet)coll.gameObject.GetComponent<Bullet>());
            }
        }
    }
}

