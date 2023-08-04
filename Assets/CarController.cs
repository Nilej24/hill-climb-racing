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
