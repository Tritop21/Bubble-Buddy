using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.Universal;


namespace WorldTime
{
    public class WorldLight : MonoBehaviour
    {
        private Light2D _light;
        private float number;
        private float number2;

        [SerializeField]
        private WorldTime _worldTime;

        void Start()
        {
            _light = GetComponent<Light2D>();
            _worldTime.WorldTimeChanged += OnWorldTimeChanged;
            number = 1;
            number2 = 1.2f;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            if (PercentOfDay(newTime) < 0.125) 
            {
                _light.intensity = 1.1f * (PercentOfDay(newTime));
            }
            else if (PercentOfDay(newTime) < 0.25)
            {
                _light.intensity = number2 * (PercentOfDay(newTime));
            }
            else if (PercentOfDay(newTime) < 0.35)
            {
                _light.intensity = 1.3f * (PercentOfDay(newTime));
            }
            else if (PercentOfDay(newTime) < 0.45)
            {
                _light.intensity = 1.4f * (PercentOfDay(newTime));
            }
            else
            {
                _light.intensity = 1.5f * (PercentOfDay(newTime));
            }
        }

        private void OnDestroy()
        {
            _worldTime.WorldTimeChanged -= OnWorldTimeChanged;
        }

        private float PercentOfDay(TimeSpan timeSpan)
        {
            if ((float)timeSpan.TotalMinutes % WorldTimeConstant.MinutesInDay / WorldTimeConstant.MinutesInDay < 0.51)
            {
                return (float)timeSpan.TotalMinutes % WorldTimeConstant.MinutesInDay / WorldTimeConstant.MinutesInDay;
            }
            else if ((float)timeSpan.TotalMinutes % WorldTimeConstant.MinutesInDay / WorldTimeConstant.MinutesInDay > 0.50)
            {
                return number - ((float)timeSpan.TotalMinutes % WorldTimeConstant.MinutesInDay / WorldTimeConstant.MinutesInDay);
            }
            else
            {
                return 1;
            }
        }
    }

    
}

