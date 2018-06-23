using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GMap.NET.WindowsForms;
using GMap.NET;
using GMap.NET.WindowsForms.Markers;
using System.ComponentModel;
using Bakalarka.Windows;
using Google.Maps;
using Google.Maps.Geocoding;
using Bakalarka.Mapa.Pages;


namespace Bakalarka.Mapa
{
    /// <summary>
    /// Interaction logic for Mapa.xaml
    /// </summary>
    public partial class Mapa_Window : Window, INotifyPropertyChanged
    {
        bool zavriet;
        GMapControl gMapControl;
        GeoCoderStatusCode statusCode;
        GeocodingProvider geocodingProvider;
        GMapOverlay markers;
        GMapOverlay routes;
        public bool Zavriet { get => zavriet; set => zavriet = value; }
        List<Cesta> zoznamCiest;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<Cesta> ZoznamCiest
        {
            get => zoznamCiest; set
            {
                if (zoznamCiest != value)
                {
                    zoznamCiest = value;
                    OnPropertyChanged("ZoznamCiest");
                }
            }
        }

        public GMapControl GMapControl { get => gMapControl; set => gMapControl = value; }
        public MapaPage MapaPage { get => mapaPage; set => mapaPage = value; }
        public LoadingPage LoadingPage { get => loadingPage; set => loadingPage = value; }
        public GMapOverlay Routes { get => routes; set => routes = value; }
        public GMapOverlay Markers { get => markers; set => markers = value; }

        LoadingPage loadingPage;
        MapaPage mapaPage;
        public Mapa_Window()
        {
            InitializeComponent();
            DataContext = this;
            Zavriet = false; // pre zavretie okna, ale nie uplne vypnutie


            mapaPage = new MapaPage();
            LoadingPage = new LoadingPage();

            ZoznamCiest = new List<Cesta>();

            // Window form vo WPF.
            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();

            //Gmap zakladne nastavenia
            GMapControl = new GMap.NET.WindowsForms.GMapControl();
            GMapControl.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            geocodingProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            statusCode = GeoCoderStatusCode.Unknow;

            Markers = new GMapOverlay("Markers");
            Routes = new GMapOverlay("Routes");
            GMapControl.Overlays.Add(Markers);
            GMapControl.Overlays.Add(Routes);


            host.Child = GMapControl;
            MapaPage.MainGrid.Children.Add(host);
            //HlavnyFrame.Content = mapaPage;
            GMapControl.MaxZoom = 25;
            GMapControl.Zoom = 8;
            GMapControl.SetPositionByKeywords("Slovakia");
            GMapControl.ShowCenter = false;
        }


     
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GMapControl.MaxZoom = 25;
            GMapControl.Zoom = 8;
            GMapControl.SetPositionByKeywords("Slovakia");
            GMapControl.ShowCenter = false;
        }

        public void pridajMarker(string adresa, GMarkerGoogleType typ)
        {
            GMapMarker marker = new GMarkerGoogle(
            geocodingProvider.GetPoint(adresa, out statusCode).Value,
            typ);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = adresa;
            Markers.Markers.Add(marker);
        }

        public void pridajMarker(PointLatLng adresa, String adresaS, GMarkerGoogleType typ)
        {
            GMapMarker marker = new GMarkerGoogle(adresa, typ);
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver;
            marker.ToolTipText = adresaS;
            Markers.Markers.Add(marker);
        }

        public void pridajCestu(string startAdresa, string endAdresa, System.Drawing.Color color, int strokeWidth)
        {
            try
            {

                PointLatLng A;
                PointLatLng B;
                GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyBjRde0e9LBWKqdj2-8m3l3fcWaN2Mv4Ck"));

                var request = new GeocodingRequest();
                request.Address = startAdresa;
                var response = new GeocodingService().GetResponse(request);

                if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
                {
                    var result = response.Results.First();
                    A = new PointLatLng(result.Geometry.Location.Latitude, result.Geometry.Location.Longitude);
                }
                else
                {
                    Upraveny_MessageBox.Show("Nepodarilo sa najsť " + startAdresa);
                    throw new Exception();
                }

                request = new GeocodingRequest();
                request.Address = endAdresa;
                response = new GeocodingService().GetResponse(request);

                if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
                {
                    var result = response.Results.First();
                    B = new PointLatLng(result.Geometry.Location.Latitude, result.Geometry.Location.Longitude);
                }
                else
                {
                    Upraveny_MessageBox.Show("Nepodarilo sa najsť " + endAdresa);
                    throw new Exception();
                }


                MapRoute route = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetRoute(A, B, false, false, 15);
                GMapRoute r = new GMapRoute(route.Points, "My route");
                Routes.Routes.Add(r);

                pridajMarker(A, startAdresa, GMarkerGoogleType.blue_dot);

                pridajMarker(B, endAdresa, GMarkerGoogleType.blue_dot);


                r.Stroke = (System.Drawing.Pen)r.Stroke.Clone();
                r.Stroke.Color = color;
                GMapControl.Overlays.Add(Routes);
            }
            catch (Exception)
            {
                try
                {
                    PointLatLng A;
                    PointLatLng B;
                    GoogleSigned.AssignAllServices(new GoogleSigned("AIzaSyBjRde0e9LBWKqdj2-8m3l3fcWaN2Mv4Ck"));

                    var request = new GeocodingRequest();
                    request.Address = startAdresa;
                    var response = new GeocodingService().GetResponse(request);

                    if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
                    {
                        var result = response.Results.First();
                        A = new PointLatLng(result.Geometry.Location.Latitude, result.Geometry.Location.Longitude);
                    }
                    else
                    {
                        Upraveny_MessageBox.Show("Nepodarilo sa najsť " + startAdresa);
                        throw new Exception();
                    }

                    request = new GeocodingRequest();
                    request.Address = endAdresa;
                    response = new GeocodingService().GetResponse(request);

                    if (response.Status == ServiceResponseStatus.Ok && response.Results.Count() > 0)
                    {
                        var result = response.Results.First();
                        B = new PointLatLng(result.Geometry.Location.Latitude, result.Geometry.Location.Longitude);
                    }
                    else
                    {
                        Upraveny_MessageBox.Show("Nepodarilo sa najsť " + endAdresa);
                        throw new Exception();
                    }


                    MapRoute route = GMap.NET.MapProviders.OpenStreetMapProvider.Instance.GetRoute(A, B, false, false, 15);
                    GMapRoute r = new GMapRoute(route.Points, "My route");
                    Routes.Routes.Add(r);

                    pridajMarker(A, startAdresa, GMarkerGoogleType.blue_dot);

                    pridajMarker(B, endAdresa, GMarkerGoogleType.blue_dot);


                    r.Stroke = (System.Drawing.Pen)r.Stroke.Clone();
                    r.Stroke.Color = color;
                    GMapControl.Overlays.Add(Routes);

                }
                catch (Exception) { }
            }
        }



        public void pridajCesty(string startAdresa, string endAdresa, List<string> listAdries,
            System.Drawing.Color color, int strokeWidth, String nazovCesty, LoadingPage loadingPage, int pocetCiest)
        {
            if (listAdries.Count == 0)
            {
                var pom = new List<string>();
                pom.Add(startAdresa);
                pom.Add(endAdresa);

                Cesta cesta = new Cesta(pom, nazovCesty);
                pridajCestu(startAdresa, endAdresa, color, strokeWidth);
                zoznamCiest.Add(cesta);
                loadingPage.updateProgressBar(100);
            }
            else
            {
                Cesta cesta = new Cesta(listAdries, nazovCesty);
                for (int i = 0; i < listAdries.Count; i++)
                {
                    if (i + 1 == listAdries.Count)
                    {
                        pridajCestu(listAdries[i], listAdries[0], color, strokeWidth);
                        loadingPage.updateProgressBar((100 / Convert.ToDouble(listAdries.Count)) / pocetCiest);

                    }
                    else
                    {
                        pridajCestu(listAdries[i], listAdries[i + 1], color, strokeWidth);
                        loadingPage.updateProgressBar((100 / Convert.ToDouble(listAdries.Count)) / pocetCiest);
                    }
                }
                this.Dispatcher.Invoke(() =>
                {
                    ListBoxTrasy.Items.Add(cesta);
                    zoznamCiest.Add(cesta);
                });
            }
        }

        public GMapRoute pridajCestu(string startAdresa, string endAdresa, List<string> listAdries, System.Drawing.Color color, int strokeWidth)
        {
            List<PointLatLng> listAdriesLatLng = new List<PointLatLng>();
            foreach (String adresa in listAdries)
            {
                try
                {
                    listAdriesLatLng.Add(geocodingProvider.GetPoint(adresa, out statusCode).Value);
                }
                catch (Exception)
                {
                    MessageBox.Show("Nenašla sa adresa " + adresa);
                }
            }

            try
            {
                MapRoute route = GMap.NET.MapProviders.GoogleMapProvider
                                                  .Instance.GetRoute(geocodingProvider.GetPoint(startAdresa, out statusCode).Value,
                                                  geocodingProvider.GetPoint(endAdresa, out statusCode).Value, listAdriesLatLng, false, false, 15, false);
                GMapRoute r = new GMapRoute(route.Points, "My route");

                var routes = new GMapOverlay("Route");
                routes.Routes.Add(r);

                foreach (var adresa in listAdries)
                {
                    pridajMarker(adresa, GMarkerGoogleType.blue_dot);
                }

                pridajMarker(startAdresa, GMarkerGoogleType.blue_dot);
                pridajMarker(endAdresa, GMarkerGoogleType.blue_dot);

                r.Stroke.Width = strokeWidth;
                r.Stroke.Color = color;

                return r;

            }
            catch (Exception)
            {
                MessageBox.Show("Nepodarilo sa vygenerovať mapu");
                return null;
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!Zavriet)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void CloseButt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window window = (sender as Button).Tag as Window;
            window.Close();
        }

        private void MinimizeButt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window window = (sender as Button).Tag as Window;
            window.WindowState = System.Windows.WindowState.Minimized;
        }

        private void MaximizeButt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Window window = (sender as Button).Tag as Window;
            window.WindowState = System.Windows.WindowState.Maximized;
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                CestaNaZobrazenie cestaNaZobrazenie = new CestaNaZobrazenie();
                var cesta = ((sender as TextBlock).DataContext as Cesta);
                cestaNaZobrazenie.ZoznamAdries = cesta.Destinacie;
                cestaNaZobrazenie.NazovCesty = cesta.NazovCesty;
                cestaNaZobrazenie.Show();
            }
        }
    }
}
