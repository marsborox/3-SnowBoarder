using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] float torqueAmmount = 2000f;
    [SerializeField] float boostSpeed = 200f;
    [SerializeField] float normalSpeed = 100f;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }
    void Update()
    {
        if (canMove)
        { 
        RotatePlayer();
        RespondToBoost();
        }
    }
    public void DisableControls()
    {
        canMove = false;
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmmount);
        }
    }
    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            surfaceEffector2D.speed = boostSpeed; 
        }
        else 
        {
            surfaceEffector2D.speed = normalSpeed; 
        }
    }
}
