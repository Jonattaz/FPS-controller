using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nome da classe: Personagem Herança: MonoBehaviour 
public class Personagem : MonoBehaviour
{
   //Atributos: controlador (CharacterController), saude (int)
    CharacterController controlador;

    int saude;
    [SerializeField]
    int speed;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        //Método Start: atribui o componente ao controlador e 100 a saúde
        controlador = GetComponent<CharacterController>();     
        saude = 100; 
    }

    // Update is called once per frame
    void Update()
    {
        Movimenta();
    }

    //Método Movimenta: move o controlador nos eixos X e Z conforme o pressionamento das setas
    void Movimenta(){
        moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed;

        
        controlador.Move(moveDirection * Time.deltaTime);     
    }
    
    //Método Cura: recebe um int como parâmetro, adiciona o valor do parâmetro a saude, até o limite de 100 de saude
    void Cura(int cura){
        saude += cura;
        if(saude > 100){
            saude = 100;
        }
    }
    // Método OnTriggerEnter: recebe um Collider como parâmetro, 
    //caso ele tenha a tag “Menor” chama Cura com valor 20, caso ele tenha a tag “Maior” chama Cura com valor 50
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Menor"){
            Cura(20);
        }

        if(other.gameObject.tag == "Maior"){
            Cura(50);
        }
    }
}