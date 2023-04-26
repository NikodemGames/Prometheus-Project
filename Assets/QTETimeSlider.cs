using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTETimeSlider : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    
    public void SetSliderMaxValue(float val)
    {
        slider.maxValue= val;
        slider.value= val;
    }

    public void SetSliderValue(float val)
    {
        slider.value= val;
    }
}
