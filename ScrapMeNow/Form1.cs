using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office2013.Excel;
using HtmlAgilityPack;
using Markdig.Helpers;
using MySql.Data.MySqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace ScrapMeNow
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        public Form1()
        {
            InitializeComponent();

            var skinmanager = MaterialSkin.MaterialSkinManager.Instance;
            skinmanager.AddFormToManage(this);
            skinmanager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            skinmanager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey800, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.BlueGrey500, MaterialSkin.Accent.LightBlue200, MaterialSkin.TextShade.WHITE);
            splitContainer1.Panel1.ResetText();

            if (Ping() & Sql())
            {
                MySQL_LoadDatagridviewData();
            }
            else
            {
                MessageBox.Show("This computer is has an internet or sql issue . Please fix the problem..", "Network/Sql error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Ping()
        {
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
            System.Net.NetworkInformation.PingReply reply = pingSender.Send("www.google.com");
            if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool Sql()
        {
            try
            {
                using (var connection = new MySqlConnection("SERVER= 88.99.136.47;PORT=3306;DATABASE=xuxlffke_testdb;USER=xuxlffke_testuser;PASSWORD=';*r-?lL&FqV]';"))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Export_Form ef = new Export_Form();
            ef.ShowDialog();
        }
        internal static string RemoveUnwantedTags(string data)
        {
            if (string.IsNullOrEmpty(data)) return string.Empty;

            var document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(data);

            var acceptableTags = new String[] { "p" };

            var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var parentNode = node.ParentNode;

                if (!acceptableTags.Contains(node.Name) && node.Name != "#text")
                {
                    var childNodes = node.SelectNodes("./*|./text()");

                    if (childNodes != null)
                    {
                        foreach (var child in childNodes)
                        {
                            nodes.Enqueue(child);
                            parentNode.InsertBefore(child, node);
                        }
                    }
                    parentNode.RemoveChild(node);
                }
            }
            return document.DocumentNode.InnerHtml;
        }
        public static string RemoveHtmlTags(string strHtml)
        {
            string strText = Regex.Replace(strHtml, "<(.|\n)*?>", String.Empty);
            strText = HttpUtility.HtmlDecode(strText);
            strText = Regex.Replace(strText, @"\s+", " ");
            return strText;
        }
        private void MySQL_LoadDatagridviewData()
        {
            insertProduction();
           // insertPersons(74, "https://www.viva.gr/tickets/theater/theatro-fournos/don-quixote/");
           // insertEvent("Θέατρο Κιβωτός",  77 , "https://www.viva.gr/tickets/theater/theatro-kivotos/rinokeros/");
            /*
            try
            {
                string connetionString = "SERVER= 88.99.136.47;PORT=3306;DATABASE=xuxlffke_testdb;USER=xuxlffke_testuser;PASSWORD=';*r-?lL&FqV]';";
                MySqlConnection conn = new MySqlConnection(connetionString);
                MySqlCommand cmd = new MySqlCommand(@"SELECT ID,Firstname,Lastname,SystemID,timestamp FROM persons", conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable();
                da.Fill(table);
                conn.Open();
                SetHeight(lvProduction, 240);
                // listViewTest.View = System.Windows.Forms.View.Details;
                using (MySqlConnection con = new MySqlConnection(connetionString))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM persons", conn))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        lvPeople.GridLines = true;
                        lvPeople.View = System.Windows.Forms.View.Details;
                        //Loop through the DataTable.
                        MySqlDataReader rd;
                        rd = cmd.ExecuteReader();
                        lvPeople.Items.Clear();

                        while (rd.Read())
                        {
                            ListViewItem lv = new ListViewItem(rd.GetInt32(0).ToString());
                            lv.SubItems.Add(rd.GetString(1));
                            lv.SubItems.Add(rd.GetString(2));
                            lv.SubItems.Add(rd.GetString(3));
                            lv.SubItems.Add(rd.GetDateTime(4).ToString());
                            lvPeople.Items.Add(lv);
                        }
                        rd.Close();
                    }
                    cmd = new MySqlCommand(@"SELECT ID,Role,SystemID,timestamp FROM roles", conn);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM roles", conn))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        lvRoles.GridLines = true;
                        lvRoles.View = System.Windows.Forms.View.Details;
                        //Loop through the DataTable.
                        MySqlDataReader rd;
                        rd = cmd.ExecuteReader();
                        lvRoles.Items.Clear();
                        while (rd.Read())
                        {
                            ListViewItem lv = new ListViewItem(rd.GetInt32(0).ToString());
                            lv.SubItems.Add(rd.GetString(1));
                            lv.SubItems.Add(rd.GetString(2));
                            lv.SubItems.Add(rd.GetDateTime(3).ToString());
                            lvRoles.Items.Add(lv);
                        }
                        rd.Close();
                    }
                    cmd = new MySqlCommand(@"SELECT ID,Title,Address,SystemID,timestamp FROM venue", conn);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM venue", conn))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        lvVenue.GridLines = true;
                        lvVenue.View = System.Windows.Forms.View.Details;
                        //Loop through the DataTable.
                        MySqlDataReader rd;
                        rd = cmd.ExecuteReader();
                        lvVenue.Items.Clear();
                        while (rd.Read())
                        {
                            ListViewItem lv = new ListViewItem(rd.GetInt32(0).ToString());
                            lv.SubItems.Add(rd.GetString(1));
                            lv.SubItems.Add(rd.GetString(2));
                            lv.SubItems.Add(rd.GetInt32(3).ToString());
                            lv.SubItems.Add(rd.GetDateTime(4).ToString());
                            lvVenue.Items.Add(lv);
                        }
                        rd.Close();
                    }
                    cmd = new MySqlCommand(@"SELECT ID,Name,Address,Town,postcode,Phone,Email,Doy,Afm,SystemID,timestamp FROM organizer", conn);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM organizer", conn))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        lvOrganizer.GridLines = true;
                        lvOrganizer.View = System.Windows.Forms.View.Details;
                        //Loop through the DataTable.
                        MySqlDataReader rd;
                        rd = cmd.ExecuteReader();
                        lvOrganizer.Items.Clear();
                        while (rd.Read())
                        {
                            ListViewItem lv = new ListViewItem(rd.GetInt32(0).ToString());
                            lv.SubItems.Add(rd.GetString(1));
                            lv.SubItems.Add(rd.GetString(2));
                            lv.SubItems.Add(rd.GetString(3));
                            lv.SubItems.Add(rd.GetString(4));
                            lv.SubItems.Add(rd.GetString(5));
                            lv.SubItems.Add(rd.GetString(6));
                            lv.SubItems.Add(rd.GetString(7));
                            lv.SubItems.Add(rd.GetString(8));
                            lv.SubItems.Add(rd.GetString(9));
                            lv.SubItems.Add(rd.GetDateTime(10).ToString());
                            lvOrganizer.Items.Add(lv);
                        }
                        rd.Close();
                    }
                    cmd = new MySqlCommand(@"SELECT ID,OrganizerID,Title,Description,URL,Production,MediaURL,Duration,SystemID,timestamp FROM production", conn);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM production", conn))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        lvProduction.GridLines = true;
                        lvProduction.View = System.Windows.Forms.View.Details;
                        //Loop through the DataTable.
                        MySqlDataReader rd;
                        rd = cmd.ExecuteReader();
                        lvProduction.Items.Clear();
                        while (rd.Read())
                        {
                            ListViewItem lv = new ListViewItem(rd.GetInt32(0).ToString());
                            lv.SubItems.Add(rd.GetInt32(1).ToString());
                            lv.SubItems.Add(rd.GetString(2));
                            lv.SubItems.Add(rd.GetString(3).ToString());
                            lv.SubItems.Add(rd.GetString(4).ToString());
                            lv.SubItems.Add(rd.GetString(5).ToString());
                            lv.SubItems.Add(rd.GetString(6).ToString());
                            lv.SubItems.Add(rd.GetString(7).ToString());
                            lv.SubItems.Add(rd.GetString(8).ToString());
                            lv.SubItems.Add(rd.GetDateTime(9).ToString());
                            lvProduction.Items.Add(lv);
                        }
                        rd.Close();
                    }
                    cmd = new MySqlCommand("SELECT ID,PeopleID,ProductionID,RoleID,SystemID,timestamp FROM contributions", conn);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM contributions", conn))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        lvContributions.GridLines = true;
                        lvContributions.View = System.Windows.Forms.View.Details;
                        //Loop through the DataTable.
                        MySqlDataReader rd;
                        rd = cmd.ExecuteReader();
                        lvContributions.Items.Clear();
                        while (rd.Read())
                        {
                            ListViewItem lv = new ListViewItem(rd.GetInt32(0).ToString());
                            lv.SubItems.Add(rd.GetInt32(1).ToString());
                            lv.SubItems.Add(rd.GetInt32(2).ToString());
                            lv.SubItems.Add(rd.GetInt32(3).ToString());
                            lv.SubItems.Add(rd.GetString(4));
                            lv.SubItems.Add(rd.GetDateTime(5).ToString());
                            lvContributions.Items.Add(lv);
                        }
                        rd.Close();
                    }
                    cmd = new MySqlCommand("SELECT ID,ProductionID,VenueID,DateEvent,PriceRange,SystemID,timestamp FROM events", conn);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter("SELECT * FROM events", conn))
                    {
                        //Fill the DataTable with records from Table.
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        lvEvents.GridLines = true;
                        lvEvents.View = System.Windows.Forms.View.Details;
                        //Loop through the DataTable.
                        MySqlDataReader rd;
                        rd = cmd.ExecuteReader();
                        lvEvents.Items.Clear();
                        while (rd.Read())
                        {
                            ListViewItem lv = new ListViewItem(rd.GetInt32(0).ToString());
                            lv.SubItems.Add(rd.GetInt32(1).ToString());
                            lv.SubItems.Add(rd.GetInt32(2).ToString());
                            lv.SubItems.Add(rd.GetDateTime(3).ToString());
                            lv.SubItems.Add(rd.GetString(4).ToString());
                            lv.SubItems.Add(rd.GetString(5));
                            lv.SubItems.Add(rd.GetDateTime(6).ToString());
                            lvEvents.Items.Add(lv);
                        }
                        rd.Close();
                    }
                }
                conn.Close();
            }
            catch (System.ArgumentException ex) { }
            */
        }
        private void button1_MouseClick(object sender, MouseEventArgs e) { }
        private void button2_Click(object sender, EventArgs e)
        {
            Contact cn = new Contact();
            cn.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private int insertProduction()
        {
            int prodid = 0;
            List<string> l = getallproductionlinks().Distinct().ToList();
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            MySqlConnection mysqlCon = new MySqlConnection("SERVER= 88.99.136.47;PORT=3306;DATABASE=xuxlffke_testdb;USER=xuxlffke_testuser;PASSWORD=';*r-?lL&FqV]';");
            mysqlCon.Open();
            foreach (var line in l)
            {
                Console.WriteLine("line " + line.ToString());
                HtmlAgilityPack.HtmlDocument doc = web.Load(line.ToString());  
                var container = doc.DocumentNode.SelectNodes("//div[@class='field-group']/span").ToList();
                var orgtitle = doc?.DocumentNode?.SelectSingleNode("//div[@class='playDetailsContainer']/h4");
                var fields = doc?.DocumentNode?.SelectNodes("//div[@class='field']").ToList();
                int counter = 0;
                var venuename = doc?.DocumentNode?.SelectSingleNode("//a[contains(@id,'PageContent_PlayDetails_ButtonMap_VenueMapLink')]");
                string venue = "";
                string org = "";
                if (venuename != null) 
                {
                    venue = venuename.InnerText;
                }
                else
                {
                    venue = "";
                }
                if (orgtitle != null)
                {
                    org = orgtitle.InnerText;
                }
                else
                {
                    org = "";
                }
                var title = doc?.DocumentNode?.SelectSingleNode("//h1[@id='playTitle']");
                MySqlCommand cmd = mysqlCon.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM organizer where Name LIKE'" + org.TrimStart().TrimEnd() + "'";
                cmd.ExecuteNonQuery();
                int mysqlint = int.Parse(cmd.ExecuteScalar().ToString());
                string url = line.ToString();
                var web1 = new HtmlWeb();
                var doc1 = web1.LoadFromBrowser(url);
                if (mysqlint > 0)
                {
                    //MessageBox.Show("Υπαρχει ηδη η εγγραφη");
                }
                else
                {
                    if (fields != null)
                    {
                        MySqlCommand command = mysqlCon.CreateCommand();
                        command.CommandText = "INSERT INTO organizer(Name,Address,Town,postcode,Phone,Email,Doy,Afm,SystemID) VALUES ('" + org+ "','" + fields[0].InnerText.Replace("'","").TrimStart().TrimEnd()
                            + "','" + fields[1].InnerText.Replace("'", "").TrimStart().TrimEnd() + "','" + fields[2].InnerText.Replace("'", "").TrimStart().TrimEnd() + "','" + fields[3].InnerText.Replace("'", "").TrimStart().TrimEnd() +
                            "','" + fields[4].InnerText.Replace("'", "").TrimStart().TrimEnd() + "','" + fields[5].InnerText.Replace("'", "").TrimStart().TrimEnd() + "','" + fields[6].InnerText.Replace("'", "").TrimStart().TrimEnd() + "','" + 3 + "')";
                        command.ExecuteNonQuery();
                        long id = command.LastInsertedId;
                    }
                }
                var desc = doc.DocumentNode.SelectNodes("//div[@itemprop='description']").ToList();
                var production = doc?.DocumentNode?.SelectSingleNode("//div[@class='playDetailsContainer']/h4");
                string safety = "";
                foreach (var m in desc)
                {
                    safety += m.InnerText;
                }
                MySqlCommand check_Prod_Name = new MySqlCommand("SELECT * FROM production WHERE URL='" + url + "'", mysqlCon);
                MySqlDataAdapter da = new MySqlDataAdapter(check_Prod_Name);
                DataSet ds1 = new DataSet();
                da.Fill(ds1);
                int i = ds1.Tables[0].Rows.Count;
                string s = safety;
                string result = s.Replace("\"", "`").Replace("/“", "`").Replace("“", "`").Replace("'", "`");
                if (i > 0)
                {
                    //MessageBox.Show("Production already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MySqlCommand mycmd = mysqlCon.CreateCommand();
                    MySqlCommand aa = mysqlCon.CreateCommand();
                    aa.CommandText = "SELECT MAX(ID) FROM organizer";
                    aa.ExecuteNonQuery();
                    MySqlCommand orgId = mysqlCon.CreateCommand();
                    orgId.CommandText = "SELECT ID FROM organizer where Name='"+org+"'";
                    orgId.ExecuteNonQuery();
                    long orgid = long.Parse(orgId.ExecuteScalar().ToString());
                    string ss = result.Replace("&lsquo;", "").Replace("&rsquo;", "").Replace("&ldquo;","").Replace("&rdquo;", "").TrimStart().TrimEnd();
                    var duration = doc1?.DocumentNode?.SelectSingleNode("//li[@class='ui-duration']");
                    mycmd.CommandText = "INSERT INTO `production`(`OrganizerID`, `Title`, `Description`, `URL`, `Producer`, `MediaURL`, `Duration`, `SystemID`) " +
                    "VALUES (@OrganizerID,@Title,@Description,@URL,@Producer,@MediaURL,@Duration,@SystemID)";
                    mycmd.Parameters.AddWithValue("@OrganizerID", orgid);
                    mycmd.Parameters.AddWithValue("@Title", title.InnerText.Replace("&lsquo;", "").Replace("&rsquo;", "").TrimStart());
                    mycmd.Parameters.AddWithValue("@Description", ss);
                    mycmd.Parameters.AddWithValue("@URL",url.TrimStart().TrimEnd());
                    mycmd.Parameters.AddWithValue("@Producer", RemoveEmptyLines(production.InnerText));
                    mycmd.Parameters.AddWithValue("@MediaURL", getImage(url));
                    mycmd.Parameters.AddWithValue("@Duration", getDuration(line.ToString()) + "'");
                    mycmd.Parameters.AddWithValue("@SystemID", 3);
                    mycmd.ExecuteNonQuery();  
                }
                safety = "";
                MySqlCommand lk = mysqlCon.CreateCommand();
                lk.CommandText = "SELECT ID FROM production where URL='"+url.TrimStart().TrimEnd()+ "'";
                lk.ExecuteNonQuery();
                prodid = Int32.Parse(lk.ExecuteScalar().ToString());
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.bell;
                popup.TitleText = "ScrapMeNow";
                popup.ContentText = "Έγινε εγγραφή νέας παράστασης στην βάση με όνομα " + title.InnerText;
                popup.Popup();
                MySqlCommand idexinevents = mysqlCon.CreateCommand();
                idexinevents.CommandText = "SELECT COUNT(ProductionID) FROM events WHERE ProductionID='"+prodid+"'";
                idexinevents.ExecuteNonQuery();
                long kl = (long)idexinevents.ExecuteScalar();
                if (kl > 0)
                {
                    //Υπαρχει ηδη
                }
                else
                {
                    insertEvent(venue, prodid, line.ToString());
                }
            }
            mysqlCon.Close();
            //insertEvent(venue, prodid, "https://www.viva.gr/tickets/theater/theatro-kivotos/rinokeros/");
            //insertPersons(prodid, "https://www.viva.gr/tickets/theater/neos-akadimos/ksypolitoi-sto-parko/");      
            return prodid;
        }
        private string getImage(string link)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            var experimentalFlags = new List<string>();
            string imgsrc = "";
            ChromeDriver driver = new ChromeDriver(chromeOptions);
            driver.Navigate().GoToUrl(link);
            experimentalFlags.Add("same-site-by-default-cookies@2");
            experimentalFlags.Add("cookies-without-same-site-must-be-secure@2");
            chromeOptions.AddLocalStatePreference("browser.enabled_labs_experiments",
                experimentalFlags);
            var cookies = driver.Manage().Cookies.AllCookies;
            driver.FindElement(By.XPath("//a[contains(@class,'cc-btn--accept')]")).Click();
            Thread.Sleep(2000);
            List<IWebElement> cheeses = driver.FindElements(By.Id("openMedia")).ToList();
            if (cheeses.Count >0)
            {
                driver.FindElement(By.Id("openMedia")).Click();
                Thread.Sleep(3000);
                Boolean isPresent = driver.FindElements(By.ClassName("mfp-img")).ToString().Length > 0;
                By by = By.CssSelector("a[data-value*='09.0']");
                var element = driver.FindElements(By.ClassName("mfp-img")).Count >= 1 ? driver.FindElement(By.ClassName("mfp-img")) : null;
                if (element != null)
                {
                    var src = driver.FindElement(By.ClassName("mfp-img"));
                    imgsrc = src.GetAttribute("src");
                    Console.WriteLine(imgsrc);
                }
                else
                {
                    imgsrc = "Not found..";
                }
            }
            driver.Quit();
            return imgsrc;
        }

        private string getDuration(string link)
        {
            string dur = "";
            var web1 = new HtmlWeb();
            var doc1 = web1.LoadFromBrowser(link);
            var duration = doc1?.DocumentNode?.SelectSingleNode("//li[@class='ui-duration']");
            if (duration != null)
            {
                var groups = Regex.Match(duration.InnerText, @"[0-9]:[0-5][0-9]").Groups;
                var res = groups[0].Value;
                dur = res.ToString();
                double mins = TimeSpan.Parse(dur).TotalMinutes; // -> 1.5
                dur = mins.ToString();
            }
            else
            {
                dur = "Not found";
            }
            return dur;
        }

        private static string RemoveEmptyLines(string lines)
        {
            return System.Text.RegularExpressions.Regex.Replace(lines, @"^\s*$\n|\r", string.Empty, RegexOptions.Multiline).TrimEnd();
        }
        static void insertEvent(string vname, int prodid,string link)
        {
            //Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine(vname + " " + prodid);
            MySqlConnection mysqlCon = new MySqlConnection("SERVER= 88.99.136.47;PORT=3306;DATABASE=xuxlffke_testdb;USER=xuxlffke_testuser;PASSWORD=';*r-?lL&FqV]';");
            mysqlCon.Open();
            string url = link;

            var web1 = new HtmlWeb();
            var web2 = new HtmlWeb();
            var doc1 = web1.LoadFromBrowser(url);
            var doc2 = web2.LoadFromBrowser(url, html =>
            {
                return !html.Contains("<li id=\"PageContent_PlayDetails_UIDuration\"></div>");
            });
            var day = doc2.DocumentNode.SelectNodes("//div[contains(@class,'events-container__item-date')]").ToList();
            var hours = doc2.DocumentNode.SelectNodes("//div[contains(@class,'events-container__item-time')]").ToList();
            var place = doc2.DocumentNode.SelectNodes("//span[contains(@class,'events-container__item-venue')]").ToList();
            var test = doc1.DocumentNode.SelectNodes("//div[contains(@class,'events-container__item-date')]").ToList();
            var money = doc1.DocumentNode.SelectSingleNode("//span[contains(@class,'money')]");
            var money1 = money?.SelectNodes("//span[1][contains(@class,'money')]")?.ToList();
            var money2 = money?.SelectNodes("//span[2][contains(@class,'money')]")?.ToList();
            var allthemoneys = doc1.DocumentNode.SelectNodes("//span[contains(@class,'money')]");
            var classmoney = doc1.DocumentNode.SelectNodes("//div[contains(@class,'events-container__item-prices')]");

            double py = 0;
            string ch = "";
            string all = "";
            List<string> tempprice = new List<string>();
            double res = 0;
            double val = 0;
            Console.WriteLine(classmoney.Count + "   " + place.Count);
            foreach(var j in classmoney)
            {
                string u = j.InnerText.TrimStart().TrimEnd();
                if (u.TrimStart().TrimEnd().ToString() == "-")
                {
                    tempprice.Add("Sold-out");
                }
                else
                {
                    tempprice.Add(j.InnerText.TrimStart().TrimEnd());
                }
                Console.WriteLine(j.InnerText.TrimStart().TrimEnd());  
            }

            for (int p = 0; p < place.Count; p++)
            {
                string s = day[p].InnerText.Split(' ').Last();
                string days = s.Split('/')[0];
                string month = s.Split('/')[1];
                string hour = hours[p].InnerText.Split(':')[0];
                string minutes = hours[p].InnerText.Split(':')[1];
                string eventvenue = place[p].InnerText.Split('-')[0].TrimEnd();
                string eventaddress = place[p].InnerText.Split('-')[1].TrimEnd();

                MySqlCommand findcom = mysqlCon.CreateCommand();
                findcom.CommandText = "SELECT COUNT(ID) FROM venue where Title='" + eventvenue.TrimStart().TrimEnd() + "' AND Address='" + eventaddress + "'";
                findcom.ExecuteNonQuery();
                long venueexist = (long)findcom.ExecuteScalar();
                string date_from = "";
                if (venueexist > 0)
                {
                    MySqlCommand getVenId = mysqlCon.CreateCommand();
                    getVenId.CommandText = "SELECT ID FROM venue where Title='" + eventvenue.TrimStart().TrimEnd() + "' AND Address='" + eventaddress + "'";
                    getVenId.ExecuteNonQuery();
                    long vid = (long)getVenId.ExecuteScalar();
                    DateTime temp = new DateTime(DateTime.Now.Year, Int32.Parse(month), Int32.Parse(days), Int32.Parse(hour), Int32.Parse(minutes), 0);
                    MySqlCommand insEvent = new MySqlCommand();
                    insEvent.Connection = mysqlCon;
                    date_from = temp.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    insEvent.CommandText = "INSERT INTO events(ProductionID,VenueID,DateEvent,PriceRange, SystemID) VALUES ('" + prodid + "','" + vid + "','" + date_from + "','" + tempprice[p] + "','" + 3 + "')";
                    insEvent.ExecuteNonQuery();
                }
                else
                {
                    MySqlCommand insvencomm = mysqlCon.CreateCommand();
                    insvencomm.CommandText = "INSERT INTO `venue`(`Title`, `Address`, `SystemID`) VALUES ('" + vname.TrimStart().TrimEnd() + "','" + eventaddress + "','" + 3 + "')";
                    insvencomm.ExecuteNonQuery();
                    MySqlCommand lk = mysqlCon.CreateCommand();
                    lk.CommandText = "SELECT MAX(ID) FROM venue";
                    lk.ExecuteNonQuery();
                    int neweid = Int32.Parse(lk.ExecuteScalar().ToString());
                    DateTime temps = new DateTime(DateTime.Now.Year, Int32.Parse(month), Int32.Parse(days), Int32.Parse(hour), Int32.Parse(minutes), 0);
                    date_from = temps.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    MySqlCommand insEvCom = mysqlCon.CreateCommand();
                    insEvCom.CommandText = "INSERT INTO events(ProductionID,VenueID,DateEvent,PriceRange, SystemID) VALUES ('" + prodid + "','" + neweid + "','" + date_from + "','" + tempprice[p] + "','" + 3 + "')";
                    insEvCom.ExecuteNonQuery();
                }             
            }
            mysqlCon.Close();
        }
        private static void insertContribution(List<string> people, List<string> roles, List<string> subroles, int prodid)
        {
            MySqlConnection mysqlCon = new MySqlConnection("SERVER= 88.99.136.47;PORT=3306;DATABASE=xuxlffke_testdb;USER=xuxlffke_testuser;PASSWORD=';*r-?lL&FqV]';");
            long peopleid = 0, roleid = 0;
            int counter = 0,i=0;
            mysqlCon.Open();
            foreach (var j in roles)
            {
                Console.WriteLine("Role " + j);
            }
            foreach (var j in people)
            {
                Console.WriteLine("People " + j);
            }
            try
            {
                for (i = 0; i < roles.Count; i++)
                {
                    if (!roles[i].Contains("Ηθοποιός") )
                    {
                        if (!people[i].ToString().Contains(",") & !people[i].ToString().Contains("–"))
                        {
                            string[] arr = people[i].Split('-', '–');
                            MySqlCommand insContr = mysqlCon.CreateCommand();
                            for (int p = 0; p < arr.Length; p++)
                            {
                                string s = arr[p].TrimStart().TrimEnd();
                                if (s.Length > 0)
                                {
                                    Console.WriteLine(arr[p] + " --- " + roles[i]);
                                    MySqlCommand lp = mysqlCon.CreateCommand();
                                    lp.CommandText = "SELECT ID FROM persons WHERE Fullname='" + s + "'";
                                    lp.ExecuteNonQuery();
                                    peopleid = long.Parse(lp.ExecuteScalar().ToString());
                                    MySqlCommand lr = mysqlCon.CreateCommand();
                                    lr.CommandText = "SELECT ID FROM roles WHERE Role='" + roles[i].ToString() + "'";
                                    lr.ExecuteNonQuery();
                                    roleid = long.Parse(lr.ExecuteScalar().ToString());
                                    MySqlCommand insContr2 = mysqlCon.CreateCommand();
                                    insContr2.CommandText = "INSERT INTO `contributions`(`PeopleID`, `ProductionID`, `RoleID`,`subRole`, `SystemID`) VALUES ('" + peopleid + "','" + prodid + "','" + roleid + "','" + " " + "','" + 3 + "')";
                                    insContr2.ExecuteNonQuery();
                                }
                            }
                        }
                        else if (people[i].ToString().Contains(",") & people[i].ToString().Length > 0)
                        {
                            string[] arr = people[i].Split(',');
                            MySqlCommand insContr = mysqlCon.CreateCommand();
                            for (int p = 0; p < arr.Length; p++)
                            {
                                string s = arr[p].TrimStart().TrimEnd();
                                if (s.Length > 0 & !s.Contains("και") & !s.Contains("@"))
                                {
                                    Console.WriteLine(arr[p] + " --- " + roles[i]);
                                    MySqlCommand lp = mysqlCon.CreateCommand();
                                    lp.CommandText = "SELECT ID FROM persons WHERE Fullname='" + s + "'";
                                    lp.ExecuteNonQuery();
                                    peopleid = long.Parse(lp.ExecuteScalar().ToString());
                                    MySqlCommand lr = mysqlCon.CreateCommand();
                                    lr.CommandText = "SELECT ID FROM roles WHERE Role='" + roles[i].ToString() + "'";
                                    lr.ExecuteNonQuery();
                                    roleid = long.Parse(lr.ExecuteScalar().ToString());
                                    MySqlCommand insContr2 = mysqlCon.CreateCommand();
                                    insContr2.CommandText = "INSERT INTO `contributions`(`PeopleID`, `ProductionID`, `RoleID`,`subRole`, `SystemID`) VALUES ('" + peopleid + "','" + prodid + "','" + roleid + "','" + " " + "','" + 3 + "')";
                                    insContr2.ExecuteNonQuery();
                                }
                            }
                        }
                        else if (people[i].ToString().Contains("|") & people[i].ToString().Length > 0)
                        {
                            string[] arr = people[i].Split('|');
                            MySqlCommand insContr = mysqlCon.CreateCommand();
                            for (int p = 0; p < arr.Length; p++)
                            {
                                string s = arr[p].TrimStart().TrimEnd();
                                if (s.Length > 0 & !s.Contains("και") & !s.Contains("@"))
                                {
                                    Console.WriteLine(arr[p] + " --- " + roles[i]);
                                    MySqlCommand lp = mysqlCon.CreateCommand();
                                    lp.CommandText = "SELECT ID FROM persons WHERE Fullname='" + s + "'";
                                    lp.ExecuteNonQuery();
                                    peopleid = long.Parse(lp.ExecuteScalar().ToString());
                                    MySqlCommand lr = mysqlCon.CreateCommand();
                                    lr.CommandText = "SELECT ID FROM roles WHERE Role='" + roles[i].ToString() + "'";
                                    lr.ExecuteNonQuery();
                                    roleid = long.Parse(lr.ExecuteScalar().ToString());
                                    MySqlCommand insContr2 = mysqlCon.CreateCommand();
                                    insContr2.CommandText = "INSERT INTO `contributions`(`PeopleID`, `ProductionID`, `RoleID`,`subRole`, `SystemID`) VALUES ('" + peopleid + "','" + prodid + "','" + roleid + "','" + " " + "','" + 3 + "')";
                                    insContr2.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    else if(subroles.Count > 0 & roles[i].Contains("Ηθοποιός"))
                    {
                        string s = people[i].TrimStart().TrimEnd();
                        Console.WriteLine(people[i] + " --- " + roles[i]);
                        MySqlCommand lp = mysqlCon.CreateCommand();
                        lp.CommandText = "SELECT ID FROM persons WHERE Fullname='" + s + "'";
                        lp.ExecuteNonQuery();
                        peopleid = long.Parse(lp.ExecuteScalar().ToString());
                        MySqlCommand lr = mysqlCon.CreateCommand();
                        lr.CommandText = "SELECT ID FROM roles WHERE Role='" + roles[i].ToString() + "'";
                        lr.ExecuteNonQuery();
                        roleid = long.Parse(lr.ExecuteScalar().ToString());
                        MySqlCommand insContr2 = mysqlCon.CreateCommand();
                        insContr2.CommandText = "INSERT INTO `contributions`(`PeopleID`, `ProductionID`, `RoleID`,`subRole`, `SystemID`) VALUES ('" + peopleid + "','" + prodid + "','" + roleid + "','" + subroles[counter] + "','" + 3 + "')";
                        insContr2.ExecuteNonQuery();
                        counter++;
                    }else if (roles[i].Contains("Ηθοποιός") & people[i].ToString().Contains(","))
                    {
                        string[] arr = people[i].Split(',');
                        MySqlCommand insContr = mysqlCon.CreateCommand();
                        for (int p = 0; p < arr.Length; p++)
                        {
                            string s = arr[p].TrimStart().TrimEnd();
                            if (s.Length > 0 & !s.Contains("και") & !s.Contains("@"))
                            {
                                Console.WriteLine(arr[p] + " --- " + roles[i]);
                                MySqlCommand lp = mysqlCon.CreateCommand();
                                lp.CommandText = "SELECT ID FROM persons WHERE Fullname='" + s + "'";
                                lp.ExecuteNonQuery();
                                peopleid = long.Parse(lp.ExecuteScalar().ToString());
                                MySqlCommand lr = mysqlCon.CreateCommand();
                                lr.CommandText = "SELECT ID FROM roles WHERE Role='" + roles[i].ToString() + "'";
                                lr.ExecuteNonQuery();
                                roleid = long.Parse(lr.ExecuteScalar().ToString());
                                MySqlCommand insContr2 = mysqlCon.CreateCommand();
                                insContr2.CommandText = "INSERT INTO `contributions`(`PeopleID`, `ProductionID`, `RoleID`,`subRole`, `SystemID`) VALUES ('" + peopleid + "','" + prodid + "','" + roleid + "','" + " " + "','" + 3 + "')";
                                insContr2.ExecuteNonQuery();
                            }
                        }
                    }
                    else if (roles[i].Contains("Ηθοποιός") & !people[i].ToString().Contains(","))
                    {
                        string s = people[i].TrimStart().TrimEnd();
                        Console.WriteLine(people[i] + " --- " + roles[i]);
                        MySqlCommand lp = mysqlCon.CreateCommand();
                        lp.CommandText = "SELECT ID FROM persons WHERE Fullname='" + s + "'";
                        lp.ExecuteNonQuery();
                        peopleid = long.Parse(lp.ExecuteScalar().ToString());
                        MySqlCommand lr = mysqlCon.CreateCommand();
                        lr.CommandText = "SELECT ID FROM roles WHERE Role='" + roles[i].ToString() + "'";
                        lr.ExecuteNonQuery();
                        roleid = long.Parse(lr.ExecuteScalar().ToString());
                        MySqlCommand insContr2 = mysqlCon.CreateCommand();
                        insContr2.CommandText = "INSERT INTO `contributions`(`PeopleID`, `ProductionID`, `RoleID`,`subRole`, `SystemID`) VALUES ('" + peopleid + "','" + prodid + "','" + roleid + "','" + subroles[counter] + "','" + 3 + "')";
                        insContr2.ExecuteNonQuery();
                        counter++;
                    }
                }
            }catch(System.ArgumentOutOfRangeException ex) { }
                /*
                    if (subroles.Count >0)
                    {
                        string s = arrpeople[i].TrimStart().TrimEnd();
                        Console.WriteLine(arrpeople[i] + " --- " + arrroles[i]);
                        MySqlCommand lp = mysqlCon.CreateCommand();
                        lp.CommandText = "SELECT ID FROM persons WHERE Fullname='" + s + "'";
                        lp.ExecuteNonQuery();
                        peopleid = long.Parse(lp.ExecuteScalar().ToString());
                        MySqlCommand lr = mysqlCon.CreateCommand();
                        lr.CommandText = "SELECT ID FROM roles WHERE Role='" + arrroles[i].ToString() + "'";
                        lr.ExecuteNonQuery();
                        roleid = long.Parse(lr.ExecuteScalar().ToString());
                        MySqlCommand insContr2 = mysqlCon.CreateCommand();
                        insContr2.CommandText = "INSERT INTO `contributions`(`PeopleID`, `ProductionID`, `RoleID`,`subRole`, `SystemID`) VALUES ('" + peopleid + "','" + prodid + "','" + roleid + "','" + subroles[counter]+ "','" + 3 + "')";
                        insContr2.ExecuteNonQuery();
                        counter++;
                    }

                 /*
                else if (arrpeople[i].ToString().Contains("-") | arrpeople[i].ToString().Contains("–"))
                {
                    string[] arr = arrpeople[i].Split('-');
                    MySqlCommand insContr = mysqlCon.CreateCommand();
                    for (int p = 0; p < arr.Length; p++)
                    {
                        string s = arr[p].TrimStart().TrimEnd();
                        MySqlCommand lp = mysqlCon.CreateCommand();
                        lp.CommandText = "SELECT ID FROM persons WHERE Fullname='" + s + "'";
                        lp.ExecuteNonQuery();
                        peopleid = long.Parse(lp.ExecuteScalar().ToString());
                        MySqlCommand lr = mysqlCon.CreateCommand();
                        lr.CommandText = "SELECT ID FROM roles WHERE Role='" + arrroles[i].ToString() + "'";
                        lr.ExecuteNonQuery();
                        roleid = long.Parse(lr.ExecuteScalar().ToString());
                        MySqlCommand insContr2 = mysqlCon.CreateCommand();
                        insContr2.CommandText = "INSERT INTO `contributions`(`PeopleID`, `ProductionID`, `RoleID`,`subRole`, `SystemID`) VALUES ('" + peopleid + "','" + prodid + "','" + roleid + "','" + " " + "','" + 3 + "')";
                        insContr2.ExecuteNonQuery();
                    }
                }*/
            
            mysqlCon.Close();
        }
        static void insertPersons(int prodid, string link)
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            MySqlConnection mysqlCon = new MySqlConnection("SERVER= 88.99.136.47;PORT=3306;DATABASE=xuxlffke_testdb;USER=xuxlffke_testuser;PASSWORD=';*r-?lL&FqV]';");
            HtmlAgilityPack.HtmlDocument doc = web.Load(link);

            var syntelestesexist = doc.DocumentNode.SelectNodes("//dl[@class='responsive-tabs']").ToList();
            bool exists = false;
            List<string> peoples = new List<string>();
            List<string> proles = new List<string>();
            List<string> peoplesafter = new List<string>();
            string url = link;
            var web1 = new HtmlWeb();
            var doc1 = web1.LoadFromBrowser(url);
            mysqlCon.Open();
            foreach (var i in syntelestesexist)
            {
                if (i.InnerText.TrimStart().TrimEnd().Contains("Συντελεστές"))
                {
                    exists = true;
                }
            }
            int alt = alternativeSearch(link, false, prodid);
            Console.WriteLine("alt " + alt );
            if (exists)
            {
                alternativeSearch(link, true, prodid);
            }
        }
        public static string[] unwanted = { "ΠΡΩΤΑΓΩΝΙΣΤΟΥΝ", "ΠΑΙΖΟΥΝ", "ΑΛΦΑΒΗΤΙΚΑ", "ΔΙΑΝΟΜΗ" , "Παίζουν" , "Θεάτρου", "Θεάτρο","Πρωταγωνιστούν",
                    "από", "ΣΥΝΤΕΛΕΣΤΕΣ", "Συμπαραγωγή", "Διανομή", "Ταυτότητα" , "ΑΛΦΑΒΗΤΙΚΑ","Θεάτρου" ,"Προπώληση","Εισιτήρια","Συμπαραγωγή","Πότε","Διάρκεια","Η ΒΑΒΥΛΩΝΙΑ","Ευχαριστούμε","*","Διατίθενται"};
        public static int alternativeSearch(string link, bool flag, int prodid) { 
            int cresults = 0;
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            MySqlConnection mysqlCon = new MySqlConnection("SERVER= 88.99.136.47;PORT=3306;DATABASE=xuxlffke_testdb;USER=xuxlffke_testuser;PASSWORD=';*r-?lL&FqV]';");
            HtmlAgilityPack.HtmlDocument doc = web.Load(link);
            mysqlCon.Open();
            List<string> peoples = new List<string>();
            List<string> proles = new List<string>();
            List<string> subroles = new List<string>();
            List<string> peoplesafter = new List<string>();

            bool exists = false;
            var syntelestesexist = doc.DocumentNode.SelectNodes("//dl[@class='responsive-tabs']").ToList();
            foreach (var x in syntelestesexist)
            {
                if (x.InnerText.TrimStart().TrimEnd().Contains("Συντελεστές"))
                {
                    exists = true;
                }
            }
            var web1 = new HtmlWeb();
            var doc1 = web1.LoadFromBrowser(link);
            if (exists)
            {
                string test = "";
                string strongtxt = "";
                if (doc1?.DocumentNode?.SelectNodes("//dl[@class='responsive-tabs']/dd/p") != null)
                {
                    foreach (HtmlNode node in doc?.DocumentNode?.SelectNodes("//dl[@class='responsive-tabs']/dd/p"))
                    {
                        strongtxt = RemoveUnwantedTags(node.InnerText.Replace("&nbsp;", "").Replace("nbsp;", "").Replace("'", " ").Replace("Με τους:", "Ηθοποιός")
                            .Replace("Διανομή:", "*").Replace("=:", "").Replace("Παίζουν:","*").Replace("laquo;","<").Replace("Παίζουν","*").Replace("ΠΑΙΖΟΥΝ:","*")
                            .Replace("ndash;", ",").Replace("&", "").Replace("raquo;",">").Replace(" & amp", "").TrimEnd().TrimStart());
                        test += strongtxt + "\n";
                    }
                }
                bool subrole = false;
                long countRole = 0;
               
                using (StringReader reader = new StringReader(test))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line.Length > 0)
                        {
                            Console.WriteLine("sub "+ subrole.ToString());
                            if (line.Contains("*"))
                            {
                                subrole = true;
                            }
                            if (subrole == true & Regex.IsMatch(line, @"[\w]{1,}(.*):(.*)[\w]{1,}") & !unwanted.Any(line.Contains))
                            {
                                string role = line.Split(':')[0];
                                string person = line.Split(':')[1].Replace("-", "|").Replace("–", "|");
                                MySqlCommand findRole = mysqlCon.CreateCommand();
                                findRole.CommandText = "SELECT COUNT(*) FROM roles WHERE Role='" + role + "'";
                                countRole = (long)findRole.ExecuteScalar();
                                if (countRole > 0)
                                {
                                    proles.Add(role.TrimStart().TrimEnd());
                                    Console.WriteLine(" βρηκε ρολο " + role);            
                                }
                                else
                                {
                                    Console.WriteLine("Δεν βρηκε ρολο " + role);
                                    proles.Add("Ηθοποιός");
                                    subroles.Add(role.TrimStart().TrimEnd());
                                }
                                peoples.Add(person.TrimEnd().TrimStart());
                                peoplesafter.Add(person.TrimEnd().TrimStart());
                            }
                            else if (Regex.IsMatch(line, @"[\w]{1,}(.*):(.*)[\w]{1,}") & !unwanted.Any(line.Contains) & subrole == false)
                                {
                                    string role = line.Split(':')[0];
                                    string person = line.Split(':')[1].Replace("-", "|").Replace("–", "|");
                                    if (!unwanted.Any(line.Contains) & !person.Contains(",") & !person.Contains("-"))
                                    {
                                        peoplesafter.Add(person.TrimStart().TrimEnd());
                                    }
                                    if (!subrole & !unwanted.Any(line.Contains))
                                    {
                                        proles.Add(role);
                                    }

                                    if (!person.Contains(',') & !unwanted.Any(person.Contains))
                                    {
                                        peoples.Add(person.TrimStart().TrimEnd());
                                    }
                                    else if (person.Contains(','))
                                    {
                                        peoplesafter.Add(person);
                                        string[] arr = person.Split(',');
                                        foreach (var item in arr)
                                        {
                                            if (item.Length > 0)
                                            {
                                                peoples.Add(item.TrimStart());
                                            }
                                        }
                                    }
                                    else if (person.Contains('|'))
                                    {
                                        peoplesafter.Add(person);
                                        string[] arr = person.Split('|');
                                        foreach (var item in arr)
                                        {
                                            if (item.Length > 0)
                                            {
                                                peoples.Add(item.TrimStart());
                                            }
                                        }
                                    }
                                }
                                else if (line.Contains(",") & !unwanted.Any(line.Contains))
                                {
                                    peoplesafter.Add(line);
                                    string[] arr = line.Split(',');
                                    foreach (var item in arr)
                                    {
                                        if (item.Length > 0)
                                        {
                                            peoples.Add(item.TrimStart());
                                            proles.Add("Ηθοποιός");
                                        }
                                    }
                                }
                                else if (line.Length > 1 & !unwanted.Any(line.Contains))
                                {
                                    //Console.WriteLine("people else : " + line);
                                    peoplesafter.Add(line);
                                    peoples.Add(line);
                                    proles.Add("Ηθοποιός");
                                }
                            }
                        }                   
                }
                test = "";
                if (doc1?.DocumentNode?.SelectNodes("//dl[@class='responsive-tabs']/dd/ul/li")?.ToList() != null)
                {
                    var lis = doc1?.DocumentNode?.SelectNodes("//dl[@class='responsive-tabs']/dd/ul/li")?.ToList();
                    foreach (var q in lis)
                    {
                        string r = RemoveUnwantedTags(q.InnerText.Replace("nbsp;", " ").Replace("&nbsp;", "").Replace("'", " ")
                            .Replace("Ταυτότητα", "").Replace("Διανομή", "").Replace("\n", "").Replace("'", "").Replace("&ndash;", "-").Replace("Με τους:", "Ηθοποιός")
                            .Replace("=", "").Replace("=:", "").Replace("amp;","-").Replace("text=", "").Replace("&", "").Replace("^(?:[\t ]*(?:\r?\n|\r))+", "").TrimStart().TrimEnd());
                        test += r + "\n";
                    }
                    test = RemoveEmptyLines(test);
                    
                    using (StringReader reader = new StringReader(test))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.ToString().Length > 1)
                            {
                                if (line.Contains(':'))
                                {
                                    string role = line.Split(':')[0];
                                    string person = line.Split(':')[1];
                                    
                                    Console.WriteLine("roles + " + role + " person +" + person);
                                    if (person.Length > 0 & role.Length > 0 & !unwanted.Any(line.Contains) & !person.Contains(',') & !person.Contains('-'))
                                    {
                                        peoplesafter.Add(person.TrimStart().TrimEnd());
                                        proles.Add(role);
                                    }
                                    if (!person.Contains(',') & !unwanted.Any(line.Contains))
                                    {
                                        peoples.Add(person.TrimStart().TrimEnd());
                                    }
                                    else if (person.Contains(','))
                                    {

                                        string[] arr = person.Split(',');
                                        foreach (var item in arr)
                                        {
                                            if (item.Length > 0)
                                                peoples.Add(item.TrimStart().TrimEnd());
                                        }
                                    }
                                    else if (person.Contains('-') | person.Contains("–"))
                                    {
                                        string[] words = person.Split('–', '-');
                                        foreach (var word in words)
                                        {
                                            peoples.Add(word.TrimStart().TrimEnd());
                                        }
                                    }
                                }
                                else if (!unwanted.Any(line.Contains) & !line.Contains(","))
                                {
                                    peoplesafter.Add(line.TrimStart().TrimEnd());
                                    peoples.Add(line.TrimStart().TrimEnd());
                                    proles.Add("Ηθοποιός");
                                }
                                else if (line.Contains(',') & !unwanted.Any(line.Contains))
                                {
                                    peoplesafter.Add(line);
                                    string[] arr = line.Split(',');
                                    foreach (var item in arr)
                                    {
                                        if (item.Length > 0)
                                            peoples.Add(item.TrimStart().TrimEnd());
                                        proles.Add("Ηθοποιός");
                                    }
                                }
                            }
                        }
                    }
                }

                if (doc?.DocumentNode?.SelectSingleNode("//tbody") != null)
                {
                    var table = doc?.DocumentNode?.SelectSingleNode("//tbody");
                    var rows = table?.SelectNodes("//tr/td")?.ToList();
                    for (int t = 0; t < rows.Count; t++)
                    {
                        peoples.Add(rows[t].InnerText);
                        peoplesafter.Add(rows[t].InnerText);
                        proles.Add("Ηθοποιός");
                    }
                }
                for (int i = 0; i < proles.Count; i++)
                {
                    proles[i] = proles[i].Replace("Διανομή (με αλφαβητική σειρά)", "Ηθοποιός").Replace("Παίζουν οι", "Ηθοποιός").Replace("ΗΘΟΠΟΙΟΙ", "Ηθοποιός").Replace("Παίζουν", "Ηθοποιός").Replace("ΠΡΩΤΑΓΩΝΙΣΤΟΥΝ", "Ηθοποιός")
                        .Replace("Διανομή (αλφαβητικά)", "Ηθοποιός").Replace("Ερμηνεία", "Ηθοποιός").Replace("Ερμηνεύουν", "Ηθοποιός").Replace("Ερμηνεύει", "Ηθοποιός").Replace("Με τους:","Ηθοποιός")
                        .Replace("Πρωταγωνιστούν", "Ηθοποιός");
                }

                //peoples.RemoveAll(u => u.Contains("ΠΡΩΤΑΓΩΝΙΣΤΟΥΝ"));
                //peoples.RemoveAll(u => u.Contains("ΠΑΙΖΟΥΝ"));
                //peoples.RemoveAll(u => u.Contains("ΑΛΦΑΒΗΤΙΚΑ"));
                //peoples.RemoveAll(u => u.Contains("ΔΙΑΝΟΜΗ"));
                // peoples.RemoveAll(u => u.Contains("Παίζουν"));
                //peoples.RemoveAll(u => u.Contains("Θεάτρου"));
                // peoples.RemoveAll(u => u.Contains("Θεάτρο"));
                peoples.RemoveAll(u => u.Contains("Το") & u.Length == 2);
                peoples.RemoveAll(u => u.Contains("το") & u.Length == 2);
                peoples.RemoveAll(u => u.Contains("Διατίθενται"));
                peoplesafter.RemoveAll(u => u.Contains("Διατίθενται"));
                //peoples.RemoveAll(u => u.Contains("από"));
                //peoples.RemoveAll(u => u.Contains("ΣΥΝΤΕΛΕΣΤΕΣ"));
                //peoples.RemoveAll(u => u.Contains("Συμπαραγωγή"));
                peoples.RemoveAll(u => u.Contains("και"));
                peoples.RemoveAll(u => u.Contains("@"));
                peoples.RemoveAll(u => u.Contains("Productions"));
                //peoples.RemoveAll(u => u.Contains("Διανομή"));
                //peoples.RemoveAll(u => u.Contains("Ταυτότητα"));
                
                subroles.RemoveAll(u => u.Contains("Διανομή"));
                subroles.RemoveAll(u => u.Contains("Παίζουν"));
                subroles.RemoveAll(u => u.Contains("ΠΡΩΤΑΓΩΝΙΣΤΟΥΝ"));
                subroles.RemoveAll(u => u.Contains("ΠΑΙΖΟΥΝ"));


                for (int t = 0; t < peoplesafter.Count; t++)
                {
                    if (peoplesafter[t] == string.Empty || peoplesafter[t].Length <= 2) peoplesafter.RemoveAt(t);
                }
                for (int pp = 0; pp < peoples.Count; pp++)
                {
                    string s = peoples[pp];
                    if (unwanted.Any(s.Contains) | s.Length == 0)
                    {
                        peoples.RemoveAt(pp);
                    }
                }
                for (int pa = 0; pa < peoplesafter.Count; pa++)
                {
                    string s = peoplesafter[pa];
                    if (unwanted.Any(s.Contains) | s.Length == 0)
                    {
                        peoplesafter.RemoveAt(pa);
                    }
                }
                for (int pr = 0; pr < proles.Count; pr++)
                {
                    string s = proles[pr];
                    if (unwanted.Any(s.Contains) | s.Length == 0)
                    {
                        proles.RemoveAt(pr);
                    }
                }
                /*
                peoplesafter.RemoveAll(u => u.Contains("Διατίθενται θέσεις καθήμενων"));
                peoplesafter.RemoveAll(u => u.Contains("ΠΡΩΤΑΓΩΝΙΣΤΟΥΝ"));
                peoplesafter.RemoveAll(u => u.Contains("ΠΑΙΖΟΥΝ"));
                peoplesafter.RemoveAll(u => u.Contains("ΑΛΦΑΒΗΤΙΚΑ"));
                peoplesafter.RemoveAll(u => u.Contains("ΔΙΑΝΟΜΗ"));
                peoplesafter.RemoveAll(u => u.Contains("ΠΑΙΖΟΥΝ"));
                peoplesafter.RemoveAll(u => u.Contains("Παίζουν"));
                peoplesafter.RemoveAll(u => u.Contains("Θεάτρου"));
                peoplesafter.RemoveAll(u => u.Contains("Ένας"));
                peoplesafter.RemoveAll(u => u.Contains("του"));
                peoplesafter.RemoveAll(u => u.Contains("Το") & u.Length == 2);
                peoplesafter.RemoveAll(u => u.Contains("το") & u.Length == 2);
                peoplesafter.RemoveAll(u => u.Contains("από"));
                peoplesafter.RemoveAll(u => u.Contains("από"));
                peoplesafter.RemoveAll(u => u.Contains("ΣΥΝΤΕΛΕΣΤΕΣ"));
                peoplesafter.RemoveAll(u => u.Contains("Συμπαραγωγή"));
                
                peoplesafter.RemoveAll(u => u.Contains("Productions"));
                peoplesafter.RemoveAll(u => u.Contains("Πρωταγωνιστούν"));
                peoplesafter.RemoveAll(u => u.Contains("Διανομή"));
                peoplesafter.RemoveAll(u => u.Contains("Ταυτότητα"));
                peoplesafter.RemoveAll(u => u.Contains("ΤΟΥ ΔΗΜΗΤΡΙΟΥ ΒΥΖΑΝΤΙΟΥ"));*/

                peoplesafter.RemoveAll(u => u.Contains("Οι ηθοποιοί"));
                peoplesafter.RemoveAll(u => u.Contains("Παίζουν:"));
                peoplesafter.RemoveAll(u => u.Contains("ΠΑΙΖΟΥΝ"));
                peoplesafter.RemoveAll(u => u.Contains("ΠΡΩΤΑΓΩΝΙΣΤΟΥΝ"));
                peoplesafter.RemoveAll(u => u.Contains("ΣΥΝΤΕΛΕΣΤΕΣ"));
                peoplesafter.RemoveAll(u => u.Contains("Ένας"));
                proles.RemoveAll(u => u.Contains("Συντελεστές"));
                proles.RemoveAll(u => u.Contains("Πού"));
                proles.RemoveAll(u => u.Contains("Πότε"));
                proles.RemoveAll(u => u.Contains("Ώρες"));
                proles.RemoveAll(u => u.Contains("Διάρκεια"));
                proles.RemoveAll(u => u.Contains("Εισιτήρια - Γενική είσοδος"));
                proles.RemoveAll(u => u.Contains("Προπώληση"));
                proles.RemoveAll(u => u.Contains("ΠΡΩΤΑΓΩΝΙΣΤΟΥΝ"));
                proles.RemoveAll(u => u.Contains("ΠΑΙΖΟΥΝ"));
                proles.RemoveAll(u => u.Contains("Παίζουν"));
                proles.RemoveAll(u => u.Contains("Ταυτότητα Παράστασης"));
                proles.RemoveAll(u => u.Contains("Διανομή"));
                proles.RemoveAll(u => u.Contains("Οι ηθοποιοί"));
                peoples.RemoveAll(u => u.Contains("Η ΒΑΒΥΛΩΝΙΑ"));
                proles.RemoveAll(u => u.Contains("Οι ηθοποιοί:"));
            }

            if (flag)
                {
                    foreach (var u in peoples)
                    {
                        Console.WriteLine("() " + u);
                    }
                    foreach (var u in proles)
                    {
                        Console.WriteLine("|| " + u);
                    }
                    foreach (var u in peoplesafter)
                    {
                        Console.WriteLine("// " + u);
                    }
                    string[] arrpeoples = peoples.ToArray();
                    long count = 0;
                    for (int u = 0; u < arrpeoples.Length; u++)
                    {
                        string fullname = arrpeoples[u].TrimStart().TrimEnd();
                        MySqlCommand findPerson =mysqlCon.CreateCommand();
                        findPerson.CommandText = "SELECT COUNT(*) FROM persons WHERE Fullname='" + fullname + "'";
                        count = (long)findPerson.ExecuteScalar();
                        if (fullname.Length > 0 & count ==0)
                        {
                            MySqlCommand insPerson = mysqlCon.CreateCommand();
                            insPerson.CommandText = "INSERT INTO persons(Fullname,SystemID) VALUES ('" + fullname + "','" + "3" + "')";
                            insPerson.ExecuteNonQuery();
                        }
                    }
                    string[] rolesarray = proles.Distinct().ToArray();
                    for (int p = 0; p < rolesarray.Length; p++)
                    {

                        MySqlCommand checkcmd = mysqlCon.CreateCommand();
                        checkcmd.CommandText = "SELECT COUNT(*) FROM roles where Role LIKE'" + rolesarray[p].TrimStart().TrimEnd() + "'";
                        checkcmd.ExecuteNonQuery();
                        int mysqlint = int.Parse(checkcmd.ExecuteScalar().ToString());
                        if (mysqlint > 0)
                        {
                            //MessageBox.Show("Role already exists");
                        }
                        else
                        {
                            MySqlCommand command = mysqlCon.CreateCommand();
                            command.CommandText = "INSERT INTO `roles`(`Role`, `SystemID`) VALUES ('" + rolesarray[p].TrimStart().TrimEnd() + "','" + "3" + "')";
                            command.ExecuteNonQuery();
                        }
                    }
                    insertContribution(peoplesafter, proles,subroles, prodid);
                }
                mysqlCon.Close();  
            return peoplesafter.Count + proles.Count;
        }
        public static string[] RemoveDuplicates(string[] s)
        {
            HashSet<string> set = new HashSet<string>(s);
            string[] result = new string[set.Count];
            set.CopyTo(result);
            return result;
        }
        private void SetHeight(ListView listView, int height)
        {
            ImageList imgLst = new ImageList();
            imgLst.ImageSize = new Size(60, height);
            listView.SmallImageList = imgLst;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //MySQL_LoadDatagridviewData();
        }
        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help h = new Help();
            h.ShowDialog();
        }
        static List<string> getallproductionlinks()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://www.viva.gr/tickets/theatre/");
            //var href = doc.DocumentNode.SelectNodes("//a[@id='lineLink']").ToList();
            List<string> theatrelinks = new List<string>();
            foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
            {
                HtmlAttribute att = link.Attributes["href"];

                if (att.Value.Contains("a") & (att.Value.StartsWith("/tickets/theatre") | att.Value.StartsWith("/tickets/theater") | (att.Value.StartsWith("/tickets/stand-up-comedy"))))
                {
                    theatrelinks.Add("https://www.viva.gr" + att.Value);
                }
            }
            return theatrelinks;
        }
        private void dgvProduction_Click(object sender, EventArgs e) { }
        private void dgvProduction_CellDoubleClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvOrganizer_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void notifyIcon_MouseClick(object sender, MouseEventArgs e){}
    }
}