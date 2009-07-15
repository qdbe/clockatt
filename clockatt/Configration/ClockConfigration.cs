using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Drawing;

namespace clockatt.Configration
{
    public class ClockConfigration : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        public Font DrawFont { get; set; }

        [UserScopedSetting()]
        public float FontSize { get; set; }

        [UserScopedSetting()]
        public Color BackColor { get; set; }

        [UserScopedSetting()]
        public Color ForeColor { get; set; }

        [UserScopedSetting()]
        public bool IsShowYear { get; set; }

        [UserScopedSetting()]
        public bool IsShowWeek { get; set; }

        [UserScopedSetting()]
        public bool IsShowTime { get; set; }

        [UserScopedSetting()]
        public bool IsShowSecond { get; set; }

        public ClockConfigration()
        {
            this.DrawFont = new Font("MS UI Gothic",9);
            this.FontSize = 9;
            this.BackColor = Color.FromKnownColor(KnownColor.LightSteelBlue);
            //this.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
            this.ForeColor = Color.Red;

            this.IsShowTime = true;
            this.IsShowWeek = true;
            this.IsShowYear = true;
            this.IsShowSecond = true;
        }
    }
}
