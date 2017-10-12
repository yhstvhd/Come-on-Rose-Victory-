
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace Come_on_rose_victory
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
			string B; string S; string O;
			AnalysisContents Content = new AnalysisContents();
			Content.BallCount(out B, out S, out O);
			this.DataContext = new {B,S,O};
		}
	}
	
	
}