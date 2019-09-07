using learnenglish.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace learnenglish
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
       public int counter = 0;

        public string Text { set; get; } = "a.jpg";
        public string[] NameArray;
        public MasterPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
        async void OnChangePictureButtonClicked(object sender, EventArgs args)
        {
            char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

            MyMp3Player audioplayer = new MyMp3Player();
           counter= (counter < 4) ? (counter+1) : 0;
            
                
                string name = string.Format("{0}.jpg", alpha[counter].ToString());
                ImgSource.Source = name;


         
          //  audioplayer.AudioPlayer("a.mp3");
        }

    }
}