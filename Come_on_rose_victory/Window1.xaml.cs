
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Threading.Tasks;

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

		}
		async void urlboxKeydown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
			{
				string URL = urlbox.Text;
				string B; string S; string O;
			while(true)
			{
				AnalysisContents Contents = new AnalysisContents();
				Contents.BallCount(URL, out B, out S, out O);
				this.DataContext = new {B,S,O};
				await Task.Delay(5000);
			}
			}
		}
	}
	
	
}