using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Thrust")]
    [SerializeField] float thrustPower = 60f;
    [SerializeField] float boostMultiplier = 2f;
    [SerializeField] float liftPower = 40f;

    [Header("Rotation")]
    [SerializeField] float pitchPower = 4f;
    [SerializeField] float yawPower = 3f;
    [SerializeField] float rollPower = 5f;

    [Header("Stability Assist")]
    [SerializeField] float autoLevelStrength = 2f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.useGravity = false;
        rb.mass = 100f;

        rb.linearDamping = 0.5f;
        rb.angularDamping = 2f;

        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void FixedUpdate()
    {
        HandleThrust();
        HandleLift();
        HandleRotation();
        AutoLevel();
    }

    void HandleThrust()
    {
        float throttle = 0f;

        if (Input.GetKey(KeyCode.W)) throttle = 1f;
        if (Input.GetKey(KeyCode.S)) throttle = -1f;

        float currentThrust = thrustPower;

        if (Input.GetKey(KeyCode.LeftShift))
            currentThrust *= boostMultiplier;

        rb.AddForce(transform.forward * throttle * currentThrust, ForceMode.Acceleration);
    }

    void HandleLift()
    {
        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(transform.up * liftPower, ForceMode.Acceleration);

        if (Input.GetKey(KeyCode.LeftControl))
            rb.AddForce(-transform.up * liftPower, ForceMode.Acceleration);
    }

    void HandleRotation()
    {
        float pitch = -Input.GetAxis("Mouse Y") * pitchPower;

        float yaw = 0f;
        if (Input.GetKey(KeyCode.A)) yaw = -yawPower;
        if (Input.GetKey(KeyCode.D)) yaw = yawPower;

        float roll = 0f;
        if (Input.GetKey(KeyCode.Q)) roll = rollPower;
        if (Input.GetKey(KeyCode.E)) roll = -rollPower;

        rb.AddTorque(transform.right * pitch, ForceMode.Acceleration);
        rb.AddTorque(transform.up * yaw, ForceMode.Acceleration);
        rb.AddTorque(transform.forward * roll, ForceMode.Acceleration);
    }

    void AutoLevel()
    {
        // Helps align jet upright slowly (GTA-style assist)
        Vector3 currentUp = transform.up;
        Vector3 worldUp = Vector3.up;

        Vector3 torqueDirection = Vector3.Cross(currentUp, worldUp);

        rb.AddTorque(torqueDirection * autoLevelStrength, ForceMode.Acceleration);
    }
}