using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidingBot : MonoBehaviour
{
    
    public float targetVelocity = 10f;
    public int numberOfRays = 17;
    public float angle = 90;
    public float rayRange = 5;

    [SerializeField] private Rigidbody botPlayerBody;
    private Vector3 startPosition;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        botPlayerBody = GetComponent<Rigidbody>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var deltaPosition = Vector3.zero;
        for(int i = 0; i < numberOfRays; ++i)
        {
            var rotation = this.transform.rotation;
            var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationMod * Vector3.forward;
            
            var ray = new Ray(this.transform.position, direction);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, rayRange))
            {
                deltaPosition -= (1f / numberOfRays) * targetVelocity * direction;
            }
            else
            {
                deltaPosition += (1f / numberOfRays) * targetVelocity * direction;
            }
        }

        this.transform.position += deltaPosition * Time.deltaTime;
        
    }

    void OnDrawGizmos()
    {
        for(int i = 0; i < numberOfRays; ++i)
        {
            var rotation = this.transform.rotation;
            var rotationMod = Quaternion.AngleAxis((i / ((float)numberOfRays - 1)) * angle * 2 - angle, this.transform.up);
            var direction = rotation * rotationMod * Vector3.forward;
            Gizmos.DrawRay(this.transform.position, direction);
        }
    }

    void Animation()
    {
        if(this.transform.up == new Vector3(0f,0f,0f)) 
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
        if(other.gameObject.tag == "Obstacle")
        {
            transform.position = startPosition;
        }
    }


}
