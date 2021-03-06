﻿/*
 * メインロジック
 */
using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
 
 
 class AnalysisContents
 {
 	string DownloadedString;
 	
 	public AnalysisContents(string URL)
 	{
		try {
			WebClient wc = new WebClient();
			wc.Encoding = Encoding.UTF8;
			DownloadedString = wc.DownloadString(URL);
 		}
 		catch
 		{
 			
 		}
 	}
 	
 	public void BallCount(out string Ball, out string Strike, out string Out)
 	{
		try {
			Regex r = new Regex("●*(</b>|</em>\n●+</p>)");			//正規表現で取得、"● が0回以上連続 </b> or <em>●が一回以上</p>"にマッチ
		
			MatchCollection mc = r.Matches(DownloadedString);	//一致したコレクション
		
			//<b>タグとか</b>タグ,●と</p>を取り除く
			string[] ReplaceMatches = new string[mc.Count];
			for (int i = 0; i < mc.Count; i++) {
				ReplaceMatches[i] = Regex.Replace(mc[i].Value, "(</b>|</em>\n●+</p>|●*</p>)", "");
			}
		
			Ball = ReplaceMatches[0];
			Strike = ReplaceMatches[1];
			Out = ReplaceMatches[2];
		} catch{
 			Ball = "";
 			Strike = "";
 			Out = "";
 		}
 	}
 	//チーム名を取得
 	public void Teams(out string HomeTeam, out string VisitorTeam)
 	{
 		try{
 		//ホーム、ビジターのチーム名を取得
 		Match m = Regex.Match(DownloadedString," .+ vs");
 		HomeTeam = m.Value.Replace("vs","").Replace(" ","");
 		m = Regex.Match(DownloadedString,"vs .+ 一");
 		VisitorTeam = m.Value.Replace("vs ","").Replace("一","").Replace(" ","");
 		}
 		catch{
 			HomeTeam = "";
 			VisitorTeam = "";
 		}
 	}
 	//イニングを取得
 	public string Inning()
 	{
 		try{
 		string SerchWord = @"<h4 class=""live"">" + "\n<em>.+</em>";
 		Match m = Regex.Match(DownloadedString,SerchWord);
 		return Regex.Replace(m.Value,@"<h4 class=""live"">" + "\n<em>","").Replace("</em>","");
 		}
 		catch
 		{
 			return "";
 		}			
 	}
 	//イニング別に色を指定
 	public void InningColor(string Inning , out string HomeColor, out string VisitorColor)
 	{
 		if (Inning.IndexOf("表") >= 0)
 		{
 			HomeColor = "White";
 			VisitorColor = "Red";
 		}
 		else if(Inning.IndexOf("裏") >= 0)
 		{
 			HomeColor = "Red";
 			VisitorColor = "White";
 		}
 		else
 		{
			HomeColor = "White";
 			VisitorColor = "White";
 		}
 	}
 	//得点を取得
 	public void Score(out string VisitorScore, out string HomeScore)
 	{
 		try{
 		MatchCollection mc = Regex.Matches(DownloadedString,@"<td class=""sum"">" + ".+</td>");
 		string[] Scores = new string[mc.Count];
 		for (int i = 0; i < mc.Count ; i++)
 		{
 			Scores[i] = mc[i].Value.Replace(@"<td class=""sum"">","").Replace("</td>","");
 		}
 		VisitorScore = Scores[0];
 		HomeScore = Scores[1];
 		}
 		catch
 		{
 			VisitorScore = "";
 			HomeScore = "";
 		}
 	}
 	//出塁状況を取得
 	public void Bases(out string First, out string Second, out string Third)
 	{
 		try{
 		string[] bases = new string[4];
 		for (int i = 1; i < 4;i++)
 		{
 			if(DownloadedString.IndexOf("base"+ i)== -1)
 			{
 				bases[i] = "◇";
 			}
 			else
 			{
 				bases[i] = "◆";
 			}
 		}
 		First = bases[1];
 		Second = bases[2];
 		Third = bases[3];
 		}
 		catch
 		{
 			First = "◇";
 			Second = "◇";
 			Third = "◇";
 		}
 	}
 	
 }