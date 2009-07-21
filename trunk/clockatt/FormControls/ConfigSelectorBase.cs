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
        public event EventHandler SamplePropertyChenged = null;

        protected object pSelectedValue;

        private object pSampleObject;
        public object SampleObject
        {
            get { return pSampleObject; }
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

        public void SetSampleObject(object target, string targetProperty)
        {
            this.pSampleObject = target;
            this.pSampleProperty = targetProperty;
            this.SetSampleProperty(this.pSelectedValue);
        }

        public void SetSampleProperty(object setValue)
        {
            if (this.SampleObject == null)
            {
                return;
            }
            PropertyInfo pi = this.SampleObject.GetType().GetProperty(this.pSampleProperty);
            Type ptype = this.GetSamplePropertyType();
            if( ptype.FullName == pi.PropertyType.FullName)
            {
                pi.SetValue(this.SampleObject, setValue, null);
                if (this.SampleObject is Control)
                {
                    ((Control)this.SampleObject).Invalidate(true);
                }
                if( SamplePropertyChenged != null )
                {
                    SamplePropertyChenged(this,new EventArgs());
                }
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

        //public virtual void GetDefaultDataFromSettings(System.Configuration.SettingsBase setting)
        //{
        //    this.SetValue(setting.PropertyValues[this.SettingName].Property.DefaultValue);
        //}

        public virtual void SetDataToSettings(System.Configuration.SettingsBase setting)
        {
            setting.PropertyValues[this.SettingName].PropertyValue = this.pSelectedValue;
        }
    }
}
