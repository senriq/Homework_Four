using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMotion : MonoBehaviour
{
    new Rigidbody rigidbody;
    AudioSource audioSource;
    [SerializeField] float rocketThrust = 200f;
    [SerializeField] float rocketRotation = 200f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        ProcessThrust(); 
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.W)){ // Rocket moves up when W is pushed
            rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * rocketThrust);
            if(!audioSource.isPlaying){
            audioSource.Play();
            }
        }
        else{
            audioSource.Stop();
        }   
    }

    void ProcessRotation()
    {
        if(Input.GetKey(KeyCode.J)){ // Rocket rotates left when J is pushed
            transform.Rotate(Vector3.left * Time.deltaTime * rocketRotation);
        }
        else if(Input.GetKey(KeyCode.L)){ // Rocket rotates right when L is pushed
            transform.Rotate(Vector3.right * Time.deltaTime * rocketRotation);
        }
    }
}
