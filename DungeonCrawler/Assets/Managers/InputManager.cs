using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    #region Singleton pattern
    protected static InputManager _instance;

    public static InputManager Instance
    {
        get
        {
            if (_instance == null) _instance = FindObjectOfType<InputManager>();
            return _instance;
        }
    }
    #endregion
    
    void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
