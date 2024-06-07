using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody myRB;
    public GameObject myTarget;
    public Text interaction_text; // Référence à l'objet TextMeshPro pour afficher le nom de l'objet interactif
    public Vector3 boxHalfExtents = new Vector3(1, 1, 1); // Taille de la boîte pour le BoxCast
    public float boxCastMaxDistance = 10f; // Distance maximale pour le BoxCast
    public LayerMask interactableLayerMask; // Masque de couche pour les objets interactifs

    void Start()
    {
        interaction_text.text = ""; // Assurez-vous que le texte est vide au début
    }

    void Update()
    {
        DetectInteractableObject();

        if (myTarget != null && Input.GetKeyDown(KeyCode.E))
        {
            myTarget.SetActive(false);
            interaction_text.text = ""; // Effacer le texte lorsque l'objet est désactivé
            // Ajouter l'objet à l'inventaire
        }
    }

    void DetectInteractableObject()
    {
        RaycastHit hit;
        Vector3 boxCenter = transform.position;
        Vector3 boxDirection = transform.forward;
        Quaternion orientation = transform.rotation;

        if (Physics.BoxCast(boxCenter, boxHalfExtents, boxDirection, out hit, orientation, boxCastMaxDistance, interactableLayerMask))
        {
            var selectionTransform = hit.transform;
            var interactable = selectionTransform.GetComponent<InteractableObject>();

            if (interactable != null)
            {
                myTarget = selectionTransform.gameObject;
                interaction_text.text = interactable.GetItemName();
            }
            else
            {
            
            }
        }
        else
        {
            myTarget = null;
            interaction_text.text = "";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Gérer les collisions si nécessaire
    }
}