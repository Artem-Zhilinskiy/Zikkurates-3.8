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

        protected virtual void Start()
        {
            _rigidBody = GetComponent<RigidBody>();
            GetSteeringBehaviorData = ConfiguraionManager.Self.GetSteeringBehaviourData;
        }

        public Vector3 GetVelocity()
        {
            return _rigidBody.velocity;
        }

        public void SetVelocity (Vector3 velocity)
        {
            _rigidBody.velocity = velocity;
        }    
    }
}
