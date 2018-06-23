using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.ComponentModel;
using Bakalarka.Pages;
using Bakalarka.Windows;
using Bakalarka.Triedy;
using Bakalarka.Triedy.Algoritmy;
using Bakalarka.Mapa;
using Oracle.ManagedDataAccess.Client;
using Bakalarka.Triedy.Databaza;
using System.Data;
using Bakalarka.Mapa.Pages;


namespace Bakalarka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        ZobrazVozidlaPage zobrazVozidlaPage;
        ZobrazTovaryPage zobrazTovaryPage;
        ZobrazObjednavkyPage zobrazObjednavkyPage;
        ZobrazDodavatelov zobrazDodavatelovPage;
        PridajVozidloWindow pridajVozidloWindow;
        PridajDodavatelaWindow pridajDodavatelaWindow;
        List<TovaryNaZobrazenie> tovaryNaZobrazenieList;

        PridajObjednavku pridajObjednavku;
        int captionHeight;
        String windowTitle;
        Databaza databaza;
        TrasaWindow trasaWindow;
        double vyska;
        double sirka;
        string isMaxed = "[ ]";
        bool koniec;

        public event PropertyChangedEventHandler PropertyChanged;

        public string IsMaxed
        {
            get => isMaxed; set
            {
                if (isMaxed != value)
                {
                    isMaxed = value;
                    OnPropertyChanged("IsMaxed");
                }
            }
        }
        public double Sirka
        {
            get => sirka; set
            {
                if (sirka != value)
                {
                    sirka = value;
                    OnPropertyChanged("Sirka");
                }
            }
        }
        public double Vyska
        {
            get => vyska; set
            {
                if (vyska != value)
                {
                    vyska = value;
                    OnPropertyChanged("Vyska");
                }
            }
        }


        public Databaza Databaza
        {
            get => databaza; set
            {
                if (databaza != value)
                {
                    databaza = value;
                    OnPropertyChanged("Databaza");
                }
            }
        }

        public String WindowTitle
        {
            get => windowTitle; set
            {
                if (windowTitle != value)
                {
                    windowTitle = value;
                    OnPropertyChanged("WindowTitle");
                }
            }
        }

        public int CaptionHeight
        {
            get => captionHeight; set
            {
                if (captionHeight != value)
                {
                    captionHeight = value;
                    OnPropertyChanged("CaptionHeight");
                }
            }
        }

        Mapa_Window mapa_window;
        BackgroundWorker backgroundWorker;
        public ZobrazVozidlaPage ZobrazVozidlaPage { get => zobrazVozidlaPage; set => zobrazVozidlaPage = value; }
        public DataTable DataTablePom
        {

            get => dataTablePom; set
            {
                if (dataTablePom != value)
                {
                    dataTablePom = value;
                    OnPropertyChanged("DataTablePom");
                }
            }
        }
        List<Thread> threads;
        public Mapa_Window Mapa_Window { get => mapa_window; set => mapa_window = value; }

        DataTable dataTablePom;
        LoadingWindow loadingWindow;
        public MainWindow() : base()
        {
            InitializeComponent();
            this.Hide();
            loadingWindow = new LoadingWindow();
            loadingWindow.Show();
            koniec = false;
            threads = new List<Thread>();
            Databaza = new Databaza();


            backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();
            WindowTitle = "Hlavné okno";

            CaptionHeight = 40;
            Sirka = HlavneOkno.MinWidth - 282;
            Vyska = HlavneOkno.MinHeight - 90;
            DnesPrichadzajuceObjednavkyGrid.Height = HlavneOkno.MinHeight - 90;

            zobrazVozidlaPage = new ZobrazVozidlaPage(this);
            zobrazTovaryPage = new ZobrazTovaryPage(this);
            zobrazObjednavkyPage = new ZobrazObjednavkyPage(this, databaza);
            zobrazDodavatelovPage = new ZobrazDodavatelov(this);
            tovaryNaZobrazenieList = new List<TovaryNaZobrazenie>();

            Thread newWindowThread = new Thread(new ThreadStart(VytvorMapu));

            newWindowThread.SetApartmentState(ApartmentState.STA);
            newWindowThread.IsBackground = true;
            newWindowThread.Start();
        }

        private void VytvorMapu()
        {
            mapa_window = new Mapa_Window();
            System.Windows.Threading.Dispatcher.Run();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!koniec)
            {
                this.Show();
                loadingWindow.Close();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                loadingWindow.TextStatus.Text = "Pripájam sa k databáze";
            });

            if (!databaza.Pripoj("obelix.fri.uniza.sk", "1521", "orcl2.fri.uniza.sk", "pecho4", "rp555965"))
            {
                this.Dispatcher.Invoke(() =>
                {
                    loadingWindow.TextStatus.Text = "Nepodarilo sa pripojiť k databáze";

                });

                this.Dispatcher.Invoke(() =>
                {
                    loadingWindow.Close();
                    koniec = true;
                    this.Close();
                });

            }
            else
            {
                this.Dispatcher.Invoke(() =>
                {
                    loadingWindow.TextStatus.Text = "Načítam dnes prichadzajúce objednávky";
                });
            }

            if (!koniec)
            {
                nacitajDnesPrichadzajuceObjednavky();
                upravPriority();
                this.Dispatcher.Invoke(() =>
                {
                    DataContext = this;
                });
            }
        }

        public List<List<String>> rozdelTrasu(List<Tovar> zoznam, List<Vozidlo> vozidla, decimal[] poziadavky)
        {
            LoadingPage loadingPage = Mapa_Window.LoadingPage;
            Mapa_Window.Dispatcher.Invoke(() =>
             {
                 Mapa_Window.HlavnyFrame.Content = loadingPage;
                 loadingPage.Faza.Text = "1 / 3";
                 loadingPage.TextStatus.Text = "Načítavam dáta zo servera";
             });

            Clarke_Wright clarke_Wright = new Clarke_Wright(zoznam, vozidla, poziadavky, loadingPage);

            Mapa_Window.Dispatcher.Invoke(() =>
            {
                loadingPage.ProgressBar.Value = 0;
                loadingPage.TextStatusPodrob.Text = "";
                loadingPage.Faza.Text = "2 / 3";
                loadingPage.TextStatus.Text = "Vytváram trasu pre vozidlá";
            });

            if (clarke_Wright.Ries() == -1)
            {
                throw new Exception("Nepodarilo sa vygenerovať trasu");
            }
            var cesty = clarke_Wright.vypisCestu(clarke_Wright.VyslednaCesta);
            return cesty;
        }

        private void ButtZobrazMapu_Click(object sender, RoutedEventArgs e)
        {
            Mapa_Window.Dispatcher.Invoke(() =>
            {
                Mapa_Window.Show();
                Mapa_Window.HlavnyFrame.Content = Mapa_Window.MapaPage;
            });
        }

        //Metody na pridavanie poloziek

        private void ButtPridajVozidlo_Click(object sender, RoutedEventArgs e)
        {
            pridajVozidloWindow = new PridajVozidloWindow(this, zobrazVozidlaPage);
            pridajVozidloWindow.Visibility = Visibility.Visible;
        }

        private void ButtPridajDodavatela_Click(object sender, RoutedEventArgs e)
        {
            pridajDodavatelaWindow = new PridajDodavatelaWindow(this, zobrazDodavatelovPage);
            pridajDodavatelaWindow.Visibility = Visibility.Visible;
        }


        private void ButtPridajObjednavku_Click(object sender, RoutedEventArgs e)
        {
            pridajObjednavku = new PridajObjednavku(this);
            pridajObjednavku.Visibility = Visibility.Visible;
        }

        //Metody na zobrazovanie

        public void nacitajDnesPrichadzajuceObjednavky()
        {
            try
            {
                string format = "dd.MM.yyyy";
                var dnes = DateTime.Today.ToString(format);

                var sql = "select * from objednavka where datumDodania = :dnes";

                using (OracleCommand cmd = new OracleCommand(sql, databaza.Connection))
                {

                    cmd.Parameters.Add("dnes", dnes);

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        DataTablePom = dataTable;
                    }
                }
             
            }
            catch (Exception ex)
            {
                Upraveny_MessageBox.Show(ex.Message);
            }
        }



        // Metody na zobrazenie vsetkych poloziek

        private void ButtZobrazVsetkyVozidla_Click(object sender, RoutedEventArgs e)
        {
            databaza.zobrazVozidla(zobrazVozidlaPage);
            HlavnyFrame.Content = zobrazVozidlaPage;
        }

        private void ButtZobraVsetky_Click(object sender, RoutedEventArgs e)
        {
            databaza.zobrazObjednavky(zobrazObjednavkyPage);
            HlavnyFrame.Content = zobrazObjednavkyPage;
        }

        private void ButtZobrazVsetkyTovary_Click(object sender, RoutedEventArgs e)
        {
            databaza.zobrazTovary(zobrazTovaryPage);
            HlavnyFrame.Content = zobrazTovaryPage;
        }

        private void ButtZobrazDodavatelov_Click(object sender, RoutedEventArgs e)
        {
            databaza.zobrazDodavatelov(zobrazDodavatelovPage);
            HlavnyFrame.Content = zobrazDodavatelovPage;
        }


        // Metody na zobraznie konkretnych poloziek


        private void ButtZobrazTovaryNaSklade_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sql = "select tovarID,datumDorucenia,DatumPrijatiaNaSklad,Hmotnost,dlzka,sirka,vyska,Decode(Prijaty, null, 'NIE', 'ÁNO') Prijaty, Decode(Doruceny, null, 'NIE', 'ÁNO') Doruceny," +
                    " objednavka.DATUMDODANIA as PlanovanyDatum, dodavatel.NAZOV as NazovDodavatela , " +
                    "prijemca.Meno as MenoPrijemcu, prijemca.ADRESA as AdresaPrijemcu, " +
                    " Decode(PrvaTrieda, 0, 'NIE', 1, 'ÁNO') PrvaTrieda  from tovar join objednavka using (objednavkaID) join dodavatel " +
                    "on(Dodavatel.DODAVATELID = objednavka.dodavatelID) join prijemca using (prijemcaID) where prijaty = 1 and doruceny is null";

                using (OracleCommand cmd = new OracleCommand(sql, databaza.Connection))
                {

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        zobrazTovaryPage.vsetkyTovaryGrid.DataContext = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Upraveny_MessageBox.Show(ex.Message);
                });
            }

            HlavnyFrame.Content = zobrazTovaryPage;

        }

        private void ButtZobrazDoruceneTovary_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var sql = "select tovarID,datumDorucenia,DatumPrijatiaNaSklad,Hmotnost,dlzka,sirka,vyska,Decode(Prijaty, null, 'NIE', 'ÁNO') " +
                    "Prijaty, Decode(Doruceny, null, 'NIE', 'ÁNO') Doruceny," +
                    " objednavka.DATUMDODANIA as PlanovanyDatum, dodavatel.NAZOV as NazovDodavatela , " +
                    "prijemca.Meno as MenoPrijemcu, prijemca.ADRESA as AdresaPrijemcu, " +
                    " Decode(PrvaTrieda, 0, 'NIE', 1, 'ÁNO') PrvaTrieda , VozidloID from tovar join objednavka using (objednavkaID) join dodavatel " +
                    "on(Dodavatel.DODAVATELID = objednavka.dodavatelID) join prijemca using (prijemcaID) where doruceny = 1";

                using (OracleCommand cmd = new OracleCommand(sql, databaza.Connection))
                {

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        zobrazTovaryPage.vsetkyTovaryGrid.DataContext = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Upraveny_MessageBox.Show(ex.Message);
                });
            }

            HlavnyFrame.Content = zobrazTovaryPage;
        }

        private void ButtZobrazPrichadzajuceTovary_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var sql = "select tovarID,datumDorucenia,DatumPrijatiaNaSklad,Hmotnost,dlzka,sirka,vyska,Decode(Prijaty, null, 'NIE', 'ÁNO') Prijaty, Decode(Doruceny, null, 'NIE', 'ÁNO') Doruceny," +
                    " objednavka.DATUMDODANIA as PlanovanyDatum, dodavatel.NAZOV as NazovDodavatela , " +
                    "prijemca.Meno as MenoPrijemcu, prijemca.ADRESA as AdresaPrijemcu, " +
                    " Decode(PrvaTrieda, 0, 'NIE', 1, 'ÁNO') PrvaTrieda  from tovar join objednavka using (objednavkaID) join dodavatel " +
                    "on(Dodavatel.DODAVATELID = objednavka.dodavatelID) join prijemca using (prijemcaID) where prijaty is null and doruceny is null";

                using (OracleCommand cmd = new OracleCommand(sql, databaza.Connection))
                {

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        zobrazTovaryPage.vsetkyTovaryGrid.DataContext = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Upraveny_MessageBox.Show(ex.Message);
                });
            }

            HlavnyFrame.Content = zobrazTovaryPage;
        }


        private void ButtZobrazAktivneVozidla_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sql = "select datumEmisnej, datumEvidencie, datumStk, datumVyradenia , " +
                                "najazdeneKm, znacka, typ, vyskaKufru, sirkaKufru, dlzkaKufru, nosnost, polohavozidla, vozidloID , " +
                                "decode(POLOHAVOZIDLA, null, 'NIE', 'ÁNO')  Aktivne from vozidlo  where POLOHAVOZIDLA is not null";

                using (OracleCommand cmd = new OracleCommand(sql, databaza.Connection))
                {

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        zobrazVozidlaPage.vsetkyVozidlaGrid.DataContext = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Upraveny_MessageBox.Show(ex.Message);
                });
            }

            HlavnyFrame.Content = zobrazVozidlaPage;
        }

        private void ButtZobrazNeAktivneVozidla_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var sql = "select datumEmisnej, datumEvidencie, datumStk, datumVyradenia , " +
                                "najazdeneKm, znacka, typ, vyskaKufru, sirkaKufru, dlzkaKufru, nosnost, polohavozidla, vozidloID , " +
                                "decode(POLOHAVOZIDLA, null, 'NIE', 'ÁNO')  Aktivne from vozidlo  where POLOHAVOZIDLA is null";

                using (OracleCommand cmd = new OracleCommand(sql, databaza.Connection))
                {

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        zobrazVozidlaPage.vsetkyVozidlaGrid.DataContext = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Upraveny_MessageBox.Show(ex.Message);
                });
            }

            HlavnyFrame.Content = zobrazVozidlaPage;
        }


        private void ButtZobrazPrichadzajuceObjednavky_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var sql = "select OBJEDNAVKAID,DATUMDODANIA,DODAVATELID, DODAVATEL.NAZOV as NazovDodavatela," +
                    "DECODE(VYBAVENA, 'V', 'Vybavená', 'N', 'Nevybavená', 'C', 'Čiastočne vybavená') " +
                    "Vybavena from objednavka join dodavatel using (dodavatelID) where DATUMDODANIA >= " + "'" + DateTime.Today.ToShortDateString() + "'";

                using (OracleCommand cmd = new OracleCommand(sql, databaza.Connection))
                {

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        zobrazObjednavkyPage.vsetkyObjednavky.DataContext = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Upraveny_MessageBox.Show(ex.Message);
                });
            }

            HlavnyFrame.Content = zobrazObjednavkyPage;
        }


        private void ButtZobrazVybavene_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var sql = "select OBJEDNAVKAID,DATUMDODANIA,DODAVATELID, DODAVATEL.NAZOV as NazovDodavatela," +
                    "DECODE(VYBAVENA, 'V', 'Vybavená', 'N', 'Nevybavená', 'C', 'Čiastočne vybavená') " +
                    "Vybavena from objednavka join dodavatel using (dodavatelID) where VYBAVENA = 'V'";

                using (OracleCommand cmd = new OracleCommand(sql, databaza.Connection))
                {

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        zobrazObjednavkyPage.vsetkyObjednavky.DataContext = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Upraveny_MessageBox.Show(ex.Message);
                });
            }

            HlavnyFrame.Content = zobrazObjednavkyPage;
        }

        private void ButtZobrazCiastocneVybavene_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var sql = "select OBJEDNAVKAID,DATUMDODANIA,DODAVATELID, DODAVATEL.NAZOV as NazovDodavatela," +
                    "DECODE(VYBAVENA, 'V', 'Vybavená', 'N', 'Nevybavená', 'C', 'Čiastočne vybavená') " +
                    "Vybavena from objednavka join dodavatel using (dodavatelID) where VYBAVENA = 'C'";

                using (OracleCommand cmd = new OracleCommand(sql, databaza.Connection))
                {

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        zobrazObjednavkyPage.vsetkyObjednavky.DataContext = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Upraveny_MessageBox.Show(ex.Message);
                });
            }

            HlavnyFrame.Content = zobrazObjednavkyPage;
        }

        private void ButtZobrazNevybavene_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var sql = "select OBJEDNAVKAID,DATUMDODANIA,DODAVATELID, DODAVATEL.NAZOV as NazovDodavatela," +
                    "DECODE(VYBAVENA, 'V', 'Vybavená', 'N', 'Nevybavená', 'C', 'Čiastočne vybavená') " +
                    "Vybavena from objednavka join dodavatel using (dodavatelID) where VYBAVENA =+ 'N'";

                using (OracleCommand cmd = new OracleCommand(sql, databaza.Connection))
                {

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        zobrazObjednavkyPage.vsetkyObjednavky.DataContext = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Upraveny_MessageBox.Show(ex.Message);
                });
            }

            HlavnyFrame.Content = zobrazObjednavkyPage;
        }

        /// <summary>
        /// Metody pre zobrazenie tovarov v objednavke
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Objednavka_Click(object sender, RoutedEventArgs e)
        {

            var objednavka = ((sender as DataGridCell).DataContext as DataRowView);
            var objednavkaID = objednavka.Row.ItemArray[2];

            TovaryNaZobrazenie tovaryVObjednavke = new TovaryNaZobrazenie(this, (string)objednavkaID);
            tovaryNaZobrazenieList.Add(tovaryVObjednavke);

            try
            {
                using (OracleCommand cmd = new OracleCommand("select tovarID,datumDorucenia,DatumPrijatiaNaSklad," +
                    "Hmotnost,dlzka,sirka,vyska,Decode(Prijaty, null, 'NIE', 'ÁNO') Prijaty, Decode(Doruceny, null, 'NIE', 'ÁNO') Doruceny," +
                    " objednavka.DATUMDODANIA as PlanovanyDatum, dodavatel.NAZOV as NazovDodavatela , " +
                    "prijemca.Meno as MenoPrijemcu, prijemca.ADRESA as AdresaPrijemcu, " +
                    " Decode(PrvaTrieda, 0, 'NIE', 1, 'ÁNO') PrvaTrieda  from tovar join objednavka using (objednavkaID) join dodavatel " +
                    "on(Dodavatel.DODAVATELID = objednavka.dodavatelID) join prijemca using (prijemcaID) " +
                    "where objednavkaID = " + "'" + objednavkaID + "'"
                    , databaza.Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        tovaryVObjednavke.vsetkyTovaryGrid.DataContext = dataTable; ;
                        tovaryVObjednavke.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
                {
                    Upraveny_MessageBox.Show(ex.Message);
                });
            }
        }


        //Ukoncovacia metoda
        private void Window_Closing(object sender, CancelEventArgs e)
        {

            if (!koniec)
            {
                MessageBoxResult result = Upraveny_MessageBox.Show("Chcete ukončiť aplikaciu?", "Ukončiť aplikaciu", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (pridajVozidloWindow != null)
                            pridajVozidloWindow.Close();
                        if (pridajDodavatelaWindow != null)
                            pridajDodavatelaWindow.Close();
                        if (pridajObjednavku != null)
                            pridajObjednavku.Close();
                        if (pridajDodavatelaWindow != null)
                            pridajDodavatelaWindow.Close();
                        if (trasaWindow != null)
                            trasaWindow.Close();

                        zobrazObjednavkyPage.vypniOkna();
                        zobrazVozidlaPage.vypniOkna();
                        zobrazDodavatelovPage.vypniOkna();

                        foreach (TovaryNaZobrazenie tovaryNaZobrazenie in tovaryNaZobrazenieList)
                        {
                            tovaryNaZobrazenie.Close();
                        }

                        foreach (Thread thread in threads)
                        {
                            thread.Abort();
                        }

                        if (Mapa_Window != null)
                        {
                            Mapa_Window.Dispatcher.Invoke(() =>
                            {
                                Mapa_Window.Zavriet = true;
                                Mapa_Window.Close();
                            });
                        }
                        break;
                    case MessageBoxResult.No:
                        e.Cancel = true;
                        break;
                }
            }
            else
            {
                if (pridajVozidloWindow != null)
                    pridajVozidloWindow.Close();
                if (pridajDodavatelaWindow != null)
                    pridajDodavatelaWindow.Close();
                if (pridajObjednavku != null)
                    pridajObjednavku.Close();
                if (pridajDodavatelaWindow != null)
                    pridajDodavatelaWindow.Close();
                if (Mapa_Window != null)
                {
                    Mapa_Window.Zavriet = true;
                    Mapa_Window.Close();
                }
            }
        }


        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void upravPriority()
        {
            var sql = " update tovar set priorita = CASE WHEN prvaTrieda = 0 then(CURRENT_DATE - datumPrijatiaNaSKlad) else 100000 end where datumPrijatiaNaSklad is not null";
            try
            {
                using (OracleCommand command = new OracleCommand(sql, databaza.Connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Dodávaťeľa sa nepodarilo pridať: " + ex.Message);
            }
        }

        public void VygenerujTrasu()
        {
            DataTable dataTable;
            DataTable vozidlaDataTable;
            List<Vozidlo> vozidlaList = new List<Vozidlo>();
            upravPriority();
            try
            {
                using (OracleCommand cmd = new OracleCommand("select nosnost,(sum(vyskaKufru) * sum(dlzkaKufru) * sum(sirkaKufru)) as objemVozidiel, vozidloID " +
                " from vozidlo  where polohavozidla is null group by vozidloID, nosnost"
              , databaza.Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        vozidlaDataTable = new DataTable();
                        vozidlaDataTable.Load(reader);
                    }
                }

                int pocetVozidiel = vozidlaDataTable.Rows.Count;

                if (pocetVozidiel == 0)
                {
                    throw new Exception("Trasa sa nedá vygenerovať, nie je žiadne volné vozidlo");
                }

                decimal kapacitaVozidla = 0;
                decimal nosnostVozidla = 0;

                kapacitaVozidla = (decimal)vozidlaDataTable.Rows[0].ItemArray[1];
                nosnostVozidla = (decimal)vozidlaDataTable.Rows[0].ItemArray[0];

                using (OracleCommand cmd = new OracleCommand("select tovarID, AdresaPrijemcu , " +
                    "sirka, vyska, dlzka, hmotnost, Decode(Prijaty, null, 'NIE', 'ÁNO') Prijaty, Decode(Doruceny, null, 'NIE', 'ÁNO') Doruceny, " +
                    "Decode(PrvaTrieda, 0, 'NIE', 1, 'ÁNO') PrvaTrieda ,  MenoPrijemcu, NazovDodavatela, PlanovanyDatum " +
                    "from(select t.*, prijemca.Meno as MenoPrijemcu, dodavatel.NAZOV as NazovDodavatela, datumDorucenia,DatumPrijatiaNaSklad, " +
                    "objednavka.DATUMDODANIA as PlanovanyDatum,  prijemca.ADRESA as AdresaPrijemcu, " +
                    "sum(t.sirka * t.vyska * t.dlzka) over(order by( (priorita / t.sirka * t.vyska * t.dlzka)) desc) " +
                    "as credit_sum from tovar t join prijemca on (t.prijemcaID = prijemca.prijemcaID) join dodavatel on (t.dodavatelID = dodavatel.dodavatelID) " +
                    "join objednavka on (t.objednavkaID = objednavka.objednavkaID) " +
                    "where prijaty = 1 and doruceny is null) " +
                     "where credit_sum <= (select SUM(VYSKAKUFRU * SIRKAKUFRU * DLZKAKUFRU) from vozidlo  " +
                     "where polohavozidla is null)  order by ((priorita / sirka * vyska * dlzka)) desc"
                 , databaza.Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        dataTable = new DataTable();
                        dataTable.Load(reader);
                    }
                }

                List<Tovar> tovary = new List<Tovar>();

                tovary.Add(new Tovar("", "Chynorany", 0, 0, 0, 0, 0));

                foreach (DataRow row in dataTable.Rows)
                {
                    tovary.Add(new Tovar((String)row[0], (String)row[1] + ", Slovakia", (decimal)row[2], (decimal)row[3],
                        (decimal)row[4], (decimal)row[5], 0));
                }

                List<Tovar> vytriedenyZoznam = tovary.GroupBy(tovar => tovar.Adresa).Select(group => group.First()).ToList();
                decimal[] poziadavky = new decimal[vytriedenyZoznam.Count];

                decimal celkovyObjemTovarov = 0;

                for (int i = 0; i < vytriedenyZoznam.Count; i++)
                {
                    foreach (Tovar tovar in tovary)
                    {
                        if (tovar.Adresa == vytriedenyZoznam[i].Adresa)
                        {
                            poziadavky[i] += tovar.Dlzka * tovar.Vyska * tovar.Sirka;
                            celkovyObjemTovarov += tovar.Dlzka * tovar.Vyska * tovar.Sirka;
                        }
                    }
                }

                decimal pocetPotrebnych = Math.Ceiling(celkovyObjemTovarov / kapacitaVozidla);

                if(pocetPotrebnych > vozidlaDataTable.Rows.Count)
                {
                    pocetPotrebnych = vozidlaDataTable.Rows.Count;
                }

                for (int i = 0; i < pocetPotrebnych; i++)
                {
                    vozidlaList.Add(new Vozidlo((decimal)vozidlaDataTable.Rows[i].ItemArray[0], (decimal)vozidlaDataTable.Rows[i].ItemArray[1],
                        (string)vozidlaDataTable.Rows[i].ItemArray[2]));
                }


                var cesty = rozdelTrasu(vytriedenyZoznam, vozidlaList, poziadavky);
                int indexVozidla = 0;

                foreach (List<String> cesta in cesty)
                {
                    int poradie = 0;

                    var sqlTrasa = "INSERT INTO trasa (trasaID, vozidloID, datumTrasy) VALUES (:trasaID, :vozidloID, :datumTrasy)";

                    using (OracleCommand command = new OracleCommand(sqlTrasa, databaza.Connection))
                    {
                        command.Parameters.Add("trasaID", 1);
                        command.Parameters.Add("vozidloID", vozidlaList[indexVozidla].SPZ);
                        command.Parameters.Add("datumTrasy", DateTime.Today.ToShortDateString());
                        command.ExecuteNonQuery();
                    }

                    int trasaID = -1;
                    using (OracleCommand cmd = new OracleCommand("select TRASAID_SEQUENCE.currval from DUAL"
                  , databaza.Connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable trasaIDDataTable = new DataTable();
                            trasaIDDataTable.Load(reader);
                            trasaID = Convert.ToInt16((decimal)trasaIDDataTable.Rows[0].ItemArray[0]);
                        }
                    }

                    var sqlVoz = "update vozidlo set polohaVozidla = 1 " +
                             " where vozidloID = " + "'" + vozidlaList[indexVozidla].SPZ + "'";

                    using (OracleCommand cmd = new OracleCommand(sqlVoz, Databaza.Connection))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    foreach (String adresa in cesta)
                    {
                        foreach (Tovar tovar in tovary.ToList())
                        {
                            if (tovar.Adresa == adresa)
                            {
                                var sql = "update tovar set vozidloID = '" + vozidlaList[indexVozidla].SPZ + "' , poradieVTrase = " + poradie +
                                    " , trasaID = " + trasaID +
                                    " where tovarID = " + "'" + tovar.CisloBaliku + "'";

                                using (OracleCommand cmd = new OracleCommand(sql, Databaza.Connection))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }
                        poradie++;
                    }
                    indexVozidla++;
                }

                this.Dispatcher.Invoke(() =>
                {
                    trasaWindow = new TrasaWindow(this, DateTime.Today);
                    trasaWindow.Show();
                });

            }
            catch (Exception ex)
            {
                this.Dispatcher.Invoke(() =>
               {
                   Upraveny_MessageBox.Show(ex.Message);
               });
            }
        }

        private void ButtVygenerujTrasu_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(VygenerujTrasu);
            thread.Start();
            threads.Add(thread);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (HlavneOkno.IsLoaded)
            {
                Sirka = HlavneOkno.Width - 282;
                Vyska = HlavneOkno.Height - 90;
                DnesPrichadzajuceObjednavkyGrid.Height = HlavneOkno.Height - 90;
            }
        }

        private void HlavneOkno_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState != System.Windows.WindowState.Maximized)
            {
                IsMaxed = "[ ]";
            }
            else
            {
                IsMaxed = "[]]";
            }
        }

        private void ButtZobrazTrasu_Click(object sender, RoutedEventArgs e)
        {
            trasaWindow = new TrasaWindow(this, DateTime.Today);
            trasaWindow.Show();
        }
    }
}
