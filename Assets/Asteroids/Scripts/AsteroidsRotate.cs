using UnityEngine;

namespace Asteroids
{
    public class AsteroidOrbitAndRotate : MonoBehaviour
    {
        [Header("Target")]
        public Transform jet;

        [Header("Attack Settings")]
        public float attackDistance = 80f;
        public float chaseSpeed = 20f;

        [Header("Rotation")]
        public float minRotationSpeed = 10f;
        public float maxRotationSpeed = 50f;

        // This variable is what JetEnterSystem will enable
        public bool attackMode = false;

        private Vector3 rotationSpeed;

        void Start()
        {
            rotationSpeed = new Vector3(
                Random.Range(minRotationSpeed, maxRotationSpeed),
                Random.Range(minRotationSpeed, maxRotationSpeed),
                Random.Range(minRotationSpeed, maxRotationSpeed)
            );
        }

        void Update()
        {
            // Always rotate
            transform.Rotate(rotationSpeed * Time.deltaTime);

            if (!attackMode || jet == null)
                return;

            float distance = Vector3.Distance(transform.position, jet.position);

            // Only attack when jet gets close
            if (distance < attackDistance)
            {
                Vector3 direction = (jet.position - transform.position).normalized;
                transform.position += direction * chaseSpeed * Time.deltaTime;
            }
        }
    }
}