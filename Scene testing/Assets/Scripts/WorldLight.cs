using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


namespace WorldTime
{
    public class WorldLight : MonoBehaviour
    {
        private Light2D _light;
        private float number;

        [SerializeField]
        private WorldTime _worldTime;

        void Start()
        {
            _light = GetComponent<Light2D>();
            _worldTime.WorldTimeChanged += OnWorldTimeChanged;
            number = 1;
        }

        private void OnWorldTimeChanged(object sender, TimeSpan newTime)
        {
            _light.intensity = (PercentOfDay(newTime));
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

