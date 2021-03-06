using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	[SerializeField] private Inventory _inventory;
    public Inventory inventory => _inventory;
	public bool canMove;
	public Animator anim;
	
    public float moveSpeed;

	private Rigidbody2D rb;

	private float x;
	private float y;

	private Vector2 input;
	private bool moving;
	
	// public VectorValue startingPosition;
	
	
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		// transform.position = startingPosition.initialValue;
	}
	private void OnEnable() => SceneAnchor.OnSceneTransition += InitialisePosition; 
    private void OnDisable() => SceneAnchor.OnSceneTransition -= InitialisePosition;
	private void InitialisePosition(Vector2 position) => transform.position = position;
	private void Update()
	{
		GetInput();
		Animate();
		
		if (Input.GetKeyDown(KeyCode.I)) InventoryUI.RequestInventory(inventory);

		if(!canMove)
		{
			rb.velocity = Vector3.zero;
			return;
		}
	}
	private void FixedUpdate()
	{
		rb.velocity = input * moveSpeed;
	}

	private void GetInput()
	{
		x = Input.GetAxisRaw("Horizontal");
		y = Input.GetAxisRaw("Vertical");

		input = new Vector2(x,y);
		input.Normalize();
	}
	private void Animate()
	{
		if(input.magnitude > 0.1f || input.magnitude < -0.1f)
		{
			moving = true;
	        }
		else
		{
			moving = false;
		}

		if(moving)
		{
			anim.SetFloat("X", x);
			anim.SetFloat("Y", y);
		}

		anim.SetBool("Moving", moving);
    }
}