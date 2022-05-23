using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Zikkurat
{
    public class Assistants : IPainter
    {

        public event PainterHandler OnPaint;

        public void OnSeek (NPC unit)
        {
            if (unit.Target == null) return;
            //Сила стремления к цели
            var desired_velocity = (unit.Target.transform.position - unit.transform.position).normalized * data.MaxVelocity;
            //Коррекция движения от текущей к желаемой
            var steering = desired_velocity- unit.GetVelocity(IgnoreAxisType.Y);
            //Учитываем ограничения по силе и массу 
            steering = Vector3.ClampMagnitude(steering, data.MaxVelocity) / unit.Mass;

            var velocity = Vector3.ClampMagnitude(unit.GetVelocity() + steering, data.MaxSpeed);

            unit.SetVelocity(velocity);
        }

    }
}