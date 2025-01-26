using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class OptionsManager : MonoBehaviour
    {
        public Slider micSlider;
        public TextMeshProUGUI sliderText;
        
        private void Start()
        {
            micSlider.onValueChanged.AddListener((v) =>
            {
                // ReSharper disable once SpecifyACultureInStringConversionExplicitly
                sliderText.text = micSlider.value.ToString();
                GameManager.Instance.microphoneSensitivity = (int) micSlider.value;
            });  
        }

        private void OnEnable()
        {
            if (GameManager.Instance.microphoneSensitivity > 0)
            {
                micSlider.value = GameManager.Instance.microphoneSensitivity;
                sliderText.text = micSlider.value.ToString();
            }
        }
    }
}
