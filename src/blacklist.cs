public class blacklistzone
{
    public static void List()
    {
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1733.73, -4426.244, 37.31858, "None"), 5.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1748.4, -4416.781, 37.27323, "None"), 5.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1668.088, -4391.733, 22.17756, "None"), 5.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1666.025, -4365.162, 27.4433, "None"), 7.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1537.106, -4379.451, 16.90634, "None"), 5.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1549.166, -4327.502, 20.44855, "None"), 5.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1737.044, -4478.17, 32.06934, "None"), 4.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1888.123, -4452.734, 19.73206, "None"), 5.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1856.235, -4422.517, 7.30606, "None"), 5.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1856.235, -4422.517, 7.30606, "None"), 5.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1890.279, -4417.67, 12.51004, "None"), 5.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1940.485, -4693.287, 29.72934, "None"), 5.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(1872.12, -4522.215, 26.97758, "None"), 5.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(-628.2213f, -4465.777f, 46.50518f, "None"), 30.00f, true);
        wManager.wManagerSetting.AddBlackListZone(new Vector3(-1137.053f, -5571.709f, 9.907743f, "None"),25.00f,true);
        Logging.Write("[Blacklist]: Blacklist Activated.");
        wManager.wManagerSetting.CurrentSetting.Save();  
    }
}