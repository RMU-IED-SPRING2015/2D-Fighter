using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour {

    public GameObject ImpactPrefab;
    public GameObject ProjectilePrefab;

    public float Range;
    public float Ammunition;
    public float RateOfFire;
    public float Velocity;
    public float MeleeDamage;

    private bool _isAttacking;
    private float _shotTimeStamp;
    private float _shotDelay;
    private Vector3 _firstContact;
    private AttackType _attackType = AttackType.Melee;
	// Use this for initialization
	void Start () {
        if (RateOfFire != 0.0f)
            _shotDelay = 1 / RateOfFire;
        else
            _shotDelay = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	    if (_isAttacking)
        {
            switch (_attackType)
            {
                case AttackType.Melee:
                {
                    if (ImpactPrefab == null)
                        break;


                    GameObject sp = Instantiate(ImpactPrefab, _firstContact, Quaternion.identity) as GameObject;

                    _isAttacking = false;
                    break;
                }
                case AttackType.Ranged:
                {
                    if (ProjectilePrefab == null)
                        break;
                    if (_isAttacking && Time.time > _shotTimeStamp + _shotDelay && _shotDelay != 0.0f )
                    {
                        // if it is, We spawn a bullet.
                        GameObject _shot = Instantiate(ProjectilePrefab, transform.position, transform.rotation) as GameObject;

                        // What the bullet does is up to the bullet...
                        _shot.rigidbody.AddForce(transform.forward * Velocity);
                        Ammunition--;
                        _shotTimeStamp = Time.time;
                        Debug.Log(transform.name + " Created a " + ProjectilePrefab.transform.name + " at: " + Time.time.ToString() );

                        _isAttacking = false;
                    }
                    break;
                }
            }
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("In range for Melee.");
        _attackType = AttackType.Melee;
        _firstContact = col.contacts[0].point;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        Debug.Log("Out of range for Melee.");
        _attackType = AttackType.Ranged;
    }


    public void Attack()
    {
        _isAttacking = true;
    }
}

public enum AttackType
{
    Melee,
    Ranged
};
