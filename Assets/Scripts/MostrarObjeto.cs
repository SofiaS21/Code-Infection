using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarObjeto : MonoBehaviour
{
    public GameObject canvasE;
    public CanvasGroup canvasGroup;


    bool jugadorCerca;

    void Start()
    {
        canvasE.SetActive(false);
        canvasGroup.alpha = 0;
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Recogido " + gameObject.name );

            //Agregar al inventario
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            jugadorCerca = true;
            StopAllCoroutines();
            StartCoroutine(Mostrar());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            jugadorCerca = false;
            StopAllCoroutines();
            StartCoroutine(Ocultar());       
        }
    }   

    IEnumerator Mostrar()
        {
            canvasE.SetActive(true);

            canvasGroup.alpha = 0;

            Vector3 fin = canvasE.transform.localScale;
            Vector3 inicio = fin * 0.7f;

            canvasE.transform.localScale = inicio;

            float t = 0;

            while(t < 1)
            {
                t += Time.deltaTime * 5;

                canvasGroup.alpha = t;
                canvasE.transform.localScale = Vector3.Lerp(inicio, fin, t);

                yield return null;
            }

            canvasGroup.alpha = 1;
            canvasE.transform.localScale = fin;
        }

    IEnumerator Ocultar()
        {
            while(canvasGroup.alpha > 0)
            {
                canvasGroup.alpha -= Time.deltaTime * 6f;
                yield return null;
            }

            canvasGroup.alpha = 0;
            canvasE.SetActive(false);
        }
}
