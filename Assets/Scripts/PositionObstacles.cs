using UnityEngine;

public class PositionObstacles : MonoBehaviour
{
    private Vector2 position;
    void Start()
    {
        transform.position = new Vector2(Random.Range(-5, 8), Random.Range(-4, 5)); // Position random d'une zone de la map
    }

 
    void Update()
    {
        
    }
}
