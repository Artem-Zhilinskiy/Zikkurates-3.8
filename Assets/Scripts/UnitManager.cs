using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Zikkurat
{
    public class UnitManager : MonoBehaviour
    {
        [SerializeField, Header("Префабы бойцов")]
        private GameObject GreenFighter;
        [SerializeField]
        private GameObject RedFighter;
        [SerializeField]
        private GameObject BlueFighter;

        [SerializeField, Header("Точки респауна")]
        private GameObject GreenRespawnPoint;
        [SerializeField]
        private GameObject RedRespawnPoint;
        [SerializeField]
        private GameObject BlueRespawnPoint;

        //Задержки создания юнитов
        private int _greenRespawnDelay = 4;
        private int _blueRespawnDelay = 5;
        private int _redRespawnDelay = 6;

        //Корутина создания юнитов
        Coroutine _greenFighterCreationCoroutine = null;
        Coroutine _redFighterCreationCoroutine = null;
        Coroutine _blueFighterCreationCoroutine = null;

        //Скрипт ворот
        [Header("Зелёные ворота"), SerializeField]
        private Transform GreenGates;

        [Header("Панель параметров зелёных воинов"), SerializeField]
        private GameObject GreenPanel;

        private void Start()
        {
            ClickGateHandler();
        }

        private void Awake()
        {
            /*
            _greenFighterCreationCoroutine = StartCoroutine(GreenFighterCreation());
            _redFighterCreationCoroutine = StartCoroutine(RedFighterCreation());
            _blueFighterCreationCoroutine = StartCoroutine(BlueFighterCreation());
            */
        }

        private IEnumerator GreenFighterCreation()
        {
            while(true)
            {
                yield return new WaitForSecondsRealtime(_greenRespawnDelay);
                Instantiate(GreenFighter, GreenRespawnPoint.transform.position, Quaternion.identity);
                Debug.Log("Зелёный воин создан");
            }
        }
        private IEnumerator RedFighterCreation()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(_redRespawnDelay);
                Instantiate(RedFighter, RedRespawnPoint.transform.position, Quaternion.identity);
                Debug.Log("Красный воин создан");
            }
        }
        private IEnumerator BlueFighterCreation()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(_blueRespawnDelay);
                Instantiate(BlueFighter, BlueRespawnPoint.transform.position, Quaternion.identity);
                Debug.Log("Синий воин создан");
            }
        }

        private void ClickGateHandler()
        {
            GreenGates.GetComponent<GateScript>().ClickGateEvent += OnClickGateMethod;
        }

        private void OnClickGateMethod(string _gateName)
        {
            /*
            if (_gateName == "Gate_Green")
            {
                Debug.Log("Сработало событие клика на зелёные ворота");
            }
            if (_gateName == "Gate_Red")
            {
                Debug.Log("Сработало событие клика на красные ворота");
            }
            if (_gateName == "Gate_Blue")
            {
                Debug.Log("Сработало событие клика на синие ворота");
            }
            else
            {
                Debug.Log("Произошло что-то непонятное в событии клика на ворота");
            }
            */
        }
    }
}
