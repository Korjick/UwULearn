using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    [Header("UI")] 
    [SerializeField] private Texture2D _texture;
    [Header("Components")]
    [SerializeField] private Animator _animator;
    [SerializeField] private SkinnedMeshRenderer _skinnedMeshRenderer;
    [SerializeField] private int _baseColorMaterialIds = -1;
    [SerializeField] private int _lightMaterialIds = -1;

    private void Start()
    {
        if(_baseColorMaterialIds >= 0)
            _skinnedMeshRenderer.materials[_baseColorMaterialIds].mainTexture = _texture;
        if(_lightMaterialIds >= 0)
            _skinnedMeshRenderer.materials[_lightMaterialIds].color = Color.red;
        
        
    }
}
