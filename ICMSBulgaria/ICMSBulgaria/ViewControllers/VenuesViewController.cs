using CoreGraphics;
using CoreLocation;
using Foundation;
using ICMSBulgaria.Utils;
using MapKit;
using System;
using UIKit;

namespace ICMSBulgaria
{
    public partial class VenuesViewController : UIViewController
    {
        private MKMapView mapView;
        private UISegmentedControl mapTypes;

        public VenuesViewController (IntPtr handle) : base (handle)
        {            
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            this.NavigationController.NavigationBar.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            this.NavigationController.NavigationBar.ShadowImage = new UIImage();
            this.NavigationController.NavigationBar.Translucent = false;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            //Create the map:
            mapView = new MKMapView(View.Bounds);
            mapView.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
            View.AddSubview(mapView);

            //Create the annotation and add it to the map:
            InitMarkers();

            //Finally, ensure the map is centered to show the annotation:
            InitMap();

            LoadMapTypeController();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        /// <summary>Converts kilometres to latitude degrees</summary>
        public double KilometresToLatitudeDegrees(double kms)
        {
            double earthRadius = 6371.0; // in kms
            double radiansToDegrees = 180.0 / Math.PI;
            return (kms / earthRadius) * radiansToDegrees;
        }

        /// <summary>Converts kilometres to longitudinal degrees at a specified latitude</summary>
        public double KilometresToLongitudeDegrees(double kms, double atLatitude)
        {
            double earthRadius = 6371.0; // in kms
            double degreesToRadians = Math.PI / 180.0;
            double radiansToDegrees = 180.0 / Math.PI;
            // derive the earth's radius at that point in latitude
            double radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
            return (kms / radiusAtLatitude) * radiansToDegrees;
        }

        private void InitMarkers()
        {
            //Handles on-click actions for each of the annotations
            mapView.Delegate = new MapDelegate(this);

            var annotation = new VenueAnnotation(new CLLocationCoordinate2D(42.682311, 23.3003315), "University Hospital \"St Ivan Rilski\"", "This is a university, hospital located at Akademik Ivan Evstratiev Geshov Blvd. in Sofia.");
            mapView.AddAnnotation(annotation);

            annotation = new VenueAnnotation(new CLLocationCoordinate2D(42.683656, 23.313092), "Preclinical University Center, Medical University Sofia", "The Medical University of Sofia is a prestigious educational centre in Bulgaria");
            mapView.AddAnnotation(annotation);

            annotation = new VenueAnnotation(new CLLocationCoordinate2D(42.684819, 23.312402), "St Ekaterina Hospital", "The St. Ekaterina University Hospital is a university " +
                            "hospital in Sofia, the capital of Bulgaria. It was formed in" +
                            " 1985 as a national centre for cardiovascular diseases led by " +
                            "professor Aleksandar Chirkov. ");
            mapView.AddAnnotation(annotation);

            annotation = new VenueAnnotation(new CLLocationCoordinate2D(42.6834575, 23.3093334), "„Maychin Dom“ Hospital", "Тhе hоѕріtаl tаkеѕ wоmеn fоr gуnесоlоgісаl саrе, bіrth, аll kіndѕ оf gуnесоlоgісаl ореrаtіоnѕ, " +
                            "mоnіtоrіng аnd trеаtmеnt оf gуnесоlоgіс раthоlоgу аnd оthеrѕ.");
            mapView.AddAnnotation(annotation);

            annotation = new VenueAnnotation(new CLLocationCoordinate2D(42.684273, 23.3171503), "Culture Beat", "Culture Beat is a picturesque place in the heart of Sofia in the NDK (National Place of Culture) complex which functions as a bar, café and a night club.");
            mapView.AddAnnotation(annotation);

            annotation = new VenueAnnotation(new CLLocationCoordinate2D(42.6847251, 23.3167497), "National Palace of Culture", "The National Palace of Culture  is the largest, multifunctional conference and exhibition centre in " +
                            "south-eastern Europe. It was opened in 1981 in celebration of Bulgaria's 1300th anniversary.");
            mapView.AddAnnotation(annotation);

            annotation = new VenueAnnotation(new CLLocationCoordinate2D(42.6843099, 23.2949802), "Hotel Forum", "THotel Forum is a business hotel located near the city center with convenient transport links to important administrative centers and sightseeing");
            mapView.AddAnnotation(annotation);

            annotation = new VenueAnnotation(new CLLocationCoordinate2D(42.68146, 23.3036613), "SBALBB „Sveta Sofia“", "The Specialized Hospital for Pulmonary Diseases is the only one in the country," +
                            "a national institution performing complex modern diagnostic, therapeutic," +
                            " surgical, teaching of pulmonary diseases.");
            mapView.AddAnnotation(annotation);
        }

        private void InitMap()
        {
            CLLocationCoordinate2D coords = new CLLocationCoordinate2D(42.69770819999999, 23.321867500000053);

            MKCoordinateSpan span = new MKCoordinateSpan(KilometresToLatitudeDegrees(10), KilometresToLongitudeDegrees(10, coords.Latitude));
            mapView.Region = new MKCoordinateRegion(coords, span);
        }

        private void LoadMapTypeController()
        {
            int typesWidth = 260, typesHeight = 30, distanceFromBottom = 60;
            mapTypes = new UISegmentedControl(new CGRect((View.Bounds.Width - typesWidth) / 2, View.Bounds.Height - distanceFromBottom, typesWidth, typesHeight));
            mapTypes.InsertSegment("Road", 0, false);
            mapTypes.InsertSegment("Satellite", 1, false);
            mapTypes.InsertSegment("Hybrid", 2, false);
            mapTypes.SelectedSegment = 0; // Road is the default
            mapTypes.AutoresizingMask = UIViewAutoresizing.FlexibleTopMargin;
            mapTypes.ValueChanged += (s, e) => {
                switch (mapTypes.SelectedSegment)
                {
                    case 0:
                        mapView.MapType = MKMapType.Standard;
                        break;
                    case 1:
                        mapView.MapType = MKMapType.Satellite;
                        break;
                    case 2:
                        mapView.MapType = MKMapType.Hybrid;
                        break;
                }
            };
        }
    }
}