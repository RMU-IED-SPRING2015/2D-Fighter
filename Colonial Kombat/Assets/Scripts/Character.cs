using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour {

    //public Limb[] Limbs;
    public string Name;

    private float _maximumHP;
    private float _currentHP;

	private bool _grounded;
    private float _jumpedAt = 0.0f;

	// Use this for initialization
	void Start () {
//        Limbs = new Limb[Enum.GetValues(typeof(HumanoidLimbs)).Length];
        setupLimbs();
        _jumpedAt = 0.0f;
	}

    private void setupLimbs()
    {
/*/        for (int i = 0; i < Limbs.Length; i++)
        {
            Limbs[i] = new Limb();
            Limbs[i].Name = ((HumanoidLimbs)i).ToString();
            if (Limbs[i].Name.ToLower().Contains("leg"))
                Limbs[i].SetLimbType(LimbType.Leg);
            else if(Limbs[i].Name.ToLower().Contains("arm"))
                Limbs[i].SetLimbType(LimbType.Arm);
            else if (Limbs[i].Name.ToLower().Contains("head"))
                Limbs[i].SetLimbType(LimbType.Head);
            else if (Limbs[i].Name.ToLower().Contains("torso"))
                Limbs[i].SetLimbType(LimbType.Torso);
        }
		/*/
	}

    // Update is called once per frame
    void fixedUpdate()
    {
		rigidbody2D.AddForce (Physics2D.gravity);
	}

    public void Injure(float damage)
    {
        _currentHP--;
        if (_currentHP > _maximumHP)
            _currentHP = _maximumHP;
        if (_currentHP < 0)
            _currentHP = 0;
    }

    public void Heal(float health)
    {
        Injure(-health);
    }

    /// <summary>
    /// Health is a read-only attribute.
    /// </summary>
    public float Health
    {
        // Add any modifiers to the HP here to pass to external entities.
        get { return _currentHP; }        
    }

    /// <summary>
    /// Moves a character to the location, and plays the walking animation.
    /// </summary>
    /// <param name="location"></param>
    public void WalkTo(Vector2 location)
    {
		//float damp = 100.5f;
		//Vector2 temp = new Vector2 (transform.position.x, transform.position.y);
        
		//rigidbody2D.AddForce( damp*(location -  temp) );
 
		// First update the position of the player.
		rigidbody2D.MovePosition( location );
 
		// Now update the animation of the player to make it appear to walk.
	}

    /// <summary>
    /// Make a character perform an attack.
    /// </summary>
    public void Attack()
    {
        // The Character performs an attack, regardless of what is the target. If the attack is successful, 
        //  (another character is hit) then the attack will call the strike method. otherwise ... only anim.
        //  is played. - Joshua Palmer 

    }

    /// <summary>
    /// Make a character attempt to perform a jump. A jump will not be successful if the character is not 
    ///  standing on something.
    /// </summary>
    public void Jump()
    {
        // Make the character jump.
        Debug.DrawLine(rigidbody2D.transform.position - 2.3f * rigidbody2D.transform.up, rigidbody2D.transform.position  - 3.0f * rigidbody2D.transform.up);

        RaycastHit2D rhit = Physics2D.Raycast(rigidbody2D.transform.position - 2.3f * rigidbody2D.transform.up, -rigidbody2D.transform.up, 0.3f);
        if (rhit.collider != null)
        {
            Debug.Log(rhit.collider.name);
            _grounded = true;
        }
        else
            _grounded = false;

        Debug.Log(_jumpedAt);
        Debug.Log(Time.time);
        // Make sure the character has a footing to jump from, and not allow an air jump.
        if ( _grounded && ( Time.time >= _jumpedAt + .15f ) ) {
			// First update the position of the character.
            
            rigidbody2D.AddForce(11000.0f * rigidbody2D. transform.up);
            _jumpedAt = Time.time;
			// Then play the animation.
		}
    }

    /// <summary>
    /// Returns a new position on a collider, in front of the character that should support the character if
    ///  he were to step there.
    /// </summary>
    private Vector2 findFooting()
    {
        Vector2 footing = new Vector2();

        // Calculate the next location to put the foot.

        return footing;
    }


	void OnTriggerEnter2D( Collider2D col )
	{
		

	}
	void OnTriggerExit2D()
	{
		//Debug.Log ("Attacked");
		//GameObject.Find ("Fireworks").particleEmitter.emit = false;
	}

	/*.void OnCollisionEnter2D( Collision2D col )
	{
		//Debug.Log ("Collision!!");
		//_grounded = true;

	}

	void OnCollisionExit2D( Collision2D col )
	{
		//_grounded = false;
	}*/
}


public enum HumanoidLimbs
{
    Head,
    LeftArm,
    RightArm,
    LeftLeg,
    RightLeg,
    Torso,
}