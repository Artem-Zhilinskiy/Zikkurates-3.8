using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zikkurat
{
    public class Assistants : IPainter
    {

        public event PainterHandler OnPaint;

        public void UpdateMoveState(NPC unit)
        {
            switch (unit.State)
            {
                case AIStateType.None:
                    break;
                case AIStateType.Wait:
                    break;
                case AIStateType.Move_Seek:
                    OnSeek(unit);
                    break;
                case AIStateType.Move_Flee:
                    OnFlee(unit);
                    break;
                case AIStateType.Move_Arrival:
                    OnArrival(unit);
                    break;
                case AIStateType.Move_Wander:
                    OnWander(unit);
                    break;
                case AIStateType.Move_Pursuing:
                    OnPursuing(unit);
                    break;
                case AIStateType.Move_Evading:
                    OnEvading(unit);
                    break;
            }
        }

        public void OnSeek (NPC unit)
        {
            if (unit.Target == null) return;

            var data = unit.GetSteeringBehaviorData;
            //Сила стремления к цели
            var desired_velocity = (unit.Target.transform.position - unit.transform.position).normalized * data.MaxVelocity;
            //Коррекция движения от текущей к желаемой
            var steering = desired_velocity- unit.GetVelocity(IgnoreAxisType.Y);
            //Учитываем ограничения по силе и массу 
            steering = Vector3.ClampMagnitude(steering, data.MaxVelocity) / unit.Mass;

            var velocity = Vector3.ClampMagnitude(unit.GetVelocity() + steering, data.MaxSpeed);
            OnPaint?.Invoke(unit.transform.position, unit.transform.position + desired_velocity, unit.name, "velocity");
            unit.SetVelocity(velocity);
            OnPaint?.Invoke(unit.transform.position, unit.transform.position + velocity, unit.name, "steering");
        }

        public void OnFlee (NPC unit)
        {
            if (unit.Target == null) return;
            var data = unit.GetSteeringBehaviorData;
            //Сила стремления к цели
            var desired_velocity = (unit.transform.position - unit.Target.transform.position).normalized * data.MaxVelocity;
            //Коррекция движения от текущей к желаемой
            var steering = desired_velocity - unit.GetVelocity(IgnoreAxisType.Y);
            //Учитываем ограничения по силе и массу 
            steering = Vector3.ClampMagnitude(steering, data.MaxVelocity) / unit.Mass;

            var velocity = Vector3.ClampMagnitude(unit.GetVelocity() + steering, data.MaxSpeed);
            OnPaint?.Invoke(unit.transform.position, unit.transform.position + desired_velocity, unit.name, "velocity");
            unit.SetVelocity(velocity);
            OnPaint?.Invoke(unit.transform.position, unit.transform.position + velocity, unit.name, "steering");
        }

        public void OnArrival(NPC unit)
        {
            if (unit.Target == null) return;
            var data = unit.GetSteeringBehaviorData;
            //Сила стремления к цели
            var desired_velocity = (unit.Target.transform.position - unit.transform.position.normalized * data.MaxVelocity;
            //Квадрат расстояния до цели
            var sqrlength = desired_velocity.sqrMagnitude; 

            if(sqrlength < data.ArrivalDistance*data.ArrivalDistance )
            {
                desired_velocity = desired_velocity / data.ArrivalDistance;

                desired_velocity = CheckMinSpeed(desired_velocity);
            }

            //Коррекция движения от текущей к желаемой
            var steering = desired_velocity - unit.GetVelocity(IgnoreAxisType.Y);
            //Учитываем ограничения по силе и массу 
            steering = Vector3.ClampMagnitude(steering, data.MaxVelocity) / unit.Mass;

            var velocity = Vector3.ClampMagnitude(unit.GetVelocity() + steering, data.MaxSpeed);
            OnPaint?.Invoke(unit.transform.position, unit.transform.position + desired_velocity, unit.name, "velocity");
            unit.SetVelocity(velocity);
            OnPaint?.Invoke(unit.transform.position, unit.transform.position + velocity, unit.name, "steering");
        }

        private void OnPursuing(NPC unit)
        {
            if (unit.Target == null) return;

            var targetPosistion = unit.transform.position;

            var data = unit.GetSteeringBehaviorData;
            var propheticIndex = Vector3.Distance(unit.transform.position, unit.Target.transform.position)/unit.Target.GetSteeringBehaviorData.MaxVelocity;
            var targetPosition = unit.Target.transform.position + unit.Target.GetVelocity(IgnoreAxisType.Y)*propheticIndex;
            //Сила стремления к цели
            var desired_velocity = (targetPosistion - unit.transform.position).normalized * data.MaxVelocity;
            //Коррекция движения от текущей к желаемой
            var steering = desired_velocity - unit.GetVelocity(IgnoreAxisType.Y);
            //Учитываем ограничения по силе и массу 
            steering = Vector3.ClampMagnitude(steering, data.MaxVelocity) / unit.Mass;

            var velocity = Vector3.ClampMagnitude(unit.GetVelocity() + steering, data.MaxSpeed);
            OnPaint?.Invoke(unit.transform.position, unit.transform.position + desired_velocity, unit.name, "velocity");
            unit.SetVelocity(velocity);
            OnPaint?.Invoke(unit.transform.position, unit.transform.position + velocity, unit.name, "steering");
        }

        private void OnEvading(NPC unit)
        {
            if (unit.Target == null) return;

            var targetPosistion = unit.transform.position;

            var data = unit.GetSteeringBehaviorData;
            var propheticIndex = Vector3.Distance(unit.transform.position, unit.Target.transform.position) / unit.Target.GetSteeringBehaviorData.MaxVelocity;
            var targetPosition = unit.Target.transform.position + unit.Target.GetVelocity(IgnoreAxisType.Y) * propheticIndex;
            //Сила стремления к цели
            var desired_velocity = (-targetPosistion + unit.transform.position).normalized * data.MaxVelocity;
            //Коррекция движения от текущей к желаемой
            var steering = desired_velocity - unit.GetVelocity(IgnoreAxisType.Y);
            //Учитываем ограничения по силе и массу 
            steering = Vector3.ClampMagnitude(steering, data.MaxVelocity) / unit.Mass;

            var velocity = Vector3.ClampMagnitude(unit.GetVelocity() + steering, data.MaxSpeed);
            OnPaint?.Invoke(unit.transform.position, unit.transform.position + desired_velocity, unit.name, "velocity");
            unit.SetVelocity(velocity);
            OnPaint?.Invoke(unit.transform.position, unit.transform.position + velocity, unit.name, "steering");
        }

        private void OnWander(NPC unit)
        {
            var data = unit.GetSteeringBehaviorData;
            var center = unit.GetVelocity(IgnoreAxisType.Y).normalized
        }

        private Vector3 CheckMinSpeed(Vector3 velocity)
        {
            if (velocity.sqrMagnitude <0.9f)
            {
                velocity.z = 0f; velocity.x = 0f;
            }
            return velocity;
        }
    }
}