public class AutoUpdater
{
    public static void CheckUpdate()
    {
        try
        {
            string onlineFile = "https://raw.githubusercontent.com/TheSmokie/Project-X/master/%233%20Orc%20%26%20Troll%20%20(6-10)";    
            Quester.Bot.QuesterSetting.Load();
            string profileName = "#3 Orc & Troll  (6-10).xml";

            string currentFile = System.Windows.Forms.Application.StartupPath + @"\Profiles\Quester\Project X\" + profileName;
            var currentFileContent = System.IO.File.ReadAllText(currentFile, System.Text.Encoding.UTF8);
            var onlineFileContent = new System.Net.WebClient { Encoding = System.Text.Encoding.UTF8 }.DownloadString(onlineFile);

            if (!string.IsNullOrWhiteSpace(currentFileContent) && !string.IsNullOrWhiteSpace(onlineFileContent))
            {
                    if (currentFileContent != onlineFileContent) // if new update
                    {
                        robotManager.Helpful.Logging.Write("New version found, try to update file", (Logging.LogType)1, System.Drawing.Color.Red);
                        System.IO.File.WriteAllText(currentFile, onlineFileContent); // replace user file by online file
                        new System.Threading.Thread(() => robotManager.Products.Products.ProductRestart()).Start(); // reload product (profile)
                    }
            }

            if(currentFileContent == onlineFileContent)
            {
                robotManager.Helpful.Logging.Write("[Auto Updater]The version on your pc is the latest updated version.", (Logging.LogType)1, System.Drawing.Color.Red);
            }
        }
        catch (System.Exception e)
        {
            robotManager.Helpful.Logging.WriteError("Auto update: " + e);
        }
    }
}