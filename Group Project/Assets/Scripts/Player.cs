using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int spriteIndex;

    private Vector3 direction;
    public float gravity = -9.8f;
    public float strengthUp = 5f;
    public float strengthDown = 10f;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * strengthUp;
        }

        //Skill drop can either act as push downwards, would need to use direction.y to avoid spamming it being slower than natural falling
        //Or increasing gravity while it is held
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift) || Input.GetMouseButtonDown(1)) {
            direction = Vector3.down * strengthDown;
        }
        /*
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetMouseButton(1)) {
            gravity = -9.8f * 3f;
        } else {
            gravity = -9.8f;
        }
        */


        //Touch control option for quick drop is to switch to checking if touch is in top half or bottom half of screen
        //Touch controls are not necessary though
        if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) {
                direction = Vector3.up * strengthUp;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void AnimateSprite() {
        spriteIndex++;

        if(spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnEnable() {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Obstacle" ) {
            FindObjectOfType<GameManager>().GameOver();
        } else if (other.gameObject.tag == "Scoring") {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
 