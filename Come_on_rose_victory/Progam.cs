/*
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
 		WebClient wc= new WebClient();
		wc.Encoding = Encoding.UTF8;
 		DownloadedString = wc.DownloadString(URL);
 	}
 	
 	public void BallCount(out string Ball, out string Strike, out string Out)
 	{
 		
 		Regex r = new Regex("(<b>●*</b>|●+</p>)");			//正規表現で取得、"<b> ●が0回以上連続する </b>"にマッチか"●●●●</p>"にマッチ
		
		MatchCollection mc = r.Matches(DownloadedString);	//一致したコレクション
		
		//<b>タグとか</b>タグ,●と</p>を取り除く
		string[] ReplaceMatches = new string[mc.Count];
		for (int i = 0;i < mc.Count;i++)
		{
			ReplaceMatches[i] = Regex.Replace(mc[i].Value,"(</*b>|●+</p>)","");
		}
		//念のための例外処理
		try
		{
			Ball = ReplaceMatches[0];
			Strike = ReplaceMatches[1];
			Out = ReplaceMatches[2];
		}catch{
			Ball = "";
			Strike = "";
			Out = "";
		}
 	}
 	//チーム名を取得
 	public void Teams(out string HomeTeam, out string VisitorTeam)
 	{
 		//ホーム、ビジターのチーム名を取得
 		Match m = Regex.Match(DownloadedString," .+ vs");
 		HomeTeam = m.Value.Replace("vs","");
 		m = Regex.Match(DownloadedString,"vs .+ 一");
 		VisitorTeam = m.Value.Replace("vs ","").Replace("一","");
 	}
 }