using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler {

    public TabGroup tabGroup;

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

}
