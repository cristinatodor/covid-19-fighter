using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfectionBar : MonoBehaviour {
    
    public Slider slider;

    public void SetMinInfection(float infection) {
        slider.minValue = infection;
        slider.value = infection;  
    }

    public void SetInfection(float infection) {
        slider.value = infection ;
    }
}
