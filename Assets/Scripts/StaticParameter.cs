using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Zikkurat
{
    public class StaticParameter : MonoBehaviour
    {
        #region "Блок статических переменных"
        //Для зелёных юнитов
        public static float _healthGreen = 6f;
        public static float _speedGreen = 3f;
        public static float _fastDamageGreen=3f;
        public static float _strongDamageGreen=6f;
        public static float _missProbabilityGreen=0.2f;
        public static float _critProbabilityGreen=0.1f;
        public static float _strongAttackProbabilityGreen=0.2f;

        //Для красных юнитов
        public static float _healthRed = 6f;
        public static float _speedRed = 3f;
        public static float _fastDamageRed=3f;
        public static float _strongDamageRed=6f;
        public static float _missProbabilityRed=0.2f;
        public static float _critProbabilityRed=0.1f;
        public static float _strongAttackProbabilityRed=0.2f;

        //Для синих юнитов
        public static float _healthBlue=6f;
        public static float _speedBlue=3f;
        public static float _fastDamageBlue=3f;
        public static float _strongDamageBlue=6f;
        public static float _missProbabilityBlue=0.2f;
        public static float _critProbabilityBlue=0.1f;
        public static float _strongAttackProbabilityBlue=0.5f;
        #endregion

        #region "Блок слайдеров"
        //Блок слайдеров зелёной панели
        [SerializeField]
        Slider _greenHealthSlider;
        [SerializeField]
        Slider _greenSpeedSlider;
        [SerializeField]
        Slider _greenFastAttackDamageSlider;
        [SerializeField]
        Slider _greenStrongAttackDamageSlider;
        [SerializeField]
        Slider _greenMissSlider;
        [SerializeField]
        Slider _greenCritSlider;
        [SerializeField]
        Slider _greenStrongAttackSlider;
        
        //Блок слайдеров красной панели
        [SerializeField]
        Slider _redHealthSlider;
        [SerializeField]
        Slider _redSpeedSlider;
        [SerializeField]
        Slider _redFastAttackDamageSlider;
        [SerializeField]
        Slider _redStrongAttackDamageSlider;
        [SerializeField]
        Slider _redMissSlider;
        [SerializeField]
        Slider _redCritSlider;
        [SerializeField]
        Slider _redStrongAttackSlider;

        //Блок слайдеров синей панели
        [SerializeField]
        Slider _blueHealthSlider;
        [SerializeField]
        Slider _blueSpeedSlider;
        [SerializeField]
        Slider _blueFastAttackDamageSlider;
        [SerializeField]
        Slider _blueStrongAttackDamageSlider;
        [SerializeField]
        Slider _blueMissSlider;
        [SerializeField]
        Slider _blueCritSlider;
        [SerializeField]
        Slider _blueStrongAttackSlider;
        #endregion

        #region "Блок изменения параметров зелёных юнитов"
        public void HealthChangeGreen()
        {
            _healthGreen = _greenHealthSlider.value;
        }

        public void SpeedChangeGreen()
        {
            _speedGreen = _greenSpeedSlider.value;
        }

        public void FastAttackDamageChangeGreen()
        {
            _fastDamageGreen = _greenFastAttackDamageSlider.value;
        }

        public void StrongAttackDamageChangeGreen()
        {
            _strongDamageGreen = _greenStrongAttackDamageSlider.value;
        }
        public void MissChangeGreen()
        {
            _missProbabilityGreen = _greenMissSlider.value;
        }
        public void CritChangeGreen()
        {
            _critProbabilityGreen = _greenCritSlider.value;
        }
        public void StrongAttackChangeGreen()
        {
            _strongAttackProbabilityGreen = _greenStrongAttackSlider.value;
        }

        #endregion

        #region "Блок изменения параметров красных юнитов"
        public void HealthChangeRed()
        {
            _healthRed = _redHealthSlider.value;
        }

        public void SpeedChangeRed()
        {
            _speedRed = _redSpeedSlider.value;
        }

        public void FastAttackDamageChangeRed()
        {
            _fastDamageRed = _redFastAttackDamageSlider.value;
        }

        public void StrongAttackDamageChangeRed()
        {
            _strongDamageRed = _redStrongAttackDamageSlider.value;
        }
        public void MissChangeRed()
        {
            _missProbabilityRed = _redMissSlider.value;
        }
        public void CritChangeRed()
        {
            _critProbabilityRed = _redCritSlider.value;
        }
        public void StrongAttackChangeRed()
        {
            _strongAttackProbabilityRed = _redStrongAttackSlider.value;
        }
        #endregion

        #region "Блок изменения параметров синих юнитов"
        public void HealthChangeBlue()
        {
            _healthBlue = _blueHealthSlider.value;
        }

        public void SpeedChangeBlue()
        {
            _speedBlue = _blueSpeedSlider.value;
        }

        public void FastAttackDamageChangeBlue()
        {
            _fastDamageBlue = _blueFastAttackDamageSlider.value;
        }

        public void StrongAttackDamageChangeBlue()
        {
            _strongDamageBlue = _blueStrongAttackDamageSlider.value;
        }
        public void MissChangeBlue()
        {
            _missProbabilityBlue = _blueMissSlider.value;
        }
        public void CritChangeBlue()
        {
            _critProbabilityBlue = _blueCritSlider.value;
        }
        public void StrongAttackChangeBlue()
        {
            _strongAttackProbabilityBlue = _blueStrongAttackSlider.value;
        }
        #endregion
    }
}