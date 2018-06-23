using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using GMap.NET;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Bakalarka.Pages;

namespace Bakalarka.Triedy.Databaza
{
    public class Databaza : INotifyPropertyChanged
    {
        OracleConnection connection;
        String stav;
        public Databaza()
        {
            stav = "Odpojený";
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public void zobrazObjednavky(ZobrazObjednavkyPage zobrazObjednavkyPage)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("select OBJEDNAVKAID,DATUMDODANIA,DODAVATELID, DODAVATEL.NAZOV as NazovDodavatela," +
                    "DECODE(VYBAVENA, 'V', 'Vybavená', 'N', 'Nevybavená', 'C', 'Čiastočne vybavená') " +
                    "Vybavena from objednavka join dodavatel using (dodavatelID) order by objednavkaID", Connection))
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
                MessageBox.Show(ex.Message);
            }
        }

        public void zobrazVozidla(ZobrazVozidlaPage zobrazVozidlaPage)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("select datumEmisnej, datumEvidencie, datumStk, datumVyradenia , " + 
                                "najazdeneKm, znacka, typ, vyskaKufru, sirkaKufru, dlzkaKufru, nosnost, polohavozidla, vozidloID , " +
                                "decode(POLOHAVOZIDLA, null, 'NIE', 'ÁNO')  Aktivne from vozidlo order by vozidloID", Connection))
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
                MessageBox.Show(ex.Message);
            }
        }

        public void zobrazTovary(ZobrazTovaryPage zobrazTovaryPage)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("select vozidloID,tovarID,datumDorucenia,DatumPrijatiaNaSklad,Hmotnost,dlzka,sirka,vyska," +
                    "Decode(Prijaty, null, 'NIE', 'ÁNO') Prijaty, Decode(Doruceny, null, 'NIE', 'ÁNO') Doruceny, " +
                    " objednavka.DATUMDODANIA as PlanovanyDatum, dodavatel.NAZOV as NazovDodavatela , " +
                    "prijemca.Meno as MenoPrijemcu, prijemca.ADRESA as AdresaPrijemcu, " +
                    " Decode(PrvaTrieda, 0, 'NIE', 1, 'ÁNO') PrvaTrieda  from tovar join objednavka using (objednavkaID) join dodavatel " +
                    "on(Dodavatel.DODAVATELID = objednavka.dodavatelID) join prijemca using (prijemcaID) order by tovarID", Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        var sa = dataTable.Rows[0];
                        zobrazTovaryPage.vsetkyTovaryGrid.DataContext = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void zobrazDodavatelov(ZobrazDodavatelov zobrazDodavatelovPage)
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("select * from dodavatel order by nazov", Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        zobrazDodavatelovPage.DataContext = this;
                        zobrazDodavatelovPage.dodavateliaGrid.DataContext = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable dajVsetkychDodavatelov()
        {
            try
            {
                using (OracleCommand cmd = new OracleCommand("select * from dodavatel order by NAZOV", Connection))
                {
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        return dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public bool pridajTovar(String cisloTovaru, double hmotnost, double sirka, double vyska, double dlzka, int prijemcaId, string objednavkaID, Oracle.ManagedDataAccess.Types.OracleDecimal prvaTrieda)
        {

            var sql = "INSERT INTO tovar (tovarID, HMOTNOST, DLZKA, SIRKA, VYSKA, PRIJEMCAID,OBJEDNAVKAID,DODAVATELID, prvaTrieda) " +
                "VALUES (:tovarID, :hmotnost, :dlzka ,:sirka, :vyska, :prijemcaId, :objednavkaID, :dodavatelID, :prvaTrieda)";
            try
            {
                using (OracleCommand command = new OracleCommand(sql, Connection))
                {
                    command.Parameters.Add("tovarID", cisloTovaru);
                    command.Parameters.Add("hmotnost", hmotnost);
                    command.Parameters.Add("dlzka", dlzka);

                    command.Parameters.Add("sirka", sirka);
                    command.Parameters.Add("vyska", vyska);
                    command.Parameters.Add("prijemcaId", prijemcaId);
                    command.Parameters.Add("objednavkaID", objednavkaID);

                    DataTable dataTable;
                    using (OracleCommand cmd = new OracleCommand("select dodavatelID from objednavka where objednavkaID =" + "'" + objednavkaID + "'", Connection))
                    {
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            dataTable = new DataTable();
                            dataTable.Load(reader);
                        }
                    }

                    var pom = dataTable.Rows[0].ItemArray[0];
                    string dodavatelID = (string)(pom);
                    command.Parameters.Add("dodavatelID", dodavatelID);
                    command.Parameters.Add("prvaTrieda", "" + prvaTrieda);


                    command.ExecuteNonQuery();
                    // MessageBox.Show("Tovar bol úspešne pridaný ");
                    return true;

                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Tovar sa nepodarilo pridať: " + ex.Message);
                return false;
            }
        }


        public bool pridajDodavatela(string adresa, string ico, string nazov)
        {
            var sql = "INSERT INTO dodavatel (adresa, nazov, dodavatelID) VALUES (:adresa, :nazov, :dodavatelID)";
            try
            {
                using (OracleCommand command = new OracleCommand(sql, Connection))
                {
                    command.Parameters.Add("adresa", adresa);
                    command.Parameters.Add("nazov", nazov);
                    command.Parameters.Add("dodavatelID", ico);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Dodávateľ bol úspešne pridaný ");
                    return true;

                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Dodávaťeľa sa nepodarilo pridať: " + ex.Message);
                return false;
            }
        }

        public bool pridajVozidlo(string spz, string znacka, string typ, double vyskaKufru, double sirkaKufru, double dlzkaKufru, double nosnost, double najazdeneKm,DateTime datumEvidencie, DateTime datumStk, DateTime datumEminsej)

        {
            var sql = "INSERT INTO vozidlo (vozidloID, znacka, typ,vyskaKufru,sirkaKufru,dlzkaKufru,nosnost, najazdeneKm, datumEvidencie, datumEmisnej, datumStk) " +
                "VALUES (:vozidloID, :znacka, :typ, :vyskaKufru, :sirkaKufru, :dlzkaKufru, :nosnost,:najazdeneKm  ,:datumEvidencie,:datumEmisnej, :datumStk)";
            try
            {
                using (OracleCommand command = new OracleCommand(sql, Connection))
                {
                    command.Parameters.Add("vozidloID", spz);
                    command.Parameters.Add("znacka", znacka);
                    command.Parameters.Add("typ", typ);
                    command.Parameters.Add("vyskaKufru", vyskaKufru);
                    command.Parameters.Add("sirkaKufru", sirkaKufru);
                    command.Parameters.Add("dlzkaKufru", dlzkaKufru);
                    command.Parameters.Add("nosnost", nosnost);
                    command.Parameters.Add("najazdeneKm", najazdeneKm);
                    command.Parameters.Add("datumEvidencie", datumEvidencie);
                    command.Parameters.Add("datumEminsej", datumEminsej);
                    command.Parameters.Add("datumStk", datumStk);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Vozidlo bolo pridané úspešne");
                    return true;

                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Vozidlo sa nepodarilo pridať: " + ex.Message);
                return false;
            }
        }

        public bool pridajObjednavku(String cisloObjednavky, DateTime datumDodania, String dodavatelID)
        {

            var sql = "INSERT INTO objednavka (OBJEDNAVKAID, DATUMDODANIA, DODAVATELID, VYBAVENA) " +
                "VALUES (:OBJEDNAVKAID, :datumDodania, :dodavatelID, :vybavena)";
            try
            {
                using (OracleCommand command = new OracleCommand(sql, Connection))
                {
                    command.Parameters.Add("OBJEDNAVKAID", cisloObjednavky);
                    command.Parameters.Add("datumDodania", datumDodania);
                    command.Parameters.Add("dodavatelID", dodavatelID);
                    command.Parameters.Add("vybavena", 'N');
                    command.ExecuteNonQuery();
                    return true;

                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Objednávku sa nepodarilo pridať: " + ex.Message);
                return false;
            }
        }

        public bool pridajPrijemcu(String meno, string adresa, string telefon)
        {

            var sql = "INSERT INTO prijemca (meno, adresa, telefon, prijemcaID) " +
                "VALUES (:meno, :adresa, :telefon, :prijemcaID)";
            try
            {
                using (OracleCommand command = new OracleCommand(sql, Connection))
                {
                    command.Parameters.Add("meno", meno);
                    command.Parameters.Add("adresa", adresa);
                    command.Parameters.Add("telefon", telefon);
                    command.Parameters.Add("prijemcaID", 10);


                    command.ExecuteNonQuery();
                    // MessageBox.Show("Príjemca bol úspešne pridaný ");
                    return true;


                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Príjemcu sa nepodarilo pridať: " + ex.Message);
                return false;
            }

        }

        public bool Pripoj(String hostName, String port, String serviceName, String user, String heslo)
        {
            string oradb = "Data Source = (DESCRIPTION = (ADDRESS = (PROTOCOL = tcp)(HOST = " + hostName
                + ")(PORT = " + port + "))(CONNECT_DATA = (SERVICE_NAME ="
                + serviceName + "))); User Id = "
                + user + "; Password = "
                + heslo + "; ";

            Connection = new OracleConnection(oradb);
            try
            {
                Connection.Open();
                stav = "Pripojený";
                return true;
            }
            catch (Exception)
            {
                stav = "Odpojený";
                Connection.Close();
                Connection.Dispose();
                return false;
            }
        }


        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string Stav
        {
            get => stav; set
            {
                if (stav != value)
                {
                    stav = value;
                    OnPropertyChanged("Stav");
                }
            }
        }

        public OracleConnection Connection { get => connection; set => connection = value; }
    }
}
