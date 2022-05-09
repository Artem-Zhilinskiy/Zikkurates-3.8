using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Zikkurat
{
    public class UnitManager : MonoBehaviour
    {
        [SerializeField, Header("Префабы бойцов")]
        public GameObject GreenFighter;
        public GameObject RedFighter;
        public GameObject BlueFighter;

        // Start is called before the first frame update
        void Start()
        {
            /*
            Instantiate(GreenFighter, new Vector3(0, 30, 0), Quaternion.identity);
            Debug.Log("Создан тестовый воин");
            */
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
