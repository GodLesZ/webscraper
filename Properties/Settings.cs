using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace GodLesZ.Tools.WebScraper.Properties
{
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
  [CompilerGenerated]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) Synchronized(new Settings());

    public static Settings Default
    {
      get
      {
        return defaultInstance;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("0, 0")]
    [DebuggerNonUserCode]
    public Point WindowLocation
    {
      get
      {
        return (Point) this["WindowLocation"];
      }
      set
      {
        this["WindowLocation"] = value;
      }
    }

    [DefaultSettingValue("936, 691")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public Size WindowSize
    {
      get
      {
        return (Size) this["WindowSize"];
      }
      set
      {
        this["WindowSize"] = value;
      }
    }

    [DefaultSettingValue("0")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public int WindowState
    {
      get
      {
        return (int) this["WindowState"];
      }
      set
      {
        this["WindowState"] = value;
      }
    }

    [DebuggerNonUserCode]
    [DefaultSettingValue("1")]
    [UserScopedSetting]
    public int WindowStartPostion
    {
      get
      {
        return (int) this["WindowStartPostion"];
      }
      set
      {
        this["WindowStartPostion"] = value;
      }
    }

    [DebuggerNonUserCode]
    [DefaultSettingValue("2010-09-01")]
    [UserScopedSetting]
    public DateTime FirstUsageDate
    {
      get
      {
        return (DateTime) this["FirstUsageDate"];
      }
      set
      {
        this["FirstUsageDate"] = value;
      }
    }

    [DefaultSettingValue("2010-09-01")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public DateTime LastUsageDate
    {
      get
      {
        return (DateTime) this["LastUsageDate"];
      }
      set
      {
        this["LastUsageDate"] = value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    public AutoCompleteStringCollection VisitedUrlList
    {
      get
      {
        return (AutoCompleteStringCollection) this["VisitedUrlList"];
      }
      set
      {
        this["VisitedUrlList"] = value;
      }
    }

    [DefaultSettingValue("False")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public bool ProxyEnabled
    {
      get
      {
        return (bool) this["ProxyEnabled"];
      }
      set
      {
        this["ProxyEnabled"] = value ? true : false;
      }
    }

    [DefaultSettingValue("0")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public byte ProxyType
    {
      get
      {
        return (byte) this["ProxyType"];
      }
      set
      {
        this["ProxyType"] = value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    public ArrayList ProxyDataList
    {
      get
      {
        return (ArrayList) this["ProxyDataList"];
      }
      set
      {
        this["ProxyDataList"] = value;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("1")]
    [DebuggerNonUserCode]
    public byte ProxyRotateInterval
    {
      get
      {
        return (byte) this["ProxyRotateInterval"];
      }
      set
      {
        this["ProxyRotateInterval"] = value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool MineAutoScroll
    {
      get
      {
        return (bool) this["MineAutoScroll"];
      }
      set
      {
        this["MineAutoScroll"] = value ? true : false;
      }
    }

    [DefaultSettingValue("")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public string DBServerName
    {
      get
      {
        return (string) this["DBServerName"];
      }
      set
      {
        this["DBServerName"] = value;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("")]
    [DebuggerNonUserCode]
    public string DBUserName
    {
      get
      {
        return (string) this["DBUserName"];
      }
      set
      {
        this["DBUserName"] = value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    public string DBName
    {
      get
      {
        return (string) this["DBName"];
      }
      set
      {
        this["DBName"] = value;
      }
    }

    [DebuggerNonUserCode]
    [DefaultSettingValue("True")]
    [UserScopedSetting]
    public bool DBWindowsAuth
    {
      get
      {
        return (bool) this["DBWindowsAuth"];
      }
      set
      {
        this["DBWindowsAuth"] = value ? true : false;
      }
    }

    [DefaultSettingValue("False")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public bool MineAllPages
    {
      get
      {
        return (bool) this["MineAllPages"];
      }
      set
      {
          this["MineAllPages"] = value ? true : false;
      }
    }

    [DefaultSettingValue("857, 644")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public Size MineWindowSize
    {
      get
      {
        return (Size) this["MineWindowSize"];
      }
      set
      {
        this["MineWindowSize"] = value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool MineWindowMaximized
    {
      get
      {
        return (bool) this["MineWindowMaximized"];
      }
      set
      {
          this["MineWindowMaximized"] = value ? true : false;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("0, 0")]
    [DebuggerNonUserCode]
    public Point MineWindowLocation
    {
      get
      {
        return (Point) this["MineWindowLocation"];
      }
      set
      {
        this["MineWindowLocation"] = value;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("5")]
    [DebuggerNonUserCode]
    public uint AjaxLoadTimeout
    {
      get
      {
        return (uint) this["AjaxLoadTimeout"];
      }
      set
      {
        this["AjaxLoadTimeout"] = value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool MinerInjectPauses
    {
      get
      {
        return (bool) this["MinerInjectPauses"];
      }
      set
      {
          this["MinerInjectPauses"] = value ? true : false;
      }
    }

    [DefaultSettingValue("15")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public uint MinerPauseInterval
    {
      get
      {
        return (uint) this["MinerPauseInterval"];
      }
      set
      {
        this["MinerPauseInterval"] = value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("10")]
    public uint MinerPauseTime
    {
      get
      {
        return (uint) this["MinerPauseTime"];
      }
      set
      {
        this["MinerPauseTime"] = value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool MinerAutoSave
    {
      get
      {
        return (bool) this["MinerAutoSave"];
      }
      set
      {
          this["MinerAutoSave"] = value ? true : false;
      }
    }

    [DebuggerNonUserCode]
    [DefaultSettingValue("")]
    [UserScopedSetting]
    public string MinerAutoSaveFileName
    {
      get
      {
        return (string) this["MinerAutoSaveFileName"];
      }
      set
      {
        this["MinerAutoSaveFileName"] = value;
      }
    }

    [DefaultSettingValue("100")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public int MinerAutoSaveRowCount
    {
      get
      {
        return (int) this["MinerAutoSaveRowCount"];
      }
      set
      {
        this["MinerAutoSaveRowCount"] = value;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("False")]
    public bool ProxyRotate
    {
      get
      {
        return (bool) this["ProxyRotate"];
      }
      set
      {
          this["ProxyRotate"] = value ? true : false;
      }
    }

    [DefaultSettingValue("")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public string DBTableName
    {
      get
      {
        return (string) this["DBTableName"];
      }
      set
      {
        this["DBTableName"] = value;
      }
    }

    [DefaultSettingValue("0")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public int DBType
    {
      get
      {
        return (int) this["DBType"];
      }
      set
      {
        this["DBType"] = value;
      }
    }

    [DefaultSettingValue("")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public string DBPwd
    {
      get
      {
        return (string) this["DBPwd"];
      }
      set
      {
        this["DBPwd"] = value;
      }
    }

    [DefaultSettingValue("False")]
    [DebuggerNonUserCode]
    [UserScopedSetting]
    public bool MinerRemoveDuplicates
    {
      get
      {
        return (bool) this["MinerRemoveDuplicates"];
      }
      set
      {
          this["MinerRemoveDuplicates"] = value ? true : false;
      }
    }

    [DefaultSettingValue("CategoryColumn")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public string CategoryTagColName
    {
      get
      {
        return (string) this["CategoryTagColName"];
      }
      set
      {
        this["CategoryTagColName"] = value;
      }
    }

    [DefaultSettingValue("False")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public bool EnableCategoryTagging
    {
      get
      {
        return (bool) this["EnableCategoryTagging"];
      }
      set
      {
          this["EnableCategoryTagging"] = value ? true : false;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("30")]
    public uint PageLoadTimeout
    {
      get
      {
        return (uint) this["PageLoadTimeout"];
      }
      set
      {
        this["PageLoadTimeout"] = value;
      }
    }

    [DefaultSettingValue("False")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public bool CategoryDoNotParse
    {
      get
      {
        return (bool) this["CategoryDoNotParse"];
      }
      set
      {
          this["CategoryDoNotParse"] = value ? true : false;
      }
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("2010-09-01")]
    public DateTime lastUpdateCheck
    {
      get
      {
        return (DateTime) this["lastUpdateCheck"];
      }
      set
      {
        this["lastUpdateCheck"] = value;
      }
    }

    [DebuggerNonUserCode]
    [UserScopedSetting]
    [DefaultSettingValue("10")]
    public int MinChildCount
    {
      get
      {
        return (int) this["MinChildCount"];
      }
      set
      {
        this["MinChildCount"] = value;
      }
    }

    [DefaultSettingValue("2")]
    [UserScopedSetting]
    [DebuggerNonUserCode]
    public int MinLevelsUp
    {
      get
      {
        return (int) this["MinLevelsUp"];
      }
      set
      {
        this["MinLevelsUp"] = value;
      }
    }

    private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
    {
    }

    private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
    {
    }
  }
}
