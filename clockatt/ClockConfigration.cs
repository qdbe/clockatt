using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Drawing;

namespace clockatt
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
        [DefaultSettingValue("White")]
        public Color ForeColor { get; set; }

        public ClockConfigration()
        {
            this.DrawFont = new Font("MS UI Gothic",9);
            this.FontSize = 9;
            this.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
            this.ForeColor = Color.FromKnownColor(KnownColor.ControlText);
        }
    }
}
