Using System;
Using System.Collections.Generic;
Using System.IO;
Using System.Windows.Controls;
Using Newtonsoft.Json;

Namespace Kinecture.UI.View
{
    /// <summary>
    /// homeview: lijst met oefeningen en knop om te beginnen
    /// </summary>
    Partial Public Class HomeView :  UserControl
    {
        /// <summary>
        /// Initializes a New instance of the HomeView class.
        /// </summary>
        Public HomeView()
        {
            InitializeComponent();
#If DEBUGThen
            String location = @"..\..\Json\OefeningenDict.json";
#else
            string location = @"Json\OefeningenDict.json";

#End If
            location = Path.GetFullPath(location);
            var oefeningStreamreader = New StreamReader(Path.GetFullPath(location));
            GetExercices(oefeningStreamreader);
        }

        Private void GetExercices(StreamReader f)
        {
            //inladen json -> oefeningen
            String json = f.ReadToEnd();
            List<OefeningInfo> oefeningen = JsonConvert.DeserializeObject<List<OefeningInfo>>(json);
            listExercices.ItemsSource = oefeningen;

        }

        Private void listExercices_SelectionChanged(Object sender, SelectionChangedEventArgs e)
        {
            detailGrid.Visibility = System.Windows.Visibility.Visible;
        }
    }

    Public Class OefeningInfo
    {
        Public String name { Get; Set; }
        Public String image { Get; Set; }
        Public String json { Get; Set; }
        Public String description { Get; Set; }
        Public String oefening { Get; Set; }

        Public OefeningInfo(String name, string image, string json, string description, string oefening)
        {

            this.name = name;
            this.image = "../.." + image;
            this.description = description;
            this.oefening = oefening;

#if DEBUGThen

            this.json = "../.." + json;
#else

            this.json = json;
#End If
        }
    }
}