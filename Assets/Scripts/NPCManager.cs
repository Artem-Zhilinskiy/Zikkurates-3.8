using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

            var hunter = _npc.FirstOrDefault(t => t.name == "Hunter");
            hunter.Target = _npc.FirstOrDefault(t => t.name == "Unit");

            var painter = FindObjectOfType<Painter>();
            _steeringBehaviourAssistants.OnPaint += painter.Paint;
        }

        private void FixedUpdate()
        {
            foreach (var unit in _npc)
            {
                _steeringBehaviourAssistants.UpdateMoveState(unit);
            }
        }
    }
}