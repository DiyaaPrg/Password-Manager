using System.Runtime.InteropServices;
using static Guna.UI2.WinForms.Suite.Descriptions;
using PasswordsManagement.Properties;

namespace PasswordsManagement_Business
{
    public class clsInactivityMonitor
    {
        private static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public static event Action OnLogOut;

        protected virtual void LogOut()
        {
            Action handler = OnLogOut;
            if (handler != null)
            {
                handler();
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        private static uint GetIdleTimeInSeconds()
        {
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();

            lastInputInfo.cbSize = (uint)Marshal.SizeOf(lastInputInfo);

            GetLastInputInfo(ref lastInputInfo);

            uint idleTime = (uint)Environment.TickCount - lastInputInfo.dwTime;

            return idleTime / 1000;
        }

        private static void Timer_Tick(object? sender, EventArgs e)
        {
            if (Settings.Default.AutoLockMinutes == -1)
                return;

            uint idleSeconds = GetIdleTimeInSeconds();

            uint autoLockSeconds =
                (uint)Settings.Default.AutoLockMinutes * 60;

            if (idleSeconds >= autoLockSeconds)
            {
                timer.Stop();

                OnLogOut?.Invoke();
            }
        }

        public static void Start()
        {
            timer.Interval = 1000 * 60;

            timer.Tick += Timer_Tick;

            timer.Start();
        }

    }
}


