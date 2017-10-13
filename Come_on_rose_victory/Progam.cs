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
 	
  	//HTMLをダウンロード
 	public void DownloadStings(string URL)
 	{
		WebClient wc= new WebClient();
		wc.Encoding = Encoding.UTF8;
		DownloadedString = wc.DownloadString(URL);
 	}
 	
 	public void BallCount(string URL,out string Ball, out string Strike, out string Out)
 	{
 		DownloadStings(URL);
 		
 		Regex r = new Regex("<b>●*</b>");			//正規表現で取得、"<b> ●が0回以上連続する </b>"にマッチ
		
		MatchCollection mc = r.Matches(DownloadedString);	//一致したコレクション
		
		//<b>タグとか</b>タグを取り除く
		string[] ReplaceMatches = new string[mc.Count];
		for (int i = 0;i < mc.Count;i++)
		{
			ReplaceMatches[i] = Regex.Replace(mc[i].Value,"</*b>","");
		}
		
		Ball = ReplaceMatches[0];
		Strike = ReplaceMatches[1];
		Out = ReplaceMatches[2];
 	}
 }