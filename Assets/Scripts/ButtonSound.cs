using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioSource audioSource;

    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach(GameObject go in eventData.hovered)
        {
            //Debug.Log(go.name);
            if(go.TryGetComponent<Button>(out Button button))
            {
                //Debug.Log("Je suis sur " + button.name);
                audioSource.Play();
            }
        }
    }
}
