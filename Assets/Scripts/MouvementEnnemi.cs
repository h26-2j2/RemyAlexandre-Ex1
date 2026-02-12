using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.UIElements;

public class MouvementEnnemi : MonoBehaviour
{
    // Variables
    public float vitesseY;
    public float vitesseRotation;
    public float tauxAggrandissement;
    private bool grosseurMax = false;
    private Vector2 position;


    void Start()
    {
        transform.position = new Vector2(Random.Range(-5, 7), Random.Range(-6, 7)); // Position random d'une zone de la map


        int nbAleatoire1 = Random.Range(0, 2); // Nombre entier aléatoire entre 0 et 1
        if (nbAleatoire1 == 0)
        {
            vitesseY = -vitesseY; // Direction inverse (1 chance sur 2)
        }
        int nbAleatoire2 = Random.Range(0, 2);
        if (nbAleatoire2 == 0)
        {
            vitesseRotation = -vitesseRotation; // Rotation inverse (1 chance sur 2)
        }
    }

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + vitesseY * Time.deltaTime); // Translation avec un meilleur frame rate j'espère

        if (transform.position.y > 6.0f) // Dépassement de la map vers le bas
        {
            transform.position = new Vector2(Random.Range(-5, 7), -6.0f);
        }
        else if (transform.position.y < -6.0f) // Dépassement de la map vers le haut
        {
            transform.position = new Vector2(Random.Range(-5, 7), 6.0f);
        }


        transform.Rotate(0, 0, vitesseRotation * Time.deltaTime); // Rotation sur soi-même


        if (grosseurMax == false)
        {
            float nouvelleGrosseur = transform.localScale.x + tauxAggrandissement * Time.deltaTime;
            if (nouvelleGrosseur >= 2.0f) // Max scale, ennemi dans les airs
            {
                grosseurMax = true;
            }
            transform.localScale = new Vector3(nouvelleGrosseur, nouvelleGrosseur, nouvelleGrosseur);
        }
        else
        {
            float nouvelleGrosseur = transform.localScale.x - tauxAggrandissement * Time.deltaTime; 
            if (nouvelleGrosseur <= 1.2f) // Min scale, ennemi au sol
            {
                grosseurMax = false;
            }
            transform.localScale = new Vector3(nouvelleGrosseur, nouvelleGrosseur, nouvelleGrosseur);
        }

    }
}
