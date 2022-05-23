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
            foreach (var npc in _npc)
            {
                switch (npc.State)
                {
                    case AIStateType.None:
                        break;
                    case AIStateType.Wait:
                        break;
                    case AIStateType.Move_Seek:
                        _steeringBehaviourAssistants.OnSeek(npc);
                        break;
                    case AIStateType.Move_Flee:
                        break;
                    case AIStateType.Move_Arrival:
                        break;
                    case AIStateType.Move_Wander:
                        break;
                    case AIStateType.Move_Pursuing:
                        break;
                    case AIStateType.Move_Evading:
                        break;
                }
            }
        }
    }
}