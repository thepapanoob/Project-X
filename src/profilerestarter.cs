public class ProfileRestarter
{
    private static bool _IsAfk = false;
    private static Vector3 afkPosition = (Vector3)null;
    private static int timer = 0;
    private static bool _isSubscribed = false;
    private static void WatchForEvents()
    {
        if (!_isSubscribed)
        {
            _isSubscribed = true;

            EventsLuaWithArgs.OnEventsLuaWithArgs += (LuaEventsId id, List&lt;string&gt; args) =&gt;
            {
                if (id == wManager.Wow.Enums.LuaEventsId.CHAT_MSG_SYSTEM &amp;&amp; Conditions.ProductIsStartedNotInPause)
                {

                    if (args.FirstOrDefault().Contains("You are now AFK"))
                    {
                        _IsAfk = true;
                        timer = 0;
                        afkPosition = ObjectManager.Me.Position;
                    }
                }
            };
        }
    }

    public static void StartProfileRestarter()
    {
        Thread ProfileRestarterThread = new Thread(() =&gt;
        {
            Logging.Write("[Restarter]: Profile Restarter initialized");

            string profileName = "Project X\\Project X launcher.xml";
            string currentProfileName = wManager.Wow.Helpers.Quest.QuesterCurrentContext.ProfileName;


            while ((wManager.Wow.Helpers.Quest.QuesterCurrentContext.ProfileName.Equals(profileName) || !ObjectManager.Me.GetMove) &amp;&amp; Conditions.ProductIsStarted)
            {
                Thread.Sleep(1000);
            }

            if (!_isSubscribed)
            {
                Thread.Sleep(Usefuls.Latency + 500);
                WatchForEvents();
            }

            while (Conditions.ProductIsStarted || Conditions.ProductInPause)
            {
                if (wManager.Wow.Helpers.Quest.QuesterCurrentContext.ProfileName.Equals(profileName))
                    break;

                while (_IsAfk &amp;&amp; timer &lt; 600 &amp;&amp; !wManager.Wow.Helpers.Quest.QuesterCurrentContext.ProfileName.Equals(profileName))
                {
                    Thread.Sleep(1000);
                    timer++;
                }

                if (_IsAfk &amp;&amp; timer &gt;= 600 &amp;&amp; ObjectManager.Me.Position.DistanceTo(afkPosition) &lt; 25)
                {
                    Logging.Write("[Restarter]: Bot seems to have stopped / went AFK for too long. Restart of profile in process...");
                    wManager.Wow.Helpers.Quest.QuesterCurrentContext.ProfileName = profileName;
                    robotManager.Products.Products.ProductRestart();
                    break;
                }

                timer = 0;
                _IsAfk = false;
                Thread.Sleep(10000);
            }

            Logging.Write("[Restarter]: Profile Restarter disposed");
        });

        ProfileRestarterThread.Start();
    }
}