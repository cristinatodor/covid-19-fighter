using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SanityBar : MonoBehaviour {
    
    public Slider slider;

    public void SetMaxSanity(float sanity) {
        slider.maxValue = sanity;
        slider.value = sanity;  
    }

    public void SetSanity(float sanity) {
        slider.value = sanity;
    }
}
