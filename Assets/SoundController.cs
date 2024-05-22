using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : Singleton<SoundController>
{
    [SerializeField] Button SFXButton, MusicButton;
    [SerializeField] Slider SFXSlider, MusicSlider;
}
