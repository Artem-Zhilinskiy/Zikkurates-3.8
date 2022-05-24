using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zikkurat
{
    public class NPCManager : MonoBehaviour
    {
        private SteeringBehaviourAssistants _steeringBehaviourAssistants;

        private LinkedList<NPC> _npc;

        private void Awake()
        {
            _steeringBehaviorAssistans = new SteeringBehaviourAssistants();
        }

        private void Start()
        {
            _npc = new LinkedList<NPC>(FindObjectsOfType<NPC>());
        }

        private void Update()
        {
            foreach (var unit in _npc)
            {
                _steeringBehaviourAssistants.UpdateMoveState(unit);
            }
        }
    }
}