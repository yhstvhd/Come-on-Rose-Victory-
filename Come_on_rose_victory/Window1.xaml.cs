
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
			//Enterキーを押されたときの処理
			if(e.Key == Key.Enter)
			{
				string URL = urlbox.Text;
				string Vscore, Hscore;
				string Fst,Snd,Trd;
				string B,S,O;
				string HomeTeam, VisitorTeam;
				//チーム名取得
				AnalysisContents Contents;
				Contents = new AnalysisContents(URL);
				Contents.Teams(out HomeTeam, out VisitorTeam);
				
				//10秒ごとにボールカウントを取得
				while(true)
				{
					Contents = new AnalysisContents(URL);
					string Inning = Contents.Inning();
					Contents.Bases(out Fst, out Snd, out Trd);
					Contents.Score(out Vscore, out Hscore);
					Contents.BallCount(out B, out S, out O);
					this.DataContext = new {Inning,Vscore,Hscore,Fst,Snd,Trd,B,S,O,HomeTeam,VisitorTeam};
					await Task.Delay(10000);
				}
			}
		}
		//テキストボックスをクリア
		void urlboxClick(object sender, MouseButtonEventArgs e)
		{
			urlbox.Text = "";
		}
	}
	
	
}