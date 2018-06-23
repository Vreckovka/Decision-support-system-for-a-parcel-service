using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Bakalarka.Triedy;
using Google.Maps.DistanceMatrix;
using Google.Maps;
using Google.Maps.Geocoding;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Bakalarka.Windows;
using Bakalarka.Mapa.Pages;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using System.Windows.Navigation;
using Bakalarka.Pages;
using Bakalarka.Mapa;
using Oracle.ManagedDataAccess.Client;
using Bakalarka.Triedy.Databaza;
using System.Data;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System.Device.Location;
using BingMapsRESTToolkit.Extensions;
using BingMapsRESTToolkit;
using Bakalarka;

namespace Bakalarka.Triedy.Algoritmy
{
    class Clarke_Wright
    {
        public class Smer : IComparable
        {
            int _od;
            int _do;
            String mestoOd;
            String mestoDo;
            double saving;
            public Smer(int od, int pdo, double za)
            {
                Do = pdo;
                Od = od;
                Saving = za;
            }

            public Smer(String pmestoOd, String pmestoDo, double za)
            {
                mestoOd = pmestoOd;
                mestoDo = pmestoDo;
                Saving = za;
            }

            public static Smer operator <(Smer a, Smer b)
            {
                if (a.Saving < b.Saving)
                {
                    return a;
                }
                return b;
            }
            public static Smer operator >(Smer a, Smer b)
            {
                if (a.Saving > b.Saving)
                {
                    return a;
                }
                return b;
            }

            public int Od { get => _od; set => _od = value; }
            public int Do { get => _do; set => _do = value; }
            public double Saving { get => saving; set => saving = value; }
            public string MestoOd { get => mestoOd; set => mestoOd = value; }
            public string MestoDo { get => mestoDo; set => mestoDo = value; }

            public int CompareTo(object obj)
            {
                return (obj as Smer).Saving.CompareTo(this.Saving);
            }
        }
        public class Cesta
        {
            List<Smer> smery;
            Vozidlo vozidlo;
            public Cesta(Vozidlo pVozidlo)
            {
                smery = new List<Smer>();
                Vozidlo = pVozidlo;
            }

            public void vypisCestu()
            {
                foreach (Smer smer in smery)
                {
                    //Console.WriteLine("[ " + smer.Od + " ," + smer.Do + " ]");
                }
            }

            public bool jeUzPouzite(String mesto)
            {
                foreach (String pouziteMesto in _uzPouziteMesta)
                {
                    if (mesto == pouziteMesto)
                    {
                        return true;
                    }
                }
                return false;
            }
            public List<String> vypisCestuString()
            {
                List<string> cesta = new List<string>();
                String[] pole = new String[(int)Math.Sqrt(_maticaVzdialenosti.Length)];

                for (int i = 0; i < Smery.Count; i++)
                {
                    pole[smery[i].Do] += smery[i].MestoDo;
                    pole[smery[i].Od] += smery[i].MestoOd;

                }
                String aktualneMesto = "";
                String dalsieMesto = "";
                Smer prvySmer = null;

                cesta.Add(_nazvyMiest[0]);
                ////Console.Write(_nazvyMiest[0] + " -> ");
                for (int i = 0; i < pole.Length; i++)
                {
                    foreach (Smer smer in smery)
                    {
                        if (pole[i] == smer.MestoDo)
                        {
                            prvySmer = smer;
                            aktualneMesto = smer.MestoDo;
                            dalsieMesto = smer.MestoOd;

                            if (!jeUzPouzite(aktualneMesto))
                            {
                                ////Console.Write(aktualneMesto + " -> ");
                                cesta.Add(aktualneMesto);
                                _uzPouziteMesta.Add(aktualneMesto);
                            }
                            if (!jeUzPouzite(dalsieMesto))
                            {
                                // //Console.Write(dalsieMesto + " -> ");
                                cesta.Add(dalsieMesto);
                                _uzPouziteMesta.Add(dalsieMesto);
                            }
                            break;
                        }
                        else if (pole[i] == smer.MestoOd)
                        {
                            prvySmer = smer;
                            aktualneMesto = smer.MestoOd;
                            dalsieMesto = smer.MestoDo;

                            if (!jeUzPouzite(aktualneMesto))
                            {
                                // //Console.Write(aktualneMesto + " -> ");

                                cesta.Add(aktualneMesto);
                                _uzPouziteMesta.Add(aktualneMesto);
                            }
                            if (!jeUzPouzite(dalsieMesto))
                            {
                                ////Console.Write(dalsieMesto + " -> ");
                                cesta.Add(dalsieMesto);
                                _uzPouziteMesta.Add(dalsieMesto);
                            }

                            break;
                        }
                    }
                    if (prvySmer != null)
                        break;
                }

                Smer momentalnySmer = prvySmer;
                int pocet = 1;
                while (pocet <= smery.Count - 1)
                {
                    foreach (Smer smer in smery)
                    {
                        if (smer.MestoDo == dalsieMesto && smer.MestoOd != aktualneMesto)
                        {
                            aktualneMesto = smer.MestoDo;
                            dalsieMesto = smer.MestoOd;

                            cesta.Add(dalsieMesto);
                            ////Console.Write(dalsieMesto + " -> ");
                            _uzPouziteMesta.Add(dalsieMesto);

                            pocet++;
                            break;

                        }
                        else if (smer.MestoOd == dalsieMesto && smer.MestoDo != aktualneMesto)
                        {
                            aktualneMesto = smer.MestoOd;
                            dalsieMesto = smer.MestoDo;
                            cesta.Add(dalsieMesto);
                            ////Console.Write(dalsieMesto + " -> ");
                            _uzPouziteMesta.Add(dalsieMesto);

                            pocet++;

                            break;
                        }
                    }
                }
                cesta.Add(_nazvyMiest[0]);
                ////Console.Write(_nazvyMiest[0]);
                ////Console.WriteLine();
                return cesta;
            }

            internal List<Smer> Smery { get => smery; set => smery = value; }
            public Vozidlo Vozidlo { get => vozidlo; set => vozidlo = value; }
        }

        private static List<Cesta> _cesty;
        private static decimal[] _poziadavky;
        private static double[,] _maticaVzdialenosti;
        private static String[] _nazvyMiest;
        private static List<String> _uzPouziteMesta;
        private static List<Cesta> _vyslednaCesta;
        private static List<Smer> _savings;
        private static List<Vozidlo> _vozidla;
        private static double _maxSaving;
        private static readonly object syncPrimitive = new object();
        private static int pocetPoloziek;
        private static LoadingPage _loadingPage;

        public List<Cesta> VyslednaCesta { get => _vyslednaCesta; set => _vyslednaCesta = value; }

        public void GoogleNacitajMaticu(List<Tovar> tovary)
        {
            // GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyC5MAtNKdvZbg8QBRZa5_xCnDRGRu9Fo5g"));

            //GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyCaMSWQkuwzUolUntovPOnJGnoBeLBVZHc"));

            GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyBjRde0e9LBWKqdj2-8m3l3fcWaN2Mv4Ck"));

            for (int i = 0; i < tovary.Count(); i++)
            {
                Thread.Sleep(100);
                Google.Maps.DistanceMatrix.DistanceMatrixRequest request = new Google.Maps.DistanceMatrix.DistanceMatrixRequest();
                request.AddOrigin(tovary[i].Adresa);

                for (int y = 0; y < tovary.Count(); y++)
                {
                    request.AddDestination(tovary[y].Adresa);
                    _loadingPage.updateProgressBar(100 / (Convert.ToDouble(tovary.Count()) * Convert.ToDouble(tovary.Count())));
                }

                DistanceMatrixResponse response = new DistanceMatrixService().GetResponse(request);

                try
                {
                    for (int x = 0; x < response.Rows[0].Elements.Length; x++)
                    {
                        _maticaVzdialenosti[i, x] = response.Rows[0].Elements[x].distance.Value;
                        _loadingPage.updateProgressBar(100 / (Convert.ToDouble(tovary.Count()) * Convert.ToDouble(tovary.Count()) * Convert.ToDouble(response.Rows[0].Elements.Length)));
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(response.ErrorMessage.ToString());
                }
            }

            _cesty = new List<Cesta>();

            _nazvyMiest = new string[tovary.Count()];
            //_poziadavky = ppoziadavky;

            for (int i = 0; i < tovary.Count(); i++)
            {
                _nazvyMiest[i] = tovary[i].Adresa;
            }
        }

        public void AlternativneNacitanie(List<Tovar> tovary)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            GeocodingProvider geocodingProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            GeoCoderStatusCode statusCode = GeoCoderStatusCode.Unknow;


            //var A = GMap.NET.MapProviders.OpenSeaMapHybridProvider.Instance.GetPoint(tovary[0].Adresa, out statusCode).Value;
            //var B = GMap.NET.MapProviders.OpenSeaMapHybridProvider.Instance.GetPoint(tovary[1].Adresa, out statusCode).Value;
            //MapRoute route = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetRoute(A, B, false, false, 15);


            PointLatLng A;
            PointLatLng B;

            for (int i = 0; i < tovary.Count(); i++)
            {
                try
                {
                    A = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetPoint(tovary[i].Adresa, out statusCode).Value;
                }
                catch (System.InvalidOperationException)
                {

                    GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyBjRde0e9LBWKqdj2-8m3l3fcWaN2Mv4Ck"));

                    var request = new GeocodingRequest();
                    request.Address = tovary[i].Adresa;
                    var response = new GeocodingService().GetResponse(request);

                    if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
                    {
                        var result = response.Results.First();
                        A = new PointLatLng(result.Geometry.Location.Latitude, result.Geometry.Location.Longitude);
                    }
                    else
                    {
                        Upraveny_MessageBox.Show("Nepodarilo sa najsť " + tovary[i].Adresa);
                        throw new Exception();
                    }
                }
                for (int y = 0; y < tovary.Count(); y++)
                {
                    try
                    {
                        B = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetPoint(tovary[y].Adresa, out statusCode).Value;
                    }
                    catch (System.InvalidOperationException)
                    {

                        GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyBjRde0e9LBWKqdj2-8m3l3fcWaN2Mv4Ck"));

                        var request = new GeocodingRequest();
                        request.Address = tovary[y].Adresa;
                        var response = new GeocodingService().GetResponse(request);

                        if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
                        {
                            var result = response.Results.First();
                            B = new PointLatLng(result.Geometry.Location.Latitude, result.Geometry.Location.Longitude);
                        }
                        else
                        {
                            Upraveny_MessageBox.Show("Nepodarilo sa najsť " + tovary[y].Adresa);
                            throw new Exception();
                        }
                    }

                    var sCoord = new GeoCoordinate(A.Lat, A.Lng);
                    var eCoord = new GeoCoordinate(B.Lat, B.Lng);

                    var distance = sCoord.GetDistanceTo(eCoord); ;

                    _maticaVzdialenosti[i, y] = (long)distance;
                    _loadingPage.updateProgressBar(100 / (Convert.ToDouble(tovary.Count()) * Convert.ToDouble(tovary.Count())));

                }
            }
        }

        public void BingNacitaj(List<Tovar> tovary)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            GeocodingProvider geocodingProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            GeoCoderStatusCode statusCode = GeoCoderStatusCode.Unknow;

            string key = "qJ8PKArWS2w7m1swoqUf~VZ22wvsEdF85BjaO5lESQA~AiOL6oiduDElxxIeUKG0me76ww732EZEbvlB7tjw-c-BBDC_4tbkQLo7KxyUGxUC";

            var distanceMatrix = new BingMapsRESTToolkit.DistanceMatrixRequest();
            distanceMatrix.BingMapsKey = key;
            distanceMatrix.Origins = new List<SimpleWaypoint>();
            distanceMatrix.Destinations = new List<SimpleWaypoint>();

            if (tovary.Count <= 25)
            {
                for (int i = 0; i < tovary.Count(); i++)
                {
                    GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyBjRde0e9LBWKqdj2-8m3l3fcWaN2Mv4Ck"));

                    var request = new GeocodingRequest();
                    request.Address = tovary[i].Adresa;
                    var response = new GeocodingService().GetResponse(request);


                    if (response.Results.Count() == 0)
                    {
                        var pom = new BingMapsRESTToolkit.GeocodeRequest();
                        pom.Address = new SimpleAddress();
                        pom.Address.AddressLine = tovary[i].Adresa;
                        var aa = pom.Execute().GetAwaiter().GetResult();
                        var asda = aa.ResourceSets.First().Resources.First();

                        //distanceMatrix.Origins.Add(asda);
                        //distanceMatrix.Destinations.Add(new SimpleWaypoint(point.Lat, point.Lng));
                    }
                    else
                    {
                        var resultPOM = response.Results.First();
                        var point = new PointLatLng(resultPOM.Geometry.Location.Latitude, resultPOM.Geometry.Location.Longitude);
                        distanceMatrix.Origins.Add(new SimpleWaypoint(point.Lat, point.Lng));
                        distanceMatrix.Destinations.Add(new SimpleWaypoint(point.Lat, point.Lng));
                    }

                    _loadingPage.updateProgressBar(100 / tovary.Count);
                }


                var result = distanceMatrix.Execute().GetAwaiter().GetResult();

                BingMapsRESTToolkit.DistanceMatrix distanceMatrixA = (DistanceMatrix)result.ResourceSets.First().Resources.First();

                int riadok = 0;
                int stlpec = 0;
                for (int i = 0; i < Math.Pow(tovary.Count, 2); i++)
                {
                    if (i % tovary.Count() == 0 && i != 0)
                    {
                        riadok++;
                        stlpec = 0;
                    }

                    _maticaVzdialenosti[riadok, stlpec] = distanceMatrixA.Results[i].TravelDistance;
                    _loadingPage.updateProgressBar(100 / Math.Pow(tovary.Count, 3));
                    stlpec++;
                }
            }
            else
            {
                int maxVelkostMatice = 625; //625 maximalna velkost matice
                int pocetTovarov = tovary.Count();

                int pocetRiadkov = maxVelkostMatice / pocetTovarov;

                int pocetOpakovani = pocetTovarov / pocetRiadkov;


                int zvysok = pocetTovarov - (pocetRiadkov * pocetOpakovani);
                // int zvysok = ((pocetTovarov * pocetTovarov) - (pocetOpakovani * pocetRiadkov * pocetTovarov)) / pocetTovarov;

                int maxPocetRiadkov = maxVelkostMatice / tovary.Count();

                GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyBjRde0e9LBWKqdj2-8m3l3fcWaN2Mv4Ck"));
                List<PointLatLng> adresy = new List<PointLatLng>();

                _loadingPage.zmenStatusPodrob("Získavam geolokácie adries");

                double pocetIteracii = pocetTovarov + (pocetOpakovani * (maxPocetRiadkov + pocetTovarov +
                    (maxPocetRiadkov * pocetTovarov)) + (zvysok + pocetTovarov + (zvysok * pocetTovarov)));

                for (int i = 0; i < tovary.Count; i++)
                {
                    var request = new GeocodingRequest();
                    request.Address = tovary[i].Adresa;
                    var response = new GeocodingService().GetResponse(request);

                    var resultPOM = response.Results.First();
                    adresy.Add(new PointLatLng(resultPOM.Geometry.Location.Latitude, resultPOM.Geometry.Location.Longitude));

                    _loadingPage.updateProgressBar(100 / pocetIteracii);
                }

                int poslednyRiadok = 0;
                _loadingPage.zmenStatusPodrob("Spravcovávam geolokácie");

                for (int i = 0; i < pocetOpakovani; i++)
                {

                    distanceMatrix = new BingMapsRESTToolkit.DistanceMatrixRequest();
                    distanceMatrix.BingMapsKey = key;
                    distanceMatrix.Origins = new List<SimpleWaypoint>();
                    distanceMatrix.Destinations = new List<SimpleWaypoint>();

                    for (int riadokI = poslednyRiadok; riadokI < maxPocetRiadkov + poslednyRiadok; riadokI++)
                    {
                        var point = adresy[riadokI];
                        distanceMatrix.Origins.Add(new SimpleWaypoint(point.Lat, point.Lng));
                        _loadingPage.updateProgressBar(100 / pocetIteracii);
                    }

                    for (int stlpecY = 0; stlpecY < tovary.Count; stlpecY++)
                    {
                        var point = adresy[stlpecY];
                        distanceMatrix.Destinations.Add(new SimpleWaypoint(point.Lat, point.Lng));

                        _loadingPage.updateProgressBar(100 / pocetIteracii);
                    }

                    var result = distanceMatrix.Execute().GetAwaiter().GetResult();

                    BingMapsRESTToolkit.DistanceMatrix distanceMatrixA = (DistanceMatrix)result.ResourceSets.First().Resources.First();

                    int stlpec = 0;
                    for (int x = 0; x < distanceMatrixA.Results.Count(); x++)
                    {
                        if (x % tovary.Count() == 0 && x != 0)
                        {
                            poslednyRiadok++;
                            stlpec = 0;
                        }

                        _maticaVzdialenosti[poslednyRiadok, stlpec] = distanceMatrixA.Results[x].TravelDistance;
                        _loadingPage.updateProgressBar(100 / pocetIteracii);
                        stlpec++;
                    }

                    poslednyRiadok++;
                }


                //zvysok
                distanceMatrix = new BingMapsRESTToolkit.DistanceMatrixRequest();
                distanceMatrix.BingMapsKey = key;
                distanceMatrix.Origins = new List<SimpleWaypoint>();
                distanceMatrix.Destinations = new List<SimpleWaypoint>();

                for (int riadokI = poslednyRiadok; riadokI < zvysok + poslednyRiadok; riadokI++)
                {
                    var point = adresy[riadokI];
                    distanceMatrix.Origins.Add(new SimpleWaypoint(point.Lat, point.Lng));
                    _loadingPage.updateProgressBar(100 / pocetIteracii);
                }

                for (int stlpecY = 0; stlpecY < tovary.Count; stlpecY++)
                {
                    var point = adresy[stlpecY];
                    distanceMatrix.Destinations.Add(new SimpleWaypoint(point.Lat, point.Lng));

                    _loadingPage.updateProgressBar(100 / pocetIteracii);
                }

                var resultB = distanceMatrix.Execute().GetAwaiter().GetResult();

                BingMapsRESTToolkit.DistanceMatrix distanceMatrixB = (DistanceMatrix)resultB.ResourceSets.First().Resources.First();

                var stlpecB = 0;
                for (int x = 0; x < distanceMatrixB.Results.Count(); x++)
                {
                    if (x % tovary.Count() == 0 && x != 0)
                    {
                        poslednyRiadok++;
                        stlpecB = 0;
                    }

                    _maticaVzdialenosti[poslednyRiadok, stlpecB] = distanceMatrixB.Results[x].TravelDistance;
                    _loadingPage.updateProgressBar(100 / pocetIteracii);
                    stlpecB++;
                }
            }
        }


        public Clarke_Wright(List<Tovar> tovary, List<Vozidlo> vozidla, decimal[] ppoziadavky, LoadingPage loadingPage)
        {

            _loadingPage = loadingPage;
            pocetPoloziek = tovary.Count;
            _vozidla = vozidla;
            _maticaVzdialenosti = new double[tovary.Count, tovary.Count];

            BingNacitaj(tovary);
            //GoogleNacitajMaticu(tovary, _poziadavky);
            //AlternativneNacitanie(tovary, _poziadavky);

            for (int i = 0; i < tovary.Count; i++)
            {
                for (int y = 0; y < tovary.Count; y++)
                {
                    //Console.Write(String.Format("{0:0.##}", (_maticaVzdialenosti[i, y])) + "\t");
                }
                //Console.WriteLine();
            }

            _cesty = new List<Cesta>();

            _nazvyMiest = new string[tovary.Count()];
            _poziadavky = ppoziadavky;

            for (int i = 0; i < tovary.Count(); i++)
            {
                _nazvyMiest[i] = tovary[i].Adresa;
            }

        }


        public static void spravPokus(object obj)
        {
            List<Smer> savings = new List<Smer>((List<Smer>)obj);
            int pocet = savings.Count;

            List<Cesta> vyslednaCesta = new List<Cesta>();

            double maxSaving = SpravCesty(vyslednaCesta, savings);

            Smer pom;

            for (int i = 0; i < savings.Count; i++)
            {
                pom = savings[i];
                savings.RemoveAt(i);

                List<Cesta> cesty = new List<Cesta>();

                if (suVsetkySmery(savings))
                {
                    double saving = SpravCesty(cesty, savings);

                    if (saving > maxSaving)
                    {
                        maxSaving = saving;
                        vyslednaCesta = new List<Cesta>(cesty);
                    }
                }
                savings.Add(pom);
            }

            lock (syncPrimitive)
            {
                if (_maxSaving < maxSaving)
                {
                    _maxSaving = maxSaving;
                    _vyslednaCesta = vyslednaCesta;
                }
            }

        }

        public double Ries()
        {
            giveSavings();
            List<Smer> pomSav = new List<Smer>(_savings);
            _vyslednaCesta = new List<Cesta>();
            _maxSaving = SpravCesty(_vyslednaCesta, _savings);
            double maxSaving = _maxSaving;
            _cesty = new List<Cesta>();

            Smer pom;
            List<Cesta> vyslednaCesta = new List<Cesta>();

            int replikacia = 0;

            for (int i = 0; i < _savings.Count; i++)
            {
                _savings = new List<Smer>(pomSav);
                pom = _savings[i];
                _savings.RemoveAt(i);
                int pocet = _savings.Count;

                for (int y = 0; y < _savings.Count; y++)
                {
                    _cesty.Clear();
                    if (suVsetkySmery(_savings))
                    {
                        double saving = SpravCesty(_cesty, _savings);
                        if (saving > maxSaving)
                        {
                            maxSaving = saving;
                            _vyslednaCesta = new List<Cesta>(_cesty);

                        }
                        if (i < _savings.Count)
                            _savings.RemoveAt(i);
                    }
                    _loadingPage.updateProgressBar(100 / (Convert.ToDouble(pocet) * Convert.ToDouble(_savings.Count())) * 2.3667936);
                }
                _savings.Add(pom);
                _savings.Sort();
                replikacia++;
            }

            return _maxSaving;
        }
        static bool suVsetkySmery(List<Smer> smery)
        {
            String[] pole = new String[(int)Math.Sqrt(_maticaVzdialenosti.Length)];

            for (int i = 0; i < smery.Count; i++)
            {
                pole[smery[i].Do] += smery[i].MestoDo;
                pole[smery[i].Od] += smery[i].MestoOd;
            }

            for (int i = 1; i < pole.Length; i++)
            {
                if (pole[i] == null)
                {
                    return false;
                }
            }
            return true;
        }
        public List<List<String>> vypisCestu(List<Cesta> cesta)
        {
            List<List<String>> pom = new List<List<string>>();
            _uzPouziteMesta = new List<string>();
            foreach (Cesta cestaa in cesta)
            {
                ////Console.WriteLine("Cesta ");
                pom.Add(cestaa.vypisCestuString());
            }
            return pom;
        }
        class AscendingComparer : IComparer<Smer>
        {
            public int Compare(Smer x, Smer y)
            {
                // use the default comparer to do the original comparison for datetimes
                int ascendingResult = Comparer<Smer>.Default.Compare(x, y);

                // turn the result around
                return ascendingResult;
            }
        }
        static void giveSavings()
        {
            List<Smer> cesta = new List<Smer>();

            double hodnota = 0;
            for (int y = 1; y < Math.Sqrt(_maticaVzdialenosti.Length) - 1; y++)
            {
                for (int x = y + 1; x < Math.Sqrt(_maticaVzdialenosti.Length); x++)
                {
                    hodnota = (_maticaVzdialenosti[0, y] + _maticaVzdialenosti[0, x]) - _maticaVzdialenosti[y, x];
                    Smer smer = new Smer(y, x, hodnota);
                    smer.MestoOd = _nazvyMiest[y];
                    smer.MestoDo = _nazvyMiest[x];
                    cesta.Add(smer);
                }
            }

            cesta.Sort(new AscendingComparer());
            _savings = cesta;

        }

        static Cesta dajCestu(List<Cesta> vsetkyCesty, int a, int b)
        {
            foreach (Cesta cesta in vsetkyCesty)
            {
                foreach (Smer smer in cesta.Smery)
                {
                    if (smer.Do == a || smer.Od == a || smer.Do == b || smer.Od == b)
                    {
                        return cesta;
                    }
                }

            }
            return null;
        }
        static public bool jePriradena(List<Cesta> vsetkyCesty, int a, int b)
        {
            foreach (Cesta cesta in vsetkyCesty)
            {
                foreach (Smer smer in cesta.Smery)
                {
                    if (smer.Do == a || smer.Od == a || smer.Do == b || smer.Od == b)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool jeVRozdielnych(List<Cesta> vsetkyCesty, int a, int b)
        {
            int pocetNalezov = 0;
            foreach (Cesta cesta in vsetkyCesty)
            {
                foreach (Smer path in cesta.Smery)
                {
                    if (path.Do == a || path.Od == a || path.Do == b || path.Od == b)
                    {
                        pocetNalezov++;
                        break;
                    }
                }
                if (pocetNalezov >= 2)
                {
                    return true;
                }
            }
            return false;
        }
        static bool nachadzajuSaObe(Cesta cesta, int a, int b)
        {
            bool jeA = false;
            bool jeB = false;

            foreach (Smer smer in cesta.Smery)
            {
                if ((smer.Do == a || smer.Od == a) && (smer.Do == b || smer.Od == b))
                {
                    return true;
                }
                if (smer.Do == a || smer.Od == a)
                {
                    jeA = true;
                }
                else if (smer.Do == b || smer.Od == b)
                {
                    jeB = true;
                }
                if (jeA && jeB)
                    return true;
            }
            return false;
        }

        static public bool nachadzaSa(Cesta cesta, int a)
        {

            foreach (Smer smer in cesta.Smery)
            {
                if (smer.Do == a || smer.Od == a)
                {
                    return true;
                }
            }

            return false;
        }
        static bool nachadzaSa2x(Cesta cesta, int a, int b)
        {
            int pocetNalezovA = 0;
            int pocetNalezovB = 0;

            foreach (Smer smer in cesta.Smery)
            {
                if (smer.Do == a || smer.Od == a)
                {
                    pocetNalezovA++;
                }
                else if (smer.Do == b || smer.Od == b)
                {
                    pocetNalezovA++;
                }
                if (pocetNalezovA == 2 || pocetNalezovB == 2)
                    return true;
            }
            return false;
        }
        static public double SpravCesty(List<Cesta> cesty, List<Smer> savings)
        {
            List<Smer> nepridane = new List<Smer>(savings);
            List<Smer> priradene = new List<Smer>();

            Cesta pomCesta = null;
            double saving = 0;
            int pridane = 0;
            int pocetAktualnePouzitychVozidiel = 0;

            bool nasieloSaVozidlo = false;

            foreach (Smer prvy in savings)
            {
                for (int i = 0; i < _vozidla.Count; i++)
                {
                    if (_poziadavky[prvy.Do] + _poziadavky[prvy.Od] <= _vozidla[i].ObjemVozidla)
                    {
                        Console.WriteLine("Nova Trasa");
                        Console.WriteLine("[ " + prvy.MestoOd + " ," + prvy.MestoDo + " ]");

                        pomCesta = new Cesta(_vozidla[i]);
                        _vozidla[i].Aktivne = true;
                        pomCesta.Smery.Add(prvy);

                        pomCesta.Vozidlo.NaplnenyObjem += _poziadavky[prvy.Od] + _poziadavky[prvy.Do];
                        cesty.Add(pomCesta);

                        pridane += 2;
                        nepridane.Remove(prvy);
                        pocetAktualnePouzitychVozidiel++;
                        saving += prvy.Saving;
                        nasieloSaVozidlo = true;
                        break;
                    }
                }
                if (nasieloSaVozidlo)
                    break;
            }




            bool pridaloSa = true;
            bool druhyPokus = false;
            bool nedaSa = false;
            if (pomCesta == null)
            {
                nedaSa = true;
            }

            while (pridane != _poziadavky.Length - 1 && !nedaSa)
            {
                if (!pridaloSa && druhyPokus)
                {
                    bool koniec = false;
                    if (pridane + 1 == _poziadavky.Length - 1)
                    {
                        int[] pole = new int[(int)Math.Sqrt(_maticaVzdialenosti.Length)];
                        foreach (Smer a in priradene)
                        {
                            pole[a.Do] = 1;
                            pole[a.Od] = 1;
                        }
                        for (int i = 1; i < pole.Length; i++)
                        {
                            if (pole[i] != 1)
                            {
                                foreach (Smer a in nepridane)
                                {
                                    if (a.Do == i || a.Od == i)
                                    {
                                        Console.WriteLine("Nova Trasa");
                                        Console.WriteLine("[ " + a.MestoOd + " ," + a.MestoDo + " ]");

                                        int index = -1;
                                        for (int x = 0; x < _vozidla.Count; x++)
                                        {
                                            if (_vozidla[x].Aktivne == false)
                                            {
                                                index = x;
                                                break;
                                            }
                                        }

                                        if (index != -1)
                                        {
                                            pomCesta = new Cesta(_vozidla[index]);
                                            _vozidla[index].Aktivne = true;
                                            pomCesta.Smery.Add(a);
                                            cesty.Add(pomCesta);
                                            saving += a.Saving;
                                            nepridane.Remove(a);
                                            koniec = true;
                                            break;
                                        }
                                        else
                                        {
                                            nepridane.Remove(a);
                                            break;
                                        }
                                    }
                                }
                            }
                            if (koniec)
                                break;
                        }
                    }
                    //if (!koniec)
                    //    saving = -1;
                    break;
                }

                if (!pridaloSa)
                    druhyPokus = true;
                pridaloSa = false;

                foreach (Smer a in nepridane)
                {
                    if (!jePriradena(cesty, a.Od, a.Do))
                    {
                        if (_poziadavky[a.Do] + _poziadavky[a.Od] <= pomCesta.Vozidlo.ObjemVozidla && _vozidla.Count > pocetAktualnePouzitychVozidiel)
                        {

                            Console.WriteLine("Nova Trasa");
                            Console.WriteLine("[ " + a.MestoOd + " ," + a.MestoDo + " ]");

                            int index = -1;
                            for (int x = 0; x < _vozidla.Count; x++)
                            {
                                if (_vozidla[x].Aktivne == false)
                                {
                                    index = x;
                                    break;
                                }
                            }

                            if (index != -1)
                            {
                                pomCesta = new Cesta(_vozidla[index]);
                                _vozidla[index].Aktivne = true;
                                cesty.Add(pomCesta);

                                pomCesta.Smery.Add(a);
                                pomCesta.Vozidlo.NaplnenyObjem += _poziadavky[a.Od] + _poziadavky[a.Do];

                                pridane += 2;
                                nepridane.Remove(a);
                                pocetAktualnePouzitychVozidiel++;
                                saving += a.Saving;
                                druhyPokus = false;
                                pridaloSa = true;
                                priradene.Add(a);

                                break;
                            }
                            else
                            {
                                druhyPokus = false;
                                nepridane.Remove(a);
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (!jeVRozdielnych(cesty, a.Od, a.Do))
                        {
                            pomCesta = dajCestu(cesty, a.Od, a.Do);
                            if (!nachadzaSa2x(pomCesta, a.Od, a.Do))
                            {
                                bool mozeSaPridat = false; ;

                                if (nachadzaSa(pomCesta, a.Od))
                                {
                                    if (pomCesta.Vozidlo.NaplnenyObjem + _poziadavky[a.Do] <= pomCesta.Vozidlo.ObjemVozidla)
                                    {
                                        pomCesta.Vozidlo.NaplnenyObjem += _poziadavky[a.Do];
                                        mozeSaPridat = true;
                                    }
                                }
                                else
                                {
                                    if (pomCesta.Vozidlo.NaplnenyObjem + _poziadavky[a.Od] <= pomCesta.Vozidlo.ObjemVozidla)
                                    {
                                        pomCesta.Vozidlo.NaplnenyObjem += _poziadavky[a.Od];
                                        mozeSaPridat = true;
                                    }
                                }

                                if (mozeSaPridat)
                                {
                                    Console.WriteLine("[ " + a.MestoOd + " ," + a.MestoDo + " ]");
                                    pomCesta.Smery.Add(a);
                                    pridane++;
                                    nepridane.Remove(a);

                                    saving += a.Saving;
                                    druhyPokus = false;
                                    pridaloSa = true;
                                    priradene.Add(a);

                                    if (pomCesta.Vozidlo.NaplnenyObjem == pomCesta.Vozidlo.ObjemVozidla)
                                        druhyPokus = true;
                                    break;
                                }
                                else
                                {
                                    druhyPokus = false;
                                    nepridane.Remove(a);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            return saving;

        }
    }

}
