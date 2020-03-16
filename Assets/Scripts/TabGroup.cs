using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour {

    public List<TabButton> tabButtons;

    [Header("Sprites")]
    public Sprite spriteIdle;
    public Sprite spriteHover;
    public Sprite spriteSelected;

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

    public void OnTabEnter(TabButton button) {
        ResetTabs();

        //Prevent enter event from selected tab
        if(selectedTab != null && button == selectedTab) return;

        button.SetBackground(spriteHover);
    }

    public void OnTabExit(TabButton button) {
        ResetTabs();
    }

    public void OnTabSelected(TabButton button) {
        selectedTab = button;
        ResetTabs();
        button.SetBackground(spriteSelected);
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
