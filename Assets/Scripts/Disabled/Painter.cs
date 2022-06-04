using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zikkurat
{
    /*
    public class Painter : MonoBehaviour
    {
        private Dictionary<string, Dictionary<string, LineRenderer>> _dictionary;

        public LineRenderer _velocityUnit;
        public LineRenderer _steeringUnit;
        public LineRenderer _velocityHunter;
        public LineRenderer _SteeringHunter;

        private void Start()
        {
            _dictionary = new Dictionary<string, Dictionary<string, LineRenderer>>
            {
                { "Unit", new Dictionary<string, LineRenderer>
                {
                    {"velocity", _velocityUnit },
                    {"Steering", _steeringUnit }
                }
            },
                {"Hunter", new Dictionary<string, LineRenderer>
                {
                    {"velocity", _velocityHunter },
                    {"steering", _SteeringHunter }
                }
                }
            };
        }

        public void Paint(Vector3 stert, Vector3 end, string sourceName, string name)
        {
            var line = _dictionary[sourceName][name];
            line.SetPositions(new Vector3[] { stert, end });
        }
    }
    */
}
