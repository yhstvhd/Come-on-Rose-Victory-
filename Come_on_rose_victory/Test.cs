/*
 * SharpDevelopによって生成
 * 日付: 10/12/2017
 * 時刻: 20:52
 * 
 * このテンプレートを変更する場合「ツール→オプション→コーディング→標準ヘッダの編集」
 */

using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

class Test
{
	public static void Main()
	{
		//ダウンロード
		WebClient wc= new WebClient();
		wc.Encoding = Encoding.UTF8;
		string DownloadString = wc.DownloadString(@"F:\2017年10月9日 楽天 vs 日本ハム 一球速報 - スポーツナビ.html");
		Regex r = new Regex("<b>●*</b>");			//正規表現で取得、"<b> ●が0回以上連続する </b>"にマッチ
		
		MatchCollection mc = r.Matches(DownloadString);	//コレクションで
		
		//<b>タグとか</b>タグを取り除く
		string[] ReplaceMatches = new string[mc.Count];
		for (int i = 0;i < mc.Count;i++)
		{
			ReplaceMatches[i] = Regex.Replace(mc[i].Value,"</*b>","");
		}
		
		string B = ReplaceMatches[0];

		string S = ReplaceMatches[1];

		string O = ReplaceMatches[2];
		
		Console.WriteLine(B +"\n" + S +"\n" + O);
		Console.ReadKey();
	}
}