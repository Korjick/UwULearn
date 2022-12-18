using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    private long _hp, _energy, _food;
    
    [SerializeField] private Cat _cat;

    public long Energy
    {
        get => _energy;

        set
        {
            if (value > 100)
                value = 100;
            if (value < 0)
                value = 0;

            _energy = value;
            OnEnergyChanged?.Invoke();
        }
    }

    public long Food
    {
        get => _food;

        set
        {
            if (value > 100)
                value = 100;
            if (value < 0)
                value = 0;

            _food = value;
            OnFoodChanged?.Invoke();
        }
    }
    
    public long HP
    {
        get => _hp;

        set
        {
            if (value > 100)
                value = 100;
            if (value < 0)
                value = 0;

            _hp = value;
            OnHPChanged?.Invoke();
        }
    }

    public event Action OnEnergyChanged;
    public event Action OnHPChanged;
    public event Action OnFoodChanged;

    private void OnEnable()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        Init();
    }

    private void Init()
    {
        _cat.Init();
    }
}