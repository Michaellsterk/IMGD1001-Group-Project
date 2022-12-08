using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speedMin = 5f;
    public float speedMax = 5f;
    public float minHeight = -2f;
    public float maxHeight = 2f;
    private float speed;
    private float topEdge;
    private float bottomEdge;

    private bool moveUp;

   private void Start() {
        bottomEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).y + 2.5f;
        topEdge = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - 1.5f;
        speed = Random.Range(speedMin, speedMax);
        transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        moveUp = Random.Range(0f, 1f) < 0.5f;
   }

   private void Update() {
        if(moveUp) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        } else {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }

        if((transform.position.y > topEdge && moveUp) || (transform.position.y < bottomEdge && !moveUp)) {
           moveUp = !moveUp;
        }
   }
}
