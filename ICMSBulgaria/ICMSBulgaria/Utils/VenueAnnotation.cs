using CoreLocation;
using MapKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICMSBulgaria.Utils
{
    class VenueAnnotation : MKAnnotation
    {
        CLLocationCoordinate2D coord;
        string title, subtitle;

        public override CLLocationCoordinate2D Coordinate { get { return coord; } }
        public override void SetCoordinate(CLLocationCoordinate2D value)
        {
            coord = value;
        }
        public override string Title { get { return title; } }
        public override string Subtitle { get { return subtitle; } }

        public VenueAnnotation(CLLocationCoordinate2D coordinate, string title, string subtitle)
        {
            this.coord = coordinate;
            this.title = title;
            this.subtitle = subtitle;
        }
    }
}
