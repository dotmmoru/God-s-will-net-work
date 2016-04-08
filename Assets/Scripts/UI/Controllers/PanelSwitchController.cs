using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PanelSwitchController : MonoBehaviour {

    public Image panelCreate;
    public Image panelFind;
    public Image panelSettings;
    public Image panelFAQ;

    public Image buttonCreateImage;
    public Image buttonFindImage;
    public Image buttonSettingsImage;
    public Image buttonFAQImage;

    private EnumMenuPanels enumMenuPanels;
    private Color whiteColor = Color.white;
    private Color greyColor = Color.grey;
	void Start () {
     //   appSettingsHolder = (AppSettingsHolder)Resources.Load(Constants.PATH_APP_SETTINGS_HOLDER, typeof(AppSettingsHolder));

        UpdateProfileTabs(EnumMenuPanels.create);                       // set create tab with start scene 
	}

    public void ButtonClickCreate()
    {

        UpdateProfileTabs(EnumMenuPanels.create);
    }
    public void ButtonClickFind()
    {
        UpdateProfileTabs(EnumMenuPanels.find);
    }

    public void ButtonClickSettings()
    {
        UpdateProfileTabs(EnumMenuPanels.settings);
    }
    public void ButtonClickFAQ()
    {
        UpdateProfileTabs(EnumMenuPanels.faq);
    }

    void UpdateProfileTabs(EnumMenuPanels enumMenuPanels)
    {
       // appSettingsHolder.currentProfileSceneTabs = enumProfileSceneTabs;
        switch (enumMenuPanels)
        {
            case EnumMenuPanels.create:
                {
                    InitPanel(true, false, false,false);
                    buttonCreateImage.color = greyColor;
                    buttonFindImage.color = whiteColor;
                    buttonSettingsImage.color = whiteColor;
                    buttonFAQImage.color = whiteColor;
                    break;
                }
            case EnumMenuPanels.find:
                {
                    InitPanel(false, true, false,false);
                    buttonCreateImage.color = whiteColor;
                    buttonFindImage.color = greyColor;
                    buttonSettingsImage.color = whiteColor;
                    buttonFAQImage.color = whiteColor;
                    break;
                }
            case EnumMenuPanels.settings:
                {
                   
                    InitPanel(false, false, true,false);
                    buttonCreateImage.color = whiteColor;
                    buttonFindImage.color = whiteColor;
                    buttonSettingsImage.color = greyColor;
                    buttonFAQImage.color = whiteColor;
                    break;
                }
            case EnumMenuPanels.faq:
                {
                    InitPanel(false, false, false,true);
                    buttonCreateImage.color = whiteColor;
                    buttonFindImage.color = whiteColor;
                    buttonSettingsImage.color = whiteColor;
                    buttonFAQImage.color = greyColor;
                    break;
                }
            default:
                {
                    //Log.debug("Scene Profile ", "profile tabs error");
                    break;
                }
        }
    }

    void InitPanel(bool isCreateActive, bool isFindActive, bool isSettingsActive, bool isFAQActive)
    {
        panelCreate.gameObject.SetActive(isCreateActive);
        panelFind.gameObject.SetActive(isFindActive);
        panelSettings.gameObject.SetActive(isSettingsActive);
        panelFAQ.gameObject.SetActive(isFAQActive);

    }
}
