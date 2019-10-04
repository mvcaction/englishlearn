using Android.Media;
using Java.Lang;
using learnenglish.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Image = Xamarin.Forms.Image;

namespace learnenglish
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public int countertrue = 0;
        public int counter = 0;
        string[] alpha = { "apple", "banana", "milk", "pear", "rice", "pinapple", "carrot", "cherry", "orange", "lemon", "meat", "salt" };
        string[] Truce = { "apple", "banana", "milk", "pear", "rice", "pinapple", "carrot", "cherry", "orange", "lemon", "meat", "salt" };
        string baseurl = "http://0020d29b.ngrok.io";
        public MasterPage()
        {
            InitializeComponent();
           
            BindingContext = this;
            ImgBtnOne.Source = ImageSource.FromUri(new Uri(string.Format(baseurl+"/images/eatable/{0}.jpg", alpha[counter])));

            ImgBtnTwo.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter + 1])));

            ImgBtnThree.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter + 2])));

            ImgBtnFour.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter + 3])));

            TapGestureRecognizer tapcorrect = new TapGestureRecognizer();
            tapcorrect.Tapped += (sender, e) => {
                var imageSource = (Image)sender;
                string phrase = imageSource.Source.ToString();
                string[] words = phrase.Split('/');
                string ImageSelected = words[5];

                if (ImageSelected == Truce[countertrue] + ".jpg")
                {
                    MediaPlayer player = new MediaPlayer();
                    player.Completion += delegate
                    {
                        player.Release();
                        player.Dispose();
                    };
                    if (countertrue < 11)
                    {

                        player.SetAudioStreamType(Stream.Music);
                        player.SetDataSource(string.Format(baseurl + "/images/eatable/{0}.mp3", Truce[countertrue + 1]));
                        player.Prepare();
                     
                        player.Start();
                    }
                    switch (countertrue)
                    {
                        case 0:
                        case 1:
                        case 2:

                            {


                                ImgBtnOne.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter])));
                                // counter ++;

                                ImgBtnTwo.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter + 2])));
                                // counter ++;

                                ImgBtnThree.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter + 1])));
                                //counter ++;

                                ImgBtnFour.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter + 3])));

                                countertrue++;
                                MyMp3Player audioplayer = new MyMp3Player();

                                audioplayer.AudioPlayer("correct.mp3");
                            
                            }
                            break;
                        case 3:
                        case 4:

                        case 5:
                        case 6:



                            {
                                counter = 4;

                                ImgBtnOne.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter])));
                                // counter ++;

                                ImgBtnTwo.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter + 3])));
                                // counter ++;

                                ImgBtnThree.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter + 1])));
                                //counter ++;

                                ImgBtnFour.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter + 2])));

                                countertrue++;

                                MyMp3Player audioplayer = new MyMp3Player();
                                audioplayer.AudioPlayer("correct.mp3");
                               


                            }
                            break;
                        case 7:
                        case 8:

                        case 9:
                        case 10:
                        case 11:




                            {
                                counter = 8;


                                ImgBtnOne.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter+3])));
                                // counter ++;

                                ImgBtnTwo.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter + 1])));
                                // counter ++;

                                ImgBtnThree.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter ])));
                                //counter ++;

                                ImgBtnFour.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter + 2])));

                                countertrue++;
                               
                                MyMp3Player audioplayer = new MyMp3Player();
                                audioplayer.AudioPlayer("correct.mp3");
                             
                                if (countertrue == 12)
                                {
                                    Navigation.PushModalAsync(new MasterPage());
                                }


                            }
                            break;



                    }

                }
                else
                {
                    MyMp3Player audioplayer = new MyMp3Player();
                    audioplayer.AudioPlayer("false.mp3");

                    MediaPlayer player = new MediaPlayer();
                    player.Completion += delegate
                    {
                        player.Release();
                        player.Dispose();
                    };



                    player.SetAudioStreamType(Stream.Music);
                    player.SetDataSource(string.Format(baseurl + "/images/eatable/{0}.mp3", Truce[countertrue]));
                    player.Prepare();
                    player.Start();


                }

            };

            ImgBtnOne.GestureRecognizers.Add(tapcorrect);
            ImgBtnTwo.GestureRecognizers.Add(tapcorrect);
            ImgBtnThree.GestureRecognizers.Add(tapcorrect);
            ImgBtnFour.GestureRecognizers.Add(tapcorrect);


      
        }

        //async void OnChangePreviousPictureButtonClicked(object sender, EventArgs args)
        //{
        //    counter--;
        //    ImgSource.Source = ImageSource.FromUri(new Uri(string.Format("http://b6b747d6.ngrok.io/images/eatable/{0}.jpg", alpha[counter])));

        //}
        async void OnRepeatButtonClicked(object sender, EventArgs args)
        {
            MediaPlayer player = new MediaPlayer();
            player.Completion += delegate
            {
                player.Release();
                player.Dispose();
            };

            player.SetAudioStreamType(Stream.Music);
            player.SetDataSource(string.Format(baseurl + "/images/eatable/{0}.mp3", alpha[counter]));
            player.Prepare();
            player.Start();

        }
        [Obsolete]
        async void OnChangeNextPictureButtonClicked(object sender, EventArgs args)
        {

            counter = (counter <= 11) ? (counter+1) : 0;

            if (counter == 12)
            {
                counter = 0;
                ImgSource.IsVisible = false;
                KeyLayout.IsVisible = false;
                imagecounter.IsVisible = false;
                ExamLayout.IsVisible = true;
               // await Navigation.PushModalAsync(new Exam());
            }
            else
            {


                ImgSource.Source = ImageSource.FromUri(new Uri(string.Format(baseurl + "/images/eatable/{0}.jpg", alpha[counter])));
                switch (counter)
                {
                    
                    case 1:
                        l2.BackgroundColor = Color.Green;
                        l2.TextColor = Color.White;
                        break;
                    case 2:
                        l3.BackgroundColor = Color.Green;
                        l3.TextColor = Color.White;

                        break;
                    case 3:
                        l4.BackgroundColor = Color.Green;
                        l4.TextColor = Color.White;

                        break;
                    case 4:
                        l5.BackgroundColor = Color.Green;
                        l5.TextColor = Color.White;

                        break;
                    case 5:
                        l6.BackgroundColor = Color.Green;
                        l6.TextColor = Color.White;

                        break;
                    case 6:
                        l7.BackgroundColor = Color.Green;
                        l7.TextColor = Color.White;

                        break;
                    case 7:
                        l8.BackgroundColor = Color.Green;
                        l8.TextColor = Color.White;

                        break;
                    case 8:
                        l9.BackgroundColor = Color.Green;
                        l9.TextColor = Color.White;

                        break;
                    case 9:
                        l10.BackgroundColor = Color.Green;
                        l10.TextColor = Color.White;

                        break;
                    case 10:
                        l11.BackgroundColor = Color.Green;
                        l11.TextColor = Color.White;

                        break;
                    case 11:
                        l12.BackgroundColor = Color.Green;
                        l12.TextColor = Color.White;

                        break;
                }
                MediaPlayer player = new MediaPlayer();
                player.Completion += delegate
                {
                    player.Release();
                    player.Dispose();
                };

                player.SetAudioStreamType(Stream.Music);
                player.SetDataSource(string.Format(baseurl + "/images/eatable/{0}.mp3", alpha[counter]));
                player.Prepare();
                player.Start();

            }
           




        }
        async void OnButton1Clicked(object sender, EventArgs args)
        {
            Selector.IsVisible = false;
            ImgSource.IsVisible = true;
            KeyLayout.IsVisible = true;
            imagecounter.IsVisible = true;

        }


    }
}