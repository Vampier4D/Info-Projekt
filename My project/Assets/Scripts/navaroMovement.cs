using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navaroMovement : MonoBehaviour {

    public controllerNavaro controllerNavaro; // Referenz auf den controllerNavaro

    float horizontalMove = 0f; // Variable zur Speicherung der horizontalen Bewegungseingabe
    bool jump = false; // Variable zur Überprüfung, ob die Sprungtaste gedrückt wurde

    public float runSpeed = 40f; // Geschwindigkeit, mit der sich die Figur bewegt

    // Update wird einmal pro Frame aufgerufen
    void Update()
    {
        // Holen der horizontalen Eingabe und multiplizieren mit der Laufgeschwindigkeit
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        // Überprüfen, ob die Sprungtaste gedrückt wurde
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
        // Überprüfen, ob die Sprungtaste losgelassen wurde
        else if(Input.GetButtonUp("Jump"))
        {
            jump = false;
        }
    }

    // FixedUpdate wird in festen Intervallen aufgerufen und wird für Physikberechnungen verwendet
    private void FixedUpdate()
    {
        // Bewegen der Figur basierend auf der horizontalen Eingabe und dem Sprungstatus
        controllerNavaro.Move(horizontalMove * Time.fixedDeltaTime, jump);
        // Zurücksetzen des Sprungs auf false nach der Anwendung des Sprungs
        jump = false;
    }
}