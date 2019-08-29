using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CazDraggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    GameObject pippoimage;

    double verticalsize;
    double horizontalsize;

    int screenwidth;
    int screenheight;

    bool held = false;  // se l'immagine è tenuta

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start draggable component");
        pippoimage = GameObject.Find("PippoImage");
        Outline outline = pippoimage.GetComponent<Outline>();
        outline.enabled = false;

        // Getione button up
        GameObject buttonup = GameObject.Find("ButtonUp");
        buttonup.GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("ButtonUp click");
            float oldx = pippoimage.GetComponent<Transform>().position.x;
            float oldy = pippoimage.GetComponent<Transform>().position.y;
            Vector3 newvect = new Vector3(oldx, oldy + 1);
            pippoimage.GetComponent<Transform>().position = newvect;
            Debug.Log("newpos" + newvect);
        });

        // Getione button down
        GameObject buttondown = GameObject.Find("ButtonDown");
        buttondown.GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log("ButtonDown click");
            float oldx = pippoimage.GetComponent<Transform>().position.x;
            float oldy = pippoimage.GetComponent<Transform>().position.y;
            Vector3 newvect = new Vector3(oldx, oldy - 1);
            pippoimage.GetComponent<Transform>().position = newvect;
            Debug.Log("newpos" + newvect);
        });

        // Salvo dimensioni schermo
        verticalsize = Camera.main.orthographicSize * 2.0;
        horizontalsize = verticalsize * Screen.width / Screen.height;

        screenwidth = Screen.width;
        screenheight = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (held)
        {
            Vector3 mouse = Input.mousePosition;
            Vector3 newvect = new Vector3(mouse.x, mouse.y - 1);
            pippoimage.GetComponent<Transform>().position = newvect;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        held = true;
        //var v3 = Input.mousePosition;
        //Debug.Log("Input.ScreenToWorldPoint PRE" + v3);
        ////v3.z = 10.0f;
        //v3 = Camera.main.ScreenToWorldPoint(v3);
        //Debug.Log("Input.ScreenToWorldPoint POST" + v3);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");
        held = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnPointerClick");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");

        Outline outline = pippoimage.GetComponent<Outline>();
        outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        Outline outline = pippoimage.GetComponent<Outline>();
        outline.enabled = false;
    }
}
