using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

//====================================================================================================
//for learning Japanese, that would be a good idea to have an App to help memorying vocabularies and
//how to prounce them, so, it require a DB to save those words, this application is tend to collec
//data from https://www.japanesepod101.com/japanese-dictionary/ and retrieve data from it resutls
//====================================================================================================
//the web site has problem with lower versions of internet exploror object, so has to add a key in the
//registry to make it use the version 10 IE, as below. 
//[HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION]
//"JVocCollect.exe"=dword:00002711
//====================================================================================================
// 2017.06.23 version 1.0.0.0: initial version
// 2017.06.29 add one more line, add another line

namespace JVocCollect
{
	public partial class frmMain : Form
	{
		private HtmlElement rootEle = null;
		private string theURL = @"https://www.japanesepod101.com/japanese-dictionary/";//the URL of the English to Japanese dictionary

		public frmMain()
		{
			InitializeComponent();
		}

		//event handler when clicking the "Get" button
		private void btnGet_Click(object sender, EventArgs e)
		{
			int order = Convert.ToInt32(txtOrder.Text);//indicate the n-th element you need in the search result
			string mp3URL = "";//example: https://assets.languagepod101.com/dictionary/japanese/audiomp3.php?id=12345
			string[] arrMp3URL = null;
			string mp3ID = "";//exmaple: 12345
			string voc = "";//example: あおい
			string han = "";//example: 十一
			string meaning = "";//its meaning in English, exmaple : eleven
			string[] arrMeaning = null;
			//1.get the root div of search result, id=dc-result, if not, means no search result exists
			rootEle = IE.Document.All["dc-result"];
			if (rootEle == null) { MessageBox.Show("no search results yet!!"); return; }
			if (rootEle.Children.Count ==0) { MessageBox.Show("no search results yet!!"); return; }
			//2.retrieve data of each result
			foreach (HtmlElement eleRow in rootEle.All) {
				// 2.1.get the div of one single result
				if (eleRow.GetAttribute("classname") == "dc-box--white dc-result-row") {
					foreach (HtmlElement ele in eleRow.All) {
						//2.2.get the pronunciation URL (dc-result-row__player-field)
						if (ele.GetAttribute("classname") == "dc-result-row__player-field") {
							if (ele.Children.Count == 0) continue;
							//due to the url is always start with "assets.languagepod101.com/dictionary/japanese/audiomp3.php?id=", so only need to keep its id.
							mp3URL = ele.Children[0].GetAttribute("data-url").Trim();
							arrMp3URL = mp3URL.Split('=');
							mp3ID = arrMp3URL[1];
						}
						//2.3.get the kana
						if (ele.GetAttribute("classname") == "dc-result-row__vocab-field") {
							if (ele.Children.Count < 2) continue;
							han = ele.Children[0].InnerText.Trim();
							voc = ele.Children[1].InnerText.Trim();
						}
						//2.4.get the english meaning
						if (ele.GetAttribute("classname") == "dc-result-row__english-field") {
							if (ele.Children.Count == 0) continue;
							meaning = ele.Children[0].InnerText.ToLower();
							string[] exclude = { "(adv)", "(uk)", "(p)", "(n)", "\r\n" };
							foreach (string item in exclude) meaning = meaning.Replace(item, "");
							for (int j=1; j<=10; j++) meaning = meaning.Replace(j.ToString() + ".", "");
							meaning = meaning.Replace("  ", ",").Trim();
							if (meaning.Substring(meaning.Length - 1) == ",") meaning = meaning.Substring(0, meaning.Length - 1);
							Debug.WriteLine("meaning=" + meaning);
							if (order == 1) {
								txtSql.Text = "insert into tbljpnvoc (voc, han, mp3id, meaning, strike, reserved1) select * from (select '" + voc + "' as c1, '" + han + "' as c2, '" + mp3ID + "', '" + meaning + "', 0, '') as tmp where not exists (select voc from tbljpnvoc where voc = '" + voc + "') limit 1;\r\n" + txtSql.Text;
								txtOrder.Text = "1";
								return;
							}
							else order--;
						}
					}
				}
			}
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			IE.Navigate(theURL);
		}
	}
}
