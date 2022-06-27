using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DoTweenTest : MonoBehaviour
{
    [SerializeField] GameObject objeto;
    
     // Tempo que leva para trocar de cor
     float timer = 0.1f;

    // Checa quanto tempo passou desde a última vez que a cor foi trocada
    private float timeChecker = 10;

    // Faz o objeto se mover
    public void Move(){       
        objeto.transform.DOMoveY(5, 4);
        
    }

    // Faz o objeto sumir
    public void Fade(){
        objeto.GetComponent<SpriteRenderer>().DOFade(0, 2);
    }

    // Restaura os valores iniciais do objeto
    public void Restore(){
        Color inicialColor = Color.white;
        objeto.transform.DOMove(new Vector2(0,0), 0);
        objeto.GetComponent<SpriteRenderer>().DOFade(1,0);
        objeto.transform.DORotate(new Vector3(0,0,0), 0);
        objeto.GetComponent<SpriteRenderer>().color = inicialColor;
        timeChecker = 10;
    }

    // Move o objeto enquanto muda a direção
    public void MoveRotateParallel(){
        objeto.transform.DOMove(new Vector2(-2,-2), 1);
        objeto.transform.DORotate(new Vector3(0,0,90), 0);
    }

    // Move o objeto e quando para ele gira
    public void MoveRotateSequence(){
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(objeto.transform.DOMove(new Vector2(2,2), 2)).Append(objeto.transform.DORotate(new Vector3(0,0,90), 2));
    }

    // Move o objeto para cima e depois para baixo
    public void MoveUpDown(){
        objeto.transform.DOMoveY(2, 0.5f).SetEase(Ease.InOutSine).SetLoops(3, LoopType.Yoyo);
    }

    // Move e depois muda a cor do objeto
    public void MoveDeactivate(){
        objeto.transform.DOMoveY(5, 2).OnComplete(ColorChange);
    }

    // Método que controla a troca de cores
    void ColorChange()
    {
        
        timeChecker += Time.deltaTime;
        if (objeto.GetComponent<SpriteRenderer>() != null && timeChecker >= timer)
        {
            //Array de cores que vai de 0 a 5
            Color[] colors = new Color[6];

            // Aqui é onde se adiciona as cores
            colors[0] = Color.blue;
            colors[1] = Color.red;
            colors[2] = Color.green;
            colors[3] = Color.cyan;
            colors[4] = Color.magenta;
            colors[5] = Color.yellow;


            objeto.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];
           
            timeChecker = 0f;
        }
    }

}
