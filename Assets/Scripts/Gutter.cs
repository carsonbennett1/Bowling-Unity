using UnityEngine;

public class Gutter : MonoBehaviour
{
    private Rigidbody ballRB;
    private void OnTriggerEnter(Collider triggeredBody)
    {

        // First get the rigibody of the ball and store it in a local variable ballRigidBody
        Rigidbody ballRigidBody = triggeredBody.GetComponent<Rigidbody>();

        // Store the velocity magnitude before resetting the velocity
        float velocityMagnitude = ballRigidBody.linearVelocity.magnitude;

        // **Important** 
        // Reset the linear and angluar velocity because the ball is rotating on the ground when moving
        ballRigidBody.linearVelocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;

        // Add force in the forward direction of the gutter
        // Use cached velocity magnitude to keep it a little realistic
        ballRB.AddForce(transform.forward * velocityMagnitude, ForceMode.VelocityChange);
    }

    private void Start()
    {
        ballRB = GetComponent<Rigidbody>();
    }

}
