using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace clockatt.FormControls
{
    public partial class ConfigSelectorBase : UserControl
    {

        protected object pSelectedValue;

        private Control pSampleControl;
        public Control SampleControl
        {
            get { return pSampleControl; }
        }

        public string SettingName { get; set; }

        private string pSampleProperty;
        public string SampleProperty
        {
            get { return pSampleProperty; }
        }

        public ConfigSelectorBase()
        {
            InitializeComponent();
        }

        protected virtual Type GetSamplePropertyType()
        {
            return null;
        }

        public void SetSampleControl(Control target, string targetProperty)
        {
            this.pSampleControl = target;
            this.pSampleProperty = targetProperty;
        }

        public void SetSampleProperty(object setValue)
        {
            if (this.pSampleControl == null)
            {
                return;
            }
            PropertyInfo pi = this.pSampleControl.GetType().GetProperty(this.pSampleProperty);
            Type ptype = this.GetSamplePropertyType();
            if( ptype.FullName == pi.PropertyType.FullName)
            {
                pi.SetValue(this.pSampleControl, setValue, null);
            }
        }

        public virtual void SetValue(object value)
        {
            throw new NotImplementedException();
        }

        public virtual void GetDataFromSettings(System.Configuration.SettingsBase setting)
        {
            this.SetValue(setting.PropertyValues[this.SettingName].PropertyValue);
        }

        public virtual void SetDataToSettings(System.Configuration.SettingsBase setting)
        {
            setting.PropertyValues[this.SettingName].PropertyValue = this.pSelectedValue;
        }
    }
}
