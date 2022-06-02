using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Zikkurat
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class BaseUnit : MonoBehaviour
    {
        private Rigidbody _rigidBody;

        public BaseUnit Target { get; set; }

        public SteeringBehaviourData GetSteeringBehaviorData {get; private set;}

        public float Mass => _rigidBody.mass;

        public float WanderAngle { get; set; }

        protected virtual void Start()
        {
            _rigidBody = GetComponent<RigidBody>();
            GetSteeringBehaviorData = ConfiguraionManager.Self.GetSteeringBehaviourData;
        }

        public Vector3 GetVelocity(IgnoreAxisType ignore = IgnoreAxisType.None)
        {
            return UpdateIgnoreAxis(_rigidBody.velocity, ignore);
        }

        public void SetVelocity (Vector3 velocity, IgnoreAxisType ignore = IgnoreAxisType.None)
        {
            _rigidBody.velocity = UpdateIgnoreAxis(velocity, ignore);
        }    

        private Vector3 UpdateIgnoreAxis(Vector3 velocity, IgnoreAxisType ignore)
        {
            if ((ignore & IgnoreAxisType.None) == IgnoreAxisType.None) return velocity;
            else if ((ignore & IgnoreAxisType.X) == IgnoreAxisType.X) velocity.x = 0f;
            else if ((ignore & IgnoreAxisType.Y) == IgnoreAxisType.Y) velocity.y = 0f;
            else if ((ignore & IgnoreAxisType.Z) == IgnoreAxisType.Z) velocity.z = 0f;
            return velocity;
        }
    }
}
