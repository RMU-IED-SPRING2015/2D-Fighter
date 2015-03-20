using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour {

    public Limb[] Limbs;
    public string Name;

    private float _maximumHP;
    private float _currentHP;

	// Use this for initialization
	void Start () {
        Limbs = new Limb[Enum.GetValues(typeof(HumanoidLimbs)).Length];
        setupLimbs();
	}

    private void setupLimbs()
    {
        for (int i = 0; i < Limbs.Length; i++)
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
    }

    // Update is called once per frame
    void Update()
    {
	    
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
    public void WalkTo(float location)
    {
        // First update the position of the player.
        rigidbody2D.MovePosition(new Vector2( location,transform.position.y ));
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
        
        // Make sure the character has a footing to jump from, and not allow an air jump.
            // First update the position of the character.

            // Then play the animation.


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

    /// <summary>
    /// Causes the characters leg limbs to reach forward and try to find a supporting location to move there.
    /// </summary>
    private void stepForward()
    {
		
    }
	public void eat()
	{
	}

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