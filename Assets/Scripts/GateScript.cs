using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

namespace Zikkurat
{
    public class GateScript : MonoBehaviour
    {
        public delegate void ClickEventHandler(GateScript component);
        /// <summary>
        /// Событие клика на игровом объекте
        /// </summary>
        public event ClickEventHandler OnClickEventHandler;

        //При нажатии мышкой по объекту, вызывается данный метод
        public void OnPointerClick(PointerEventData eventData)
        {
            OnClickEventHandler?.Invoke(this);
            Debug.Log("Зарегистрирован клик мышью");
        }
        /*
        public void OnClickMethod(Transform[] _massiveCells)
        {
            OnClickEventHandler += (_chip) =>
            {
                /*
                var _cell = Pair2(GameObject.Find("Main Camera").GetComponent<GameManager>()._blackCells, gameObject.transform);
                var _cellScript = _cell.GetComponent<CellComponent>();
                _cellScript.Click(_massiveCells);
            };
        }
        */
    }
}