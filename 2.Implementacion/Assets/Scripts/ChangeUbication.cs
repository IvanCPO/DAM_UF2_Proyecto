using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeUbication : MonoBehaviour
{
    [SerializeField] float ubicationX;
    [SerializeField] float ubicationY;
    [SerializeField] string city;

    CityController cityController;

    void Start(){
        GameObject canvas = GameObject.FindGameObjectWithTag("Canvas");
        cityController = canvas.GetComponent<CityController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GameObject().transform.position = new Vector3(ubicationX,ubicationY,0f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            cityController.ActivateQuestion(city, ubicationX, ubicationY);
        }
    }
}
