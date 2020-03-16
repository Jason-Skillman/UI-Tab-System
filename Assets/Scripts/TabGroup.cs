using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour {

    public List<GameObject> pages;

    [Header("Hover Sprites")]
    public Sprite spriteIdle;
    public Sprite spriteHover;
    public Sprite spriteSelected;

    private List<TabButton> tabButtons;
    private TabButton selectedTab;


    private void Awake() {
        tabButtons = new List<TabButton>();
    }

    /// <summary>
    /// Subscribes the button to this group
    /// </summary>
    /// <param name="button"></param>
    public void Subscribe(TabButton button) {
        tabButtons.Add(button);
    }

    /// <summary>
    /// Event for when a TabButton has triggered a hover enter event
    /// </summary>
    /// <param name="button"></param>
    public void OnTabEnter(TabButton button) {
        ResetTabs();

        //Prevent enter event from selected tab
        if(selectedTab != null && button == selectedTab) return;

        button.SetBackground(spriteHover);
    }

    /// <summary>
    /// Event for when a TabButton has triggered a hover exit event
    /// </summary>
    /// <param name="button"></param>
    public void OnTabExit(TabButton button) {
        ResetTabs();
    }

    /// <summary>
    /// Event for when a TabButton has been selected
    /// </summary>
    /// <param name="button"></param>
    public void OnTabSelected(TabButton button) {
        selectedTab = button;

        ResetTabs();
        button.SetBackground(spriteSelected);

        //Turn on the correct page and disable the rest
        int index = button.transform.GetSiblingIndex();
        for(int i = 0; i < pages.Count; i++) {
            if(i == index)
                pages[i].SetActive(true);
            else
                pages[i].SetActive(false);
        }
    }

    /// <summary>
    /// Sets all of the buttons background to idle
    /// </summary>
    public void ResetTabs() {
        foreach(TabButton button in tabButtons) {
            //Dont reset the selected tab
            if(selectedTab != null && button == selectedTab) continue;

            button.SetBackground(spriteIdle);
        }
    }

}
