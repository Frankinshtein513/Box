using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForse = 2000f;
    public float sidewaysForse = 500f;
    public float upForse = 7f;
    public bool IsGround;
    public PlayerMovement movement;
    public float maxVelocity = 0f;
    




    public void Jump()
    {
        Ray ray = new Ray(gameObject.transform.position, Vector3.down);
        RaycastHit rh;
        if (Physics.Raycast(ray, out rh, 1f))
        {
            IsGround = true;
        }
        else
        {
            IsGround = false;
        }
        if(Input.GetKeyDown(KeyCode.Space)&& IsGround)
        {
            rb.AddForce(Vector3.up * upForse);
        }
    }

    
        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Enemy>())
            {
                Destroy(gameObject);
            }
            if (other.tag == "Damage")
            {
                SceneManager.LoadScene(0);
            }
            
        }   
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
        }
    }
    
    void Update()
    {

        Jump();

        rb.AddForce(0, 0, forwardForse * Time.deltaTime);
     
        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForse * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForse * Time.deltaTime, 0, 0);
        }

        /*
         limit speed don`t work
        if (rb.velocity.magnitude >= maxVelocity)
        {
            rb.velocity =rb.velocity.normalized * maxVelocity;
        } 
        */




    }



}   
