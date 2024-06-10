using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody myRB;
    public GameObject myTarget;
    public Text interactionText; // Référence à l'objet TextMeshPro pour afficher le nom de l'objet interactif
    public Vector3 boxHalfExtents = new Vector3(1, 1, 1); // Taille de la boîte pour le BoxCast
    public float boxCastMaxDistance = 10f; // Distance maximale pour le BoxCast
    public LayerMask interactableLayerMask; // Masque de couche pour les objets interactifs
    public Inventory inventory; // Référence à l'inventaire du joueur

    void Start()
    {
        interactionText.text = ""; // Assurez-vous que le texte est vide au début
    }

    void Update()
    {
        UpdateInteractionText();

        if (myTarget != null && Input.GetKeyDown(KeyCode.F)) // Changez la touche si nécessaire
        {
            PickUpItem();
        }
    }

    void UpdateInteractionText()
    {
        if (myTarget != null)
        {
            var interactable = myTarget.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                interactionText.text = interactable.GetItemName();
            }
            else
            {
                interactionText.text = "";
            }
        }
        else
        {
            interactionText.text = "";
        }
    }

    void PickUpItem()
    {
        inventory.AddItem(myTarget);
        myTarget.SetActive(false);
        interactionText.text = ""; // Effacer le texte lorsque l'objet est désactivé
        myTarget = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Gérer les collisions si nécessaire
    }
}



