﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace clockatt
{
	partial class ShowAboutBox : Form
	{
		public ShowAboutBox()
		{
			InitializeComponent();

			//  アセンブリ情報からの製品情報を表示する情報ボックスを初期化します。
			//  アプリケーションのアセンブリ情報設定を次のいずれかにて変更します:
			//  - [プロジェクト] メニューの [プロパティ] にある [アプリケーション] の [アセンブリ情報]
			//  - AssemblyInfo.cs
			this.Text = String.Format("{0} のバージョン情報", AssemblyTitle);
			this.labelProductName.Text = AssemblyProduct;
			this.labelVersion.Text = String.Format("バージョン {0}", AssemblyVersion);
			this.labelCopyright.Text = AssemblyCopyright;
//			this.labelCompanyName.Text = AssemblyCompany;
			this.textBoxDescription.Text = AssemblyDescription;
		}

		#region アセンブリ属性アクセサ

		/// <summary>
		/// タイトル属性をすべて取得します
		/// </summary>
		public string AssemblyTitle
		{
			get
			{
				// このアセンブリ上のタイトル属性をすべて取得します
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				// 少なくとも 1 つのタイトル属性がある場合
				if (attributes.Length > 0)
				{
					// 最初の項目を選択します
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					// 空の文字列の場合、その項目を返します
					if (titleAttribute.Title != "")
						return titleAttribute.Title;
				}
				// タイトル属性がないか、またはタイトル属性が空の文字列の場合、.exe 名を返します
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		/// <summary>
		/// アセンブリバージョンを取得する
		/// </summary>
		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetExecutingAssembly().GetName().Version.ToString();
			}
		}

		/// <summary>
		/// 説明属性をすべて取得します
		/// </summary>
		public string AssemblyDescription
		{
			get
			{
				// このアセンブリ上の説明属性をすべて取得します
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				// 説明属性がない場合、空の文字列を返します
				if (attributes.Length == 0)
					return "";
				// 説明属性がある場合、その値を返します
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		/// <summary>
		/// 説明属性をすべて取得します
		/// </summary>
		public string AssemblyProduct
		{
			get
			{
				// このアセンブリ上の製品属性をすべて取得します
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				// 製品属性がない場合、空の文字列を返します
				if (attributes.Length == 0)
					return "";
				// 製品属性がある場合、その値を返します
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		/// <summary>
		/// 著作権属性をすべて取得します
		/// </summary>
		public string AssemblyCopyright
		{
			get
			{
				// このアセンブリ上の著作権属性をすべて取得します
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				// 著作権属性がない場合、空の文字列を返します
				if (attributes.Length == 0)
					return "";
				// 著作権属性がある場合、その値を返します
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		/// <summary>
		/// 会社属性をすべて取得します
		/// </summary>
		public string AssemblyCompany
		{
			get
			{
				// このアセンブリ上の会社属性をすべて取得します
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				// 会社属性がない場合、空の文字列を返します
				if (attributes.Length == 0)
					return "";
				// 会社属性がある場合、その値を返します
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion

		/// <summary>
		/// OKボタンの押下によりダイアログを閉じる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void okButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
