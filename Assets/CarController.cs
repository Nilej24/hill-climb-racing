using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody2D backWheel, frontWheel;
    public Rigidbody2D wholeCar;
    public float wheelAccel;
    public float wheelMaxSpeed;
    public float rotateAccel;
    public float rotateMaxSpeed;
    public float downforceStrength;
    private float direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal") * -1;
    }

	private void FixedUpdate()
	{
		backWheel.AddTorque(
            CalculateAppliedTorque(wheelAccel * direction, wheelMaxSpeed, backWheel) *
            Time.fixedDeltaTime
        );

		frontWheel.AddTorque(
            CalculateAppliedTorque(wheelAccel * direction, wheelMaxSpeed, frontWheel) *
            Time.fixedDeltaTime
        );

		wholeCar.AddTorque(
            CalculateAppliedTorque(rotateAccel * -direction, rotateMaxSpeed, wholeCar) *
            Time.fixedDeltaTime
        );

		wholeCar.AddForce(
            CalculateDownforce(wholeCar.velocity, CalculateDirectionVector(wholeCar.rotation), downforceStrength) *
            Time.fixedDeltaTime
        );
	}

    private Vector2 CalculateDirectionVector(float rotation, float rotationToFaceRight=0) {

        return new Vector2(
            Mathf.Cos((rotation - rotationToFaceRight) * Mathf.Deg2Rad),
            Mathf.Sin((rotation - rotationToFaceRight) * Mathf.Deg2Rad)
        );

    }

    private Vector2 CalculateDownforce(Vector2 carVel, Vector2 carDirection, float multiplier) {

        // skip all if multiplier is 0
        if (multiplier == 0f) return Vector2.zero;
        
        // check how fast the car is travelling in the direction it's facing
        float dfValue = Vector2.Dot(carVel, carDirection);

        // no downforce backwards
        if (dfValue <= 0) return Vector2.zero;

        // calculate downforce
        return Vector2.Perpendicular(carDirection) * dfValue * multiplier * -1;

    }

    private float CalculateAppliedTorque(float torque, float maxAngVel, Rigidbody2D rigidbody) {

        // skip function if 0
        if (torque == 0) return 0;

        float currentAngVel = rigidbody.angularVelocity;

        // trying to apply +ve torque
        if (torque >= 0) {

            // apply no torque if above max ang vel
            if (currentAngVel > maxAngVel) return 0;

            // apply torque
            return torque;

        // trying -ve torque
        // same thing
        } else {

            if (currentAngVel < -maxAngVel) return 0;
            return torque;

        }

    }
}
