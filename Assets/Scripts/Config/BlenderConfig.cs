using System;
using UnityEngine;

[Serializable]
public class BlenderConfig
{
    [SerializeField] private int _maxFruitsInBlender;
    [SerializeField] private float _blendDuration;
    [SerializeField] private float _blendSpeed;
  
    public int MaxFruitsInBlender { get => _maxFruitsInBlender; }
    public float BlendDuration { get => _blendDuration; }
    public float BlendSpeed { get => _blendSpeed; }
}
