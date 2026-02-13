using UnityEngine;

public class ZoneArrivee : MonoBehaviour
{
    public float positionZoneX = 8f;
    private Vector2 position;

    void Update()
    {
        if (transform.position.y > 6.0f) // Dépassement de la map vers le bas
        {
            transform.position = new Vector2(positionZoneX, -6.0f);
        }

        else if (transform.position.y < -6.0f) // Dépassement de la map vers le haut
        {
            transform.position = new Vector2(positionZoneX, 6.0f);
        }
    }
}
