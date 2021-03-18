using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] private Rigidbody playerBody;
    private Vector3 inputVector;
    private Vector3 startPosition;
    private Animator anim;

    
    void Start()
    {
        anim = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }


    void FixedUpdate() 
    {
        Movement();     
    }

    void Movement()
    {
        inputVector = new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, playerBody.velocity.y, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));
        playerBody.velocity = inputVector;
    }

    void Animation()
    {
        if(inputVector == new Vector3(0f,0f,0f)) 
        {
            anim.SetBool("isRunning", false);
        }

        else
        {
            anim.SetBool("isRunning",true);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("You touched an obstacle");
        if(other.gameObject.tag == "Obstacle")
        {
        Debug.Log("Go Back");
        transform.position = startPosition;
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Sea")
        {
            RestartLevel();
        }
    }

     void RestartLevel()
    {
        SceneManager.LoadScene(1);
    }

}
