using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public TabGroup tabGroup;

    public UnityEvent onTabSelected, onTabDeselected;

    private Image background;


    private void Awake() {
        background = GetComponent<Image>();
    }

    private void Start() {
        tabGroup.Subscribe(this);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData) {
        tabGroup.OnTabExit(this);
    }

    public void OnPointerClick(PointerEventData eventData) {
        tabGroup.OnTabSelected(this);
    }

    public void SetBackground(Sprite sprite) {
        background.sprite = sprite;
    }

    /// <summary>
    /// Called when this button has been selected
    /// </summary>
    public void Select() {
        if(onTabSelected != null)
            onTabSelected.Invoke();
    }

    /// <summary>
    /// Called when this button has been deselected
    /// </summary>
    public void Deselect() {
        if(onTabDeselected != null)
            onTabDeselected.Invoke();
    }

}
