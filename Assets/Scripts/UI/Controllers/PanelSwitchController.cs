using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PanelSwitchController : MonoBehaviour {

    public Image panelProfile;
    public Image panelCreate;
    public Image panelFind;
    public Image panelSettings;
    public Image panelFAQ;

    public Image buttonProfileImage;
    public Image buttonCreateImage;
    public Image buttonFindImage;
    public Image buttonSettingsImage;
    public Image buttonFAQImage;

    private EnumMenuPanels enumMenuPanels;
    private Color whiteColor = Color.white;
    private Color greyColor = Color.grey;
	void Start () {
     //   appSettingsHolder = (AppSettingsHolder)Resources.Load(Constants.PATH_APP_SETTINGS_HOLDER, typeof(AppSettingsHolder));

        UpdateProfileTabs(EnumMenuPanels.profile);                       // set create tab with start scene 
	}

    public void ButtonClickProfle()
    {
        UpdateProfileTabs(EnumMenuPanels.profile);
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
            case EnumMenuPanels.profile:
                {
                    InitPanel(true,false, false, false, false);
                    buttonProfileImage.color = greyColor;
                    buttonCreateImage.color = whiteColor;
                    buttonFindImage.color = whiteColor;
                    buttonSettingsImage.color = whiteColor;
                    buttonFAQImage.color = whiteColor;
                    break;
                }
            case EnumMenuPanels.create:
                {
                    InitPanel(false,true, false, false,false);
                    buttonProfileImage.color = whiteColor;
                    buttonCreateImage.color = greyColor;
                    buttonFindImage.color = whiteColor;
                    buttonSettingsImage.color = whiteColor;
                    buttonFAQImage.color = whiteColor;
                    break;
                }
            case EnumMenuPanels.find:
                {
                    InitPanel(false, false, true, false, false);
                    buttonProfileImage.color = whiteColor;
                    buttonCreateImage.color = whiteColor;
                    buttonFindImage.color = greyColor;
                    buttonSettingsImage.color = whiteColor;
                    buttonFAQImage.color = whiteColor;
                    break;
                }
            case EnumMenuPanels.settings:
                {

                    InitPanel(false, false, false, true, false);
                    buttonProfileImage.color = whiteColor;
                    buttonCreateImage.color = whiteColor;
                    buttonFindImage.color = whiteColor;
                    buttonSettingsImage.color = greyColor;
                    buttonFAQImage.color = whiteColor;
                    break;
                }
            case EnumMenuPanels.faq:
                {
                    InitPanel(false,false, false, false, true);
                    buttonProfileImage.color = whiteColor;
                    buttonCreateImage.color = whiteColor;
                    buttonFindImage.color = whiteColor;
                    buttonSettingsImage.color = whiteColor;
                    buttonFAQImage.color = greyColor;
                    break;
                }
            default:
                {
                    Log.debug("Console: ", "PanelSwitchController - default");
                    break;
                }
        }
    }

    void InitPanel(bool isProfileActive,bool isCreateActive, bool isFindActive, bool isSettingsActive, bool isFAQActive)
    {
        panelProfile.gameObject.SetActive(isProfileActive);
        panelCreate.gameObject.SetActive(isCreateActive);
        panelFind.gameObject.SetActive(isFindActive);
        panelSettings.gameObject.SetActive(isSettingsActive);
        panelFAQ.gameObject.SetActive(isFAQActive);

    }
}
