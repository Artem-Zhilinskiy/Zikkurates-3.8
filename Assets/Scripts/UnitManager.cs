using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

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

        [SerializeField, Header("Центр карты")]
        public GameObject MapCenter;

        //Задержки создания юнитов
        private int _greenRespawnDelay = 4;
        private int _blueRespawnDelay = 4;
        private int _redRespawnDelay = 4;

        //Корутина создания юнитов
        Coroutine _greenFighterCreationCoroutine = null;
        Coroutine _redFighterCreationCoroutine = null;
        Coroutine _blueFighterCreationCoroutine = null;

        //Корутина открытия панели
        Coroutine _openPanel = null;
        //Корутина закрытия панели
        Coroutine _closePanel = null;

        //Активная на данный момент панель
        private GameObject _activePanel;

        //Скрипт ворот
        [Header("Зелёные ворота"), SerializeField]
        private Transform GreenGates;

        [Header("Панель параметров зелёных воинов"), SerializeField]
        private GameObject GreenPanel;
        [Header("Панель параметров красных воинов"), SerializeField]
        private GameObject RedPanel;
        [Header("Панель параметров синих воинов"), SerializeField]
        private GameObject BluePanel;

        [Header("Кнопки закрытия панелей"), SerializeField]
        private Button GreenPanelCloseButton;
        [SerializeField]
        private Button RedPanelCloseButton;
        [SerializeField]
        private Button BluePanelCloseButton;

        //Открыта ли на данный момент какая-нибудь панель
        private bool _panelIsOpened = false;

        private void Start()
        {
            ClickGateHandler();
            //Отладка один на один
            //Instantiate(RedFighter, RedRespawnPoint.transform.position, Quaternion.identity);
            //Instantiate(GreenFighter, GreenRespawnPoint.transform.position, Quaternion.identity);
        }

        private void Awake()
        {
            _greenFighterCreationCoroutine = StartCoroutine(GreenFighterCreation());
            _redFighterCreationCoroutine = StartCoroutine(RedFighterCreation());
            _blueFighterCreationCoroutine = StartCoroutine(BlueFighterCreation());
        }

        private IEnumerator GreenFighterCreation()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(_greenRespawnDelay);
                Instantiate(GreenFighter, GreenRespawnPoint.transform.position, Quaternion.identity);
                //Debug.Log("Зелёный воин создан");
            }
        }
        private IEnumerator RedFighterCreation()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(_redRespawnDelay);
                Instantiate(RedFighter, RedRespawnPoint.transform.position, Quaternion.identity);
                //Debug.Log("Красный воин создан");
            }
        }
        private IEnumerator BlueFighterCreation()
        {
            while (true)
            {
                yield return new WaitForSecondsRealtime(_blueRespawnDelay);
                Instantiate(BlueFighter, BlueRespawnPoint.transform.position, Quaternion.identity);
                //Debug.Log("Синий воин создан");
            }
        }

        private void ClickGateHandler()
        {
            GreenGates.GetComponent<GateScript>().ClickGateEvent += OnClickGateMethod;
        }

        //Методы открытия панелей ворот
        public void OpenPanel(string _gateName)
        {
            if (_panelIsOpened)
            {
                ClosePanel();
            }
            _activePanel = PanelDefinition(_gateName);
            //_activePanel.SetActive(true);
            _openPanel = StartCoroutine(OpenPanelCoroutine(_activePanel));
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
        //Определение панели по имени ворот
        private GameObject PanelDefinition(string _gateName)
        {
            if (_gateName == "Gate_Green")
            {
                return GreenPanel;
            }
            if (_gateName == "Gate_Red")
            {
                return RedPanel;
            }
            if (_gateName == "Gate_Blue")
            {
                return BluePanel;
            }
            else
            {
                Debug.Log("Произошло что-то непонятное в методе PanelDefinition");
                return null;
            }
        }

        //Корутина открытия панели
        private IEnumerator OpenPanelCoroutine(GameObject _panel)
        {
            while (_panel.GetComponent<RectTransform>().transform.position.y > 350f)
            {
                yield return new WaitForSecondsRealtime(Time.deltaTime);
                //Debug.Log("Корутина открытия панели запущена ");
               //Debug.Log(_panel.GetComponent<RectTransform>().transform.position);
                _panel.GetComponent<RectTransform>().transform.position -= new Vector3(0f, 5f);
            }
            AllButtonsTurnOn();
            _panelIsOpened = true;
            yield break;
        }

        //Закрытие панели
        public void ClosePanel()
        {
            //_activePanel.SetActive(true);
            AllButtonsTurnOff();
            _closePanel = StartCoroutine(ClosePanelCoroutine(_activePanel));
        }

        private IEnumerator ClosePanelCoroutine(GameObject _panel)
        {
            while (_panel.GetComponent<RectTransform>().transform.position.y < 700f)
            {
                yield return new WaitForSecondsRealtime(Time.deltaTime);
                //Debug.Log("Корутина открытия панели запущена ");
                //Debug.Log(_panel.GetComponent<RectTransform>().transform.position);
                _panel.GetComponent<RectTransform>().transform.position += new Vector3(0f, 5f);
            }
            _panelIsOpened = false;
            yield break;
        }

        #region "включение и отключение кнопок"
        //Методы включения и отключения всех кнопок
        public void AllButtonsTurnOff()
        {
            GreenPanelCloseButton.interactable = false;
            RedPanelCloseButton.interactable = false;
            BluePanelCloseButton.interactable = false;
        }

        public void AllButtonsTurnOn()
        {
            GreenPanelCloseButton.interactable = true;
            RedPanelCloseButton.interactable = true;
            BluePanelCloseButton.interactable = true;
        }
        #endregion

        /*
        public void SetVelocity(GameObject _unit)
        {
            _unit.transform.LookAt(MapCenter.transform);
            _unit.GetComponent<Rigidbody>().velocity = _unit.transform.forward;
        }
        */
    }
}
