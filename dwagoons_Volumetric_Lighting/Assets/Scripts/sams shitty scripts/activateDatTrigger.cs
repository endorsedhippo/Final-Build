using UnityEngine;
using System.Collections;
using InControl;

public class activateDatTrigger  : MonoBehaviour 
{


	private Collider capCol;
	private InputDevice device;
	public int playerIndex;
	private HealthScript health;
	private float timer = 5;
	public float timeBetweenAttacks;
	public Animator animator;
	public float damage;


	// Use this for initialization
	void Start () 
	{
		capCol = GetComponent<SphereCollider>();
		device = InputManager.Devices [playerIndex];
		capCol.enabled = false;

	}


	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
		if (device.Action3.IsPressed) 
		{
			

			Timer ();

		}
		else 
		{
			animator.SetBool ("IsAttacking", false);
		}

	}

	void Timer()
	{
		
		{
			if (timer > timeBetweenAttacks)
			{
				animator.SetBool ("IsAttacking", true);

				StartCoroutine (Combat ());
				timer = 0;
			}
		}
	}


	IEnumerator Combat()
	{
		capCol.enabled = true;
		yield return new WaitForSeconds (1);
		capCol.enabled = false;


	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Player") 
		{
			if (other.gameObject.layer == 0)
			{
				other.GetComponent<DragonStats> ().currentHealth -= damage;

			}

		}
	}
		
}
