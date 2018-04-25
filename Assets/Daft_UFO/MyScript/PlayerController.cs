using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // zmienne 
    private Rigidbody2D rb2d;
    public float speed;
    public bool inTouch = false;
    public Text countText;
    public Text winText;

    private int count;

    void Start()
    {
        //pobranie i uzyskanie dostępu do Rigid Body
        rb2d = GetComponent<Rigidbody2D> ();
        // wartości początkowe
        count = 0;
        winText.text = "";
        SetCountText();
    }
    void FixedUpdate()
    {
        //przechowaj bieżące wartości ruchu
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // użyj powyższych wartości ruchu by stworzyć nowy Vector2
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        //dodanie funkcji siły do powyższego ruchu * prędkość do poruszenia gracza
        rb2d.AddForce(movement * speed);

    }
    //wywołwane w momencie gdy obiekt styka się z colliderem
    void OnCollisionEnter2D(Collision2D other)
    {
        //sprawdz czy zetknięty obiekt ma tag Pickup
        if (other.gameObject.CompareTag("PickUp"))
        {
            //ustaw dotkniętemu obiektowi status inactive i dodaj 1
            other.gameObject.SetActive(false);
            count = count + 1;

            //aktualizuj obecną wartość zliczenia
            SetCountText();
            Debug.Log("amout of coins: " + count);

        }
    }


    void SetCountText()
    {
        // wyświetl ilość zebranych coinw
        countText.text = "Score: " + count.ToString();

        // po zebraniu 4 coinów wyświetl tekst wygranej
        if (count >= 4)
        {
            winText.text = "Congratulations !!";
        }
    }


    
}
