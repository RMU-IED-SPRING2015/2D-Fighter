using UnityEngine;
using System.Collections;

public class BaseStat : MonoBehaviour {


    public BaseStatus Status = BaseStatus.Normal;
    public Texture HealthBarImage;

    public float Health;

    private float _maximumHealth;
    private float _currentHealth;
    private float _buff;


    
	// Use this for initialization
	void Start () {
        _maximumHealth = 10.0f;
        _currentHealth = 10.0f;
        _buff = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (_currentHealth < 0.0f)
            Status = BaseStatus.Deceased;

        if (_currentHealth > _maximumHealth)
            _currentHealth = _maximumHealth;

        Health = _currentHealth + _buff;
	}

    public void Heal(float amount)
    {
        _currentHealth += amount;
    }

    public void Hurt(float amount)
    {
        if( Status != BaseStatus.Invincible )
            Heal(-amount);
    }

    void OnGUI( )
    {
        GUI.color = Color.green;
        GUI.Box(new Rect(transform.position.x - 20, transform.position.y - 20, 40, 10), Health.ToString() );
    }
}

[System.Serializable]
public enum BaseStatus
{
    Invincible,
    Normal,
    Buffed,
    Deceased
}
