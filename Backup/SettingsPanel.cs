﻿// Decompiled with JetBrains decompiler
// Type: ImprovedPublicTransport.SettingsPanel
// Assembly: ImprovedPublicTransport, Version=1.0.6177.17409, Culture=neutral, PublicKeyToken=null
// MVID: 76F370C5-F40B-41AE-AA9D-1E3F87E934D3
// Assembly location: C:\Games\Steam\steamapps\workshop\content\255710\424106600\ImprovedPublicTransport.dll

using ColossalFramework;
using ColossalFramework.UI;
using UnityEngine;

namespace ImprovedPublicTransport
{
  public class SettingsPanel : UIPanel
  {
    private UICheckBox _budgetControl;
    private UICheckBox _compatibilityMode;
    private UICheckBox _showLineInfo;
    private UITextField _spawnTimeInterval;
    private UITextField _intervalAggressionFactor;
    private UITextField _speedString;
    private UITextField _defaultVehicleCount;
    private UICheckBox _deleteBusLines;
    private UICheckBox _deleteTramLines;
    private UICheckBox _deleteMetroLines;
    private UICheckBox _deleteTrainLines;
    private UICheckBox _deleteShipLines;
    private UICheckBox _deleteAirLines;

    public override void Start()
    {
      base.Start();
      this.CreatePanel();
    }

    private void CreatePanel()
    {
      this.transform.parent = this.parent.transform;
      this.name = "IptSettingsPanel";
      this.AlignTo(this.parent, UIAlignAnchor.TopRight);
      this.relativePosition = new Vector3(this.parent.width + 1f, 0.0f);
      this.width = 344f;
      this.height = 363f;
      this.backgroundSprite = "MenuPanel2";
      this.canFocus = true;
      this.isInteractive = true;
      this.isVisible = false;
      this.eventVisibilityChanged += new PropertyChangedEventHandler<bool>(this.OnVisibilityChanged);
      UILabel uiLabel1 = this.AddUIComponent<UILabel>();
      uiLabel1.name = "Title";
      uiLabel1.text = Localization.Get("SETTINGS");
      uiLabel1.textAlignment = UIHorizontalAlignment.Center;
      uiLabel1.font = UIHelper.Font;
      uiLabel1.position = new Vector3((float) ((double) this.width / 2.0 - (double) uiLabel1.width / 2.0), (float) ((double) uiLabel1.height / 2.0 - 20.0));
      UIButton uiButton = this.AddUIComponent<UIButton>();
      uiButton.name = "CloseButton";
      uiButton.width = 32f;
      uiButton.height = 32f;
      uiButton.normalBgSprite = "buttonclose";
      uiButton.hoveredBgSprite = "buttonclosehover";
      uiButton.pressedBgSprite = "buttonclosepressed";
      uiButton.relativePosition = new Vector3((float) ((double) this.width - (double) uiButton.width - 2.0), 2f);
      uiButton.eventClick += new MouseEventHandler(this.OnCloseButtonClick);
      UIPanel uiPanel1 = this.AddUIComponent<UIPanel>();
      string str1 = "ContainerPanel";
      uiPanel1.name = str1;
      int num1 = 13;
      uiPanel1.anchor = (UIAnchorStyle) num1;
      uiPanel1.transform.localPosition = Vector3.zero;
      double num2 = (double) this.width - 12.0;
      uiPanel1.width = (float) num2;
      double num3 = (double) this.height - 60.0;
      uiPanel1.height = (float) num3;
      int num4 = 1;
      uiPanel1.autoLayout = num4 != 0;
      int num5 = 1;
      uiPanel1.autoLayoutDirection = (LayoutDirection) num5;
      RectOffset rectOffset1 = new RectOffset(0, 0, 0, 1);
      uiPanel1.autoLayoutPadding = rectOffset1;
      int num6 = 0;
      uiPanel1.autoLayoutStart = (LayoutStart) num6;
      Vector3 vector3 = new Vector3(6f, 50f);
      uiPanel1.relativePosition = vector3;
      UIPanel uiPanel2 = uiPanel1.AddUIComponent<UIPanel>();
      uiPanel2.width = uiPanel2.parent.width;
      uiPanel2.height = 30f;
      uiPanel2.autoLayoutDirection = LayoutDirection.Horizontal;
      uiPanel2.autoLayoutStart = LayoutStart.TopLeft;
      uiPanel2.autoLayoutPadding = new RectOffset(8, 0, 4, 4);
      uiPanel2.autoLayout = true;
      uiPanel2.backgroundSprite = "InfoviewPanel";
      uiPanel2.color = new Color32((byte) 128, (byte) 128, (byte) 128, byte.MaxValue);
      UIPanel uiPanel3 = uiPanel2.AddUIComponent<UIPanel>();
      Vector2 vector2_1 = new Vector2(233f, 30f);
      uiPanel3.size = vector2_1;
      int num7 = 0;
      uiPanel3.autoLayoutDirection = (LayoutDirection) num7;
      int num8 = 0;
      uiPanel3.autoLayoutStart = (LayoutStart) num8;
      RectOffset rectOffset2 = new RectOffset(0, 0, 4, 0);
      uiPanel3.autoLayoutPadding = rectOffset2;
      int num9 = 1;
      uiPanel3.autoLayout = num9 != 0;
      UICheckBox checkBox1 = UIHelper.CreateCheckBox((UIComponent) uiPanel3);
      checkBox1.name = "BudgetControl";
      checkBox1.text = Localization.Get("SETTINGS_ENABLE_BUDGET_CONTROL");
      checkBox1.tooltip = Localization.Get("SETTINGS_BUDGET_CONTROL_TOOLTIP") + System.Environment.NewLine + Localization.Get("EXPLANATION_BUDGET_CONTROL");
      checkBox1.size = new Vector2(229f, 30f);
      checkBox1.eventCheckChanged += new PropertyChangedEventHandler<bool>(this.OnBudgetCheckChanged);
      this._budgetControl = checkBox1;
      UIButton button1 = UIHelper.CreateButton((UIComponent) uiPanel2);
      string str2 = Localization.Get("SETTINGS_UPDATE");
      button1.text = str2;
      string str3 = Localization.Get("SETTINGS_BUDGET_BUTTON_TOOLTIP");
      button1.tooltip = str3;
      double num10 = 0.800000011920929;
      button1.textScale = (float) num10;
      double num11 = 80.0;
      button1.width = (float) num11;
      double num12 = 22.0;
      button1.height = (float) num12;
      MouseEventHandler mouseEventHandler1 = new MouseEventHandler(this.OnUpdateButtonClick);
      button1.eventClick += mouseEventHandler1;
      UIPanel uiPanel4 = uiPanel1.AddUIComponent<UIPanel>();
      uiPanel4.width = uiPanel4.parent.width;
      uiPanel4.height = 30f;
      uiPanel4.autoLayoutDirection = LayoutDirection.Horizontal;
      uiPanel4.autoLayoutStart = LayoutStart.TopLeft;
      uiPanel4.autoLayoutPadding = new RectOffset(8, 0, 4, 4);
      uiPanel4.autoLayout = true;
      uiPanel4.backgroundSprite = "InfoviewPanel";
      uiPanel4.color = new Color32((byte) 96, (byte) 96, (byte) 96, byte.MaxValue);
      UIPanel uiPanel5 = uiPanel4.AddUIComponent<UIPanel>();
      Vector2 vector2_2 = new Vector2(uiPanel4.width - 4f, uiPanel4.height);
      uiPanel5.size = vector2_2;
      int num13 = 0;
      uiPanel5.autoLayoutDirection = (LayoutDirection) num13;
      int num14 = 0;
      uiPanel5.autoLayoutStart = (LayoutStart) num14;
      RectOffset rectOffset3 = new RectOffset(0, 0, 4, 0);
      uiPanel5.autoLayoutPadding = rectOffset3;
      int num15 = 1;
      uiPanel5.autoLayout = num15 != 0;
      UICheckBox checkBox2 = UIHelper.CreateCheckBox((UIComponent) uiPanel5);
      checkBox2.name = "CompatibilityMode";
      checkBox2.text = Localization.Get("SETTINGS_COMPATIBILITY_MODE");
      checkBox2.tooltip = Localization.Get("SETTINGS_COMPATIBILITY_MODE_TOOLTIP");
      checkBox2.size = new Vector2(uiPanel4.width - 8f, uiPanel4.height);
      checkBox2.eventCheckChanged += new PropertyChangedEventHandler<bool>(this.OnCompatibilityModeChanged);
      this._compatibilityMode = checkBox2;
      UIPanel uiPanel6 = uiPanel1.AddUIComponent<UIPanel>();
      uiPanel6.width = uiPanel6.parent.width;
      uiPanel6.height = 30f;
      uiPanel6.autoLayoutDirection = LayoutDirection.Horizontal;
      uiPanel6.autoLayoutStart = LayoutStart.TopLeft;
      uiPanel6.autoLayoutPadding = new RectOffset(8, 0, 4, 4);
      uiPanel6.autoLayout = true;
      uiPanel6.backgroundSprite = "InfoviewPanel";
      uiPanel6.color = new Color32((byte) 128, (byte) 128, (byte) 128, byte.MaxValue);
      UILabel uiLabel2 = uiPanel6.AddUIComponent<UILabel>();
      string str4 = Localization.Get("SETTINGS_SPAWN_TIME_INTERVAL");
      uiLabel2.text = str4;
      UIFont font1 = UIHelper.Font;
      uiLabel2.font = font1;
      Color32 white1 = (Color32) Color.white;
      uiLabel2.textColor = white1;
      double num16 = 0.800000011920929;
      uiLabel2.textScale = (float) num16;
      int num17 = 0;
      uiLabel2.autoSize = num17 != 0;
      double num18 = 30.0;
      uiLabel2.height = (float) num18;
      double num19 = 180.0;
      uiLabel2.width = (float) num19;
      int num20 = 1;
      uiLabel2.verticalAlignment = (UIVerticalAlignment) num20;
      UITextField uiTextField1 = uiPanel6.AddUIComponent<UITextField>();
      uiTextField1.name = "SpawnTimeInterval";
      uiTextField1.text = "0";
      uiTextField1.tooltip = Localization.Get("SETTINGS_SPAWN_TIME_INTERVAL_TOOLTIP");
      uiTextField1.textColor = (Color32) Color.black;
      uiTextField1.selectionSprite = "EmptySprite";
      uiTextField1.normalBgSprite = "TextFieldPanelHovered";
      uiTextField1.focusedBgSprite = "TextFieldPanel";
      uiTextField1.builtinKeyNavigation = true;
      uiTextField1.submitOnFocusLost = true;
      uiTextField1.eventTextSubmitted += new PropertyChangedEventHandler<string>(this.OnSpawnTimeIntervalSubmitted);
      uiTextField1.width = 45f;
      uiTextField1.height = 22f;
      uiTextField1.maxLength = 4;
      uiTextField1.numericalOnly = true;
      uiTextField1.verticalAlignment = UIVerticalAlignment.Middle;
      uiTextField1.padding = new RectOffset(0, 0, 4, 0);
      this._spawnTimeInterval = uiTextField1;
      UIButton button2 = UIHelper.CreateButton((UIComponent) uiPanel6);
      string str5 = Localization.Get("SETTINGS_RESET");
      button2.text = str5;
      string str6 = Localization.Get("SETTINGS_SPAWN_TIME_INTERVAL_BUTTON_TOOLTIP");
      button2.tooltip = str6;
      double num21 = 0.800000011920929;
      button2.textScale = (float) num21;
      double num22 = 80.0;
      button2.width = (float) num22;
      double num23 = 22.0;
      button2.height = (float) num23;
      MouseEventHandler mouseEventHandler2 = new MouseEventHandler(this.OnResetButtonClick);
      button2.eventClick += mouseEventHandler2;
      UIPanel uiPanel7 = uiPanel1.AddUIComponent<UIPanel>();
      uiPanel7.width = uiPanel7.parent.width;
      uiPanel7.height = 30f;
      uiPanel7.autoLayoutDirection = LayoutDirection.Horizontal;
      uiPanel7.autoLayoutStart = LayoutStart.TopLeft;
      uiPanel7.autoLayoutPadding = new RectOffset(8, 0, 4, 4);
      uiPanel7.autoLayout = true;
      uiPanel7.backgroundSprite = "InfoviewPanel";
      uiPanel7.color = new Color32((byte) 96, (byte) 96, (byte) 96, byte.MaxValue);
      UILabel uiLabel3 = uiPanel7.AddUIComponent<UILabel>();
      string str7 = Localization.Get("SETTINGS_UNBUNCHING_AGGRESSION");
      uiLabel3.text = str7;
      UIFont font2 = UIHelper.Font;
      uiLabel3.font = font2;
      Color32 white2 = (Color32) Color.white;
      uiLabel3.textColor = white2;
      double num24 = 0.800000011920929;
      uiLabel3.textScale = (float) num24;
      int num25 = 0;
      uiLabel3.autoSize = num25 != 0;
      double num26 = 30.0;
      uiLabel3.height = (float) num26;
      double num27 = 180.0;
      uiLabel3.width = (float) num27;
      int num28 = 1;
      uiLabel3.verticalAlignment = (UIVerticalAlignment) num28;
      UITextField uiTextField2 = uiPanel7.AddUIComponent<UITextField>();
      uiTextField2.name = "IntervalAggressionFactor";
      uiTextField2.text = "3";
      uiTextField2.tooltip = Localization.Get("SETTINGS_UNBUNCHING_AGGRESSION_TOOLTIP") + System.Environment.NewLine + Localization.Get("EXPLANATION_UNBUNCHING");
      uiTextField2.textColor = (Color32) Color.black;
      uiTextField2.selectionSprite = "EmptySprite";
      uiTextField2.normalBgSprite = "TextFieldPanelHovered";
      uiTextField2.focusedBgSprite = "TextFieldPanel";
      uiTextField2.builtinKeyNavigation = true;
      uiTextField2.submitOnFocusLost = true;
      uiTextField2.eventTextSubmitted += new PropertyChangedEventHandler<string>(this.OnIntervalAggressionFactorSubmitted);
      uiTextField2.width = 45f;
      uiTextField2.height = 22f;
      uiTextField2.maxLength = 1;
      uiTextField2.numericalOnly = true;
      uiTextField2.verticalAlignment = UIVerticalAlignment.Middle;
      uiTextField2.padding = new RectOffset(0, 0, 4, 0);
      this._intervalAggressionFactor = uiTextField2;
      UIPanel uiPanel8 = uiPanel1.AddUIComponent<UIPanel>();
      uiPanel8.width = uiPanel8.parent.width;
      uiPanel8.height = 30f;
      uiPanel8.autoLayoutDirection = LayoutDirection.Horizontal;
      uiPanel8.autoLayoutStart = LayoutStart.TopLeft;
      uiPanel8.autoLayoutPadding = new RectOffset(8, 0, 4, 4);
      uiPanel8.autoLayout = true;
      uiPanel8.backgroundSprite = "InfoviewPanel";
      uiPanel8.color = new Color32((byte) 128, (byte) 128, (byte) 128, byte.MaxValue);
      UILabel uiLabel4 = uiPanel8.AddUIComponent<UILabel>();
      string str8 = Localization.Get("SETTINGS_VEHICLE_COUNT");
      uiLabel4.text = str8;
      UIFont font3 = UIHelper.Font;
      uiLabel4.font = font3;
      Color32 white3 = (Color32) Color.white;
      uiLabel4.textColor = white3;
      double num29 = 0.800000011920929;
      uiLabel4.textScale = (float) num29;
      int num30 = 0;
      uiLabel4.autoSize = num30 != 0;
      double num31 = 30.0;
      uiLabel4.height = (float) num31;
      double num32 = 180.0;
      uiLabel4.width = (float) num32;
      int num33 = 1;
      uiLabel4.verticalAlignment = (UIVerticalAlignment) num33;
      UITextField uiTextField3 = uiPanel8.AddUIComponent<UITextField>();
      uiTextField3.name = "DefaultVehicleCount";
      uiTextField3.text = "0";
      uiTextField3.tooltip = Localization.Get("SETTINGS_VEHICLE_COUNT_TOOLTIP");
      uiTextField3.textColor = (Color32) Color.black;
      uiTextField3.selectionSprite = "EmptySprite";
      uiTextField3.normalBgSprite = "TextFieldPanelHovered";
      uiTextField3.focusedBgSprite = "TextFieldPanel";
      uiTextField3.builtinKeyNavigation = true;
      uiTextField3.submitOnFocusLost = true;
      uiTextField3.eventTextSubmitted += new PropertyChangedEventHandler<string>(this.OnDefaultVehicleCountSubmitted);
      uiTextField3.width = 45f;
      uiTextField3.height = 22f;
      uiTextField3.maxLength = 1;
      uiTextField3.numericalOnly = true;
      uiTextField3.verticalAlignment = UIVerticalAlignment.Middle;
      uiTextField3.padding = new RectOffset(0, 0, 4, 0);
      this._defaultVehicleCount = uiTextField3;
      UIPanel uiPanel9 = uiPanel1.AddUIComponent<UIPanel>();
      uiPanel9.width = uiPanel9.parent.width;
      uiPanel9.height = 30f;
      uiPanel9.autoLayoutDirection = LayoutDirection.Horizontal;
      uiPanel9.autoLayoutStart = LayoutStart.TopLeft;
      uiPanel9.autoLayoutPadding = new RectOffset(8, 0, 4, 4);
      uiPanel9.autoLayout = true;
      uiPanel9.backgroundSprite = "InfoviewPanel";
      uiPanel9.color = new Color32((byte) 96, (byte) 96, (byte) 96, byte.MaxValue);
      UIPanel uiPanel10 = uiPanel9.AddUIComponent<UIPanel>();
      Vector2 vector2_3 = new Vector2(uiPanel9.width - 4f, uiPanel9.height);
      uiPanel10.size = vector2_3;
      int num34 = 0;
      uiPanel10.autoLayoutDirection = (LayoutDirection) num34;
      int num35 = 0;
      uiPanel10.autoLayoutStart = (LayoutStart) num35;
      RectOffset rectOffset4 = new RectOffset(0, 0, 4, 0);
      uiPanel10.autoLayoutPadding = rectOffset4;
      int num36 = 1;
      uiPanel10.autoLayout = num36 != 0;
      UICheckBox checkBox3 = UIHelper.CreateCheckBox((UIComponent) uiPanel10);
      checkBox3.name = "ShowLineInfo";
      checkBox3.text = Localization.Get("SETTINGS_AUTOSHOW_LINE_INFO");
      checkBox3.tooltip = Localization.Get("SETTINGS_AUTOSHOW_LINE_INFO_TOOLTIP");
      checkBox3.size = new Vector2(uiPanel9.width - 8f, uiPanel9.height);
      checkBox3.eventCheckChanged += new PropertyChangedEventHandler<bool>(this.OnShowLineCheckChanged);
      this._showLineInfo = checkBox3;
      UIPanel uiPanel11 = uiPanel1.AddUIComponent<UIPanel>();
      uiPanel11.width = uiPanel11.parent.width;
      uiPanel11.height = 30f;
      uiPanel11.autoLayoutDirection = LayoutDirection.Horizontal;
      uiPanel11.autoLayoutStart = LayoutStart.TopLeft;
      uiPanel11.autoLayoutPadding = new RectOffset(8, 0, 4, 4);
      uiPanel11.autoLayout = true;
      uiPanel11.backgroundSprite = "InfoviewPanel";
      uiPanel11.color = new Color32((byte) 128, (byte) 128, (byte) 128, byte.MaxValue);
      UILabel uiLabel5 = uiPanel11.AddUIComponent<UILabel>();
      string str9 = Localization.Get("SETTINGS_SPEED");
      uiLabel5.text = str9;
      UIFont font4 = UIHelper.Font;
      uiLabel5.font = font4;
      Color32 white4 = (Color32) Color.white;
      uiLabel5.textColor = white4;
      double num37 = 0.800000011920929;
      uiLabel5.textScale = (float) num37;
      int num38 = 0;
      uiLabel5.autoSize = num38 != 0;
      double num39 = 30.0;
      uiLabel5.height = (float) num39;
      double num40 = 180.0;
      uiLabel5.width = (float) num40;
      int num41 = 1;
      uiLabel5.verticalAlignment = (UIVerticalAlignment) num41;
      UITextField uiTextField4 = uiPanel11.AddUIComponent<UITextField>();
      uiTextField4.name = "MaxSpeed";
      uiTextField4.text = "";
      uiTextField4.textColor = (Color32) Color.black;
      uiTextField4.selectionSprite = "EmptySprite";
      uiTextField4.normalBgSprite = "TextFieldPanelHovered";
      uiTextField4.focusedBgSprite = "TextFieldPanel";
      uiTextField4.builtinKeyNavigation = true;
      uiTextField4.submitOnFocusLost = true;
      uiTextField4.eventTextSubmitted += new PropertyChangedEventHandler<string>(this.OnMaxSpeedSubmitted);
      uiTextField4.width = 45f;
      uiTextField4.height = 22f;
      uiTextField4.maxLength = 4;
      uiTextField4.verticalAlignment = UIVerticalAlignment.Middle;
      uiTextField4.padding = new RectOffset(0, 0, 4, 0);
      this._speedString = uiTextField4;
      UIPanel uiPanel12 = uiPanel1.AddUIComponent<UIPanel>();
      uiPanel12.width = uiPanel12.parent.width;
      uiPanel12.height = 90f;
      uiPanel12.autoLayoutDirection = LayoutDirection.Vertical;
      uiPanel12.autoLayoutStart = LayoutStart.TopLeft;
      uiPanel12.autoLayoutPadding = new RectOffset(8, 0, 0, 0);
      uiPanel12.autoLayout = true;
      uiPanel12.backgroundSprite = "InfoviewPanel";
      uiPanel12.color = new Color32((byte) 96, (byte) 96, (byte) 96, byte.MaxValue);
      UIPanel uiPanel13 = uiPanel12.AddUIComponent<UIPanel>();
      uiPanel13.width = uiPanel12.width - (float) uiPanel12.autoLayoutPadding.left;
      uiPanel13.height = 30f;
      uiPanel13.autoLayoutDirection = LayoutDirection.Horizontal;
      uiPanel13.autoLayoutStart = LayoutStart.TopLeft;
      uiPanel13.autoLayoutPadding = new RectOffset(0, 0, 7, 0);
      uiPanel13.autoLayout = true;
      UILabel uiLabel6 = uiPanel13.AddUIComponent<UILabel>();
      string str10 = Localization.Get("SETTINGS_LINE_DELETION_TOOL");
      uiLabel6.text = str10;
      UIFont font5 = UIHelper.Font;
      uiLabel6.font = font5;
      Color32 white5 = (Color32) Color.white;
      uiLabel6.textColor = white5;
      double num42 = 0.800000011920929;
      uiLabel6.textScale = (float) num42;
      int num43 = 0;
      uiLabel6.autoSize = num43 != 0;
      double num44 = 30.0;
      uiLabel6.height = (float) num44;
      double num45 = 241.0;
      uiLabel6.width = (float) num45;
      int num46 = 1;
      uiLabel6.verticalAlignment = (UIVerticalAlignment) num46;
      UIButton button3 = UIHelper.CreateButton((UIComponent) uiPanel13);
      string str11 = Localization.Get("SETTINGS_DELETE");
      button3.text = str11;
      string str12 = Localization.Get("SETTINGS_LINE_DELETION_TOOL_BUTTON_TOOLTIP");
      button3.tooltip = str12;
      double num47 = 0.800000011920929;
      button3.textScale = (float) num47;
      double num48 = 80.0;
      button3.width = (float) num48;
      double num49 = 22.0;
      button3.height = (float) num49;
      MouseEventHandler mouseEventHandler3 = new MouseEventHandler(this.OnDeleteLinesClick);
      button3.eventClick += mouseEventHandler3;
      UIPanel uiPanel14 = uiPanel12.AddUIComponent<UIPanel>();
      uiPanel14.width = uiPanel12.width - (float) uiPanel12.autoLayoutPadding.left;
      uiPanel14.height = 30f;
      uiPanel14.autoLayoutDirection = LayoutDirection.Horizontal;
      uiPanel14.autoLayoutStart = LayoutStart.TopLeft;
      uiPanel14.autoLayoutPadding = new RectOffset(0, 0, 7, 0);
      uiPanel14.autoLayout = true;
      this._deleteBusLines = UIHelper.CreateCheckBox((UIComponent) uiPanel14);
      this._deleteBusLines.text = ColossalFramework.Globalization.Locale.Get("INFO_PUBLICTRANSPORT_BUS");
      this._deleteBusLines.width = uiPanel14.width / 3f;
      this._deleteTramLines = UIHelper.CreateCheckBox((UIComponent) uiPanel14);
      this._deleteTramLines.text = ColossalFramework.Globalization.Locale.Get("INFO_PUBLICTRANSPORT_TRAM");
      this._deleteTramLines.width = uiPanel14.width / 3f;
      this._deleteMetroLines = UIHelper.CreateCheckBox((UIComponent) uiPanel14);
      this._deleteMetroLines.text = ColossalFramework.Globalization.Locale.Get("INFO_PUBLICTRANSPORT_METRO");
      this._deleteMetroLines.width = uiPanel14.width / 3f;
      UIPanel uiPanel15 = uiPanel12.AddUIComponent<UIPanel>();
      uiPanel15.width = uiPanel12.width - (float) uiPanel12.autoLayoutPadding.left;
      uiPanel15.height = 30f;
      uiPanel15.autoLayoutDirection = LayoutDirection.Horizontal;
      uiPanel15.autoLayoutStart = LayoutStart.TopLeft;
      uiPanel15.autoLayoutPadding = new RectOffset(0, 0, 7, 0);
      uiPanel15.autoLayout = true;
      this._deleteTrainLines = UIHelper.CreateCheckBox((UIComponent) uiPanel15);
      this._deleteTrainLines.text = ColossalFramework.Globalization.Locale.Get("INFO_PUBLICTRANSPORT_TRAIN");
      this._deleteTrainLines.width = uiPanel15.width / 3f;
      this._deleteShipLines = UIHelper.CreateCheckBox((UIComponent) uiPanel15);
      this._deleteShipLines.text = ColossalFramework.Globalization.Locale.Get("INFO_PUBLICTRANSPORT_SHIP");
      this._deleteShipLines.width = uiPanel15.width / 3f;
      this._deleteAirLines = UIHelper.CreateCheckBox((UIComponent) uiPanel15);
      this._deleteAirLines.text = ColossalFramework.Globalization.Locale.Get("INFO_PUBLICTRANSPORT_PLANE");
      this._deleteAirLines.width = uiPanel15.width / 3f;
    }

    private void OnVisibilityChanged(UIComponent component, bool visible)
    {
      if (!visible)
        return;
      this._budgetControl.isChecked = ImprovedPublicTransportMod.Settings.BudgetControl;
      this._compatibilityMode.isChecked = ImprovedPublicTransportMod.Settings.CompatibilityMode;
      this._spawnTimeInterval.text = ImprovedPublicTransportMod.Settings.SpawnTimeInterval.ToString();
      this._intervalAggressionFactor.text = ImprovedPublicTransportMod.Settings.IntervalAggressionFactor.ToString();
      this._speedString.text = ImprovedPublicTransportMod.Settings.SpeedString;
      this._showLineInfo.isChecked = ImprovedPublicTransportMod.Settings.ShowLineInfo;
      this._defaultVehicleCount.text = ImprovedPublicTransportMod.Settings.DefaultVehicleCount.ToString();
      this._deleteBusLines.isChecked = false;
      this._deleteTramLines.isChecked = false;
      this._deleteMetroLines.isChecked = false;
      this._deleteTrainLines.isChecked = false;
      this._deleteShipLines.isChecked = false;
      this._deleteAirLines.isChecked = false;
    }

    private void OnCloseButtonClick(UIComponent component, UIMouseEventParameter eventParam)
    {
      this.isVisible = !this.isVisible;
    }

    private void OnBudgetCheckChanged(UIComponent component, bool isChecked)
    {
      if (ImprovedPublicTransportMod.Settings.BudgetControl == isChecked)
        return;
      ImprovedPublicTransportMod.Settings.BudgetControl = isChecked;
      TransportManager instance = Singleton<TransportManager>.instance;
      int length = instance.m_lines.m_buffer.Length;
      for (int index = 0; index < length; ++index)
      {
        if (!instance.m_lines.m_buffer[index].Complete)
          TransportLineMod.SetBudgetControlState((ushort) index, isChecked);
      }
    }

    private void OnCompatibilityModeChanged(UIComponent component, bool isChecked)
    {
      if (ImprovedPublicTransportMod.Settings.CompatibilityMode == isChecked)
        return;
      Utils.Log((object) ("Changing compatibility mode: " + (isChecked ? "on" : "off")));
      ImprovedPublicTransportMod.Settings.CompatibilityMode = isChecked;
      if (isChecked)
        TransportLineMod.RevertDetourUpdateMeshData();
      else
        TransportLineMod.DetourUpdateMeshData();
    }

    private void OnShowLineCheckChanged(UIComponent component, bool isChecked)
    {
      ImprovedPublicTransportMod.Settings.ShowLineInfo = isChecked;
    }

    private void OnUpdateButtonClick(UIComponent component, UIMouseEventParameter eventParam)
    {
      int length = Singleton<TransportManager>.instance.m_lines.m_buffer.Length;
      for (int index = 0; index < length; ++index)
      {
        TransportLineMod.SetBudgetControlState((ushort) index, this._budgetControl.isChecked);
        if (this._budgetControl.isChecked)
          TransportLineMod.ClearEnqueuedVehicles((ushort) index);
      }
    }

    private void OnSpawnTimeIntervalSubmitted(UIComponent component, string text)
    {
      ImprovedPublicTransportMod.Settings.SpawnTimeInterval = Utils.ToInt32(text);
    }

    private void OnIntervalAggressionFactorSubmitted(UIComponent component, string text)
    {
      ImprovedPublicTransportMod.Settings.IntervalAggressionFactor = Utils.ToByte(text);
    }

    private void OnDefaultVehicleCountSubmitted(UIComponent component, string text)
    {
      int int32 = Utils.ToInt32(text);
      ImprovedPublicTransportMod.Settings.DefaultVehicleCount = int32;
      TransportManager instance = Singleton<TransportManager>.instance;
      int length = instance.m_lines.m_buffer.Length;
      for (int index = 0; index < length; ++index)
      {
        if (!instance.m_lines.m_buffer[index].Complete)
          TransportLineMod.SetTargetVehicleCount((ushort) index, int32);
      }
    }

    private void OnResetButtonClick(UIComponent component, UIMouseEventParameter eventParam)
    {
      int length = Singleton<TransportManager>.instance.m_lines.m_buffer.Length;
      for (int index = 0; index < length; ++index)
        TransportLineMod.SetNextSpawnTime((ushort) index, 0.0f);
    }

    private void OnMaxSpeedSubmitted(UIComponent component, string text)
    {
      ImprovedPublicTransportMod.Settings.SpeedString = text;
    }

    private void OnDeleteLinesClick(UIComponent component, UIMouseEventParameter eventParam)
    {
      if (!this._deleteBusLines.isChecked && !this._deleteTramLines.isChecked && (!this._deleteMetroLines.isChecked && !this._deleteTrainLines.isChecked) && (!this._deleteShipLines.isChecked && !this._deleteAirLines.isChecked))
        return;
      WorldInfoPanel.Hide<PublicTransportWorldInfoPanel>();
      ConfirmPanel.ShowModal(Localization.Get("SETTINGS_LINE_DELETION_TOOL_CONFIRM_TITLE"), Localization.Get("SETTINGS_LINE_DELETION_TOOL_CONFIRM_MSG"), (UIView.ModalPoppedReturnCallback) ((s, r) =>
      {
        if (r != 1)
          return;
        Singleton<SimulationManager>.instance.AddAction(new System.Action(this.DeleteLines));
      }));
    }

    private void DeleteLines()
    {
      TransportManager instance = Singleton<TransportManager>.instance;
      int length = instance.m_lines.m_buffer.Length;
      for (int index = 0; index < length; ++index)
      {
        TransportInfo info = instance.m_lines.m_buffer[index].Info;
        if (!((UnityEngine.Object) info == (UnityEngine.Object) null))
        {
          bool flag = false;
          switch (info.GetSubService())
          {
            case ItemClass.SubService.PublicTransportBus:
              flag = this._deleteBusLines.isChecked;
              break;
            case ItemClass.SubService.PublicTransportMetro:
              flag = this._deleteMetroLines.isChecked;
              break;
            case ItemClass.SubService.PublicTransportTrain:
              flag = this._deleteTrainLines.isChecked;
              break;
            case ItemClass.SubService.PublicTransportShip:
              flag = this._deleteShipLines.isChecked;
              break;
            case ItemClass.SubService.PublicTransportPlane:
              flag = this._deleteAirLines.isChecked;
              break;
            case ItemClass.SubService.PublicTransportTram:
              flag = this._deleteTramLines.isChecked;
              break;
          }
          if (flag)
            instance.ReleaseLine((ushort) index);
        }
      }
    }
  }
}
