using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed; 
    [SerializeField] KeyCode keyToPress; // find what key to press

    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(keyToPress)) {
            if(canBePressed) {
                gameObject.SetActive(false);

                GameManager.instance.NoteHit();
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                // SFX.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) { // checks if within hit box
        if(other.tag == "Activator") {
            canBePressed = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Activator") {
            canBePressed = false;
            
            GameManager.instance.NoteMissed();
            }
    }


}
